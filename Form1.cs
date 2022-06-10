using PluginInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private string[] classesNames;
        private List<object> objects;

        List<IPlugin> plugins;
        string pluginsPath = "D:/Lab4/Plugins";
        public Form1()
        {
            InitializeComponent();
            classesNames=new string[5] { "Processor","Monitor","VideoAdapter","HardDisk","OperativeMemory"};
            for(int i=0;i<classesNames.Length;i++)
            {
                classNames.Items.Add(classesNames[i]);
            }
            classNames.SelectedItem = classesNames[0];
            objects=new List<object>();
            deleteBtn.Enabled = false;
            serializeBtn.Enabled = false;
            RefreshPlugins();
        }

        public void RefreshPlugins()
        {
            plugins.Clear();

            DirectoryInfo pluginDirectory = new DirectoryInfo(pluginsPath);
            if (!pluginDirectory.Exists)
                pluginDirectory.Create();

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
               Assembly asm = Assembly.LoadFrom(file);
               var types = asm.GetTypes().
                                Where(t => t.GetInterfaces().
                                Where(i => i.FullName == typeof(IPlugin).FullName).Any());
                foreach (var type in types)
                {
                    var plugin = asm.CreateInstance(type.FullName) as IPlugin;
                    plugins.Add(plugin);
                }
            }
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            string className = "Lab3.";
            className += classNames.SelectedItem.ToString();
            object obj=Activator.CreateInstance(Type.GetType(className));
            objects.Add(obj);
            objectNames.Items.Add(objectTextBox.Text);
            serializeBtn.Enabled = true;
        }

        private void objectNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteBtn.Enabled = true;
            objectValueTypes.Items.Clear();
            objectValues.Items.Clear();
            int index = objectNames.SelectedIndex;
            if (index<objects.Count && index>=0)
            {
                object obj = objects[index];
                var fields = obj.GetType().GetProperties(BindingFlags.FlattenHierarchy|BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                for (int i = 0; i < fields.Length; i++)
                {
                    objectValueTypes.Items.Add(fields[i].Name);
                    objectValues.Items.Add(fields[i].GetValue(obj).ToString());
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int index= objectNames.SelectedIndex;
            objects.RemoveAt(index);
            objectNames.Items.RemoveAt(index);
        }


        private void acceptBtn_Click(object sender, EventArgs e)
        {
            
            string newValue = ValueTextBox.Text;
            string fieldName = objectValueTypes.Items[objectValues.SelectedIndex].ToString();
            int objIndex = objectNames.SelectedIndex;
            var fields=objects[objIndex].GetType().GetProperties(BindingFlags.FlattenHierarchy|BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldType = "";
            var obj = objects[objIndex];
            PropertyInfo neededField = null;
            for(int i=0;i<fields.Length;i++)
            {
                if (fields[i].Name == fieldName)
                {
                    neededField = fields[i];
                    break;
                }
            }
            try
            {
                object ob=Convert.ChangeType(newValue,neededField.PropertyType);
                neededField.SetValue(obj, ob);
                objectValues.Items[objectValues.SelectedIndex] = newValue;
            }
            catch
            {
                MessageBox.Show("Введённое значение не подходит под тип: " + neededField.PropertyType);
            }
        }

        private void serializeBtn_Click(object sender, EventArgs e)
        {
            FileStream fstream = new FileStream("D://Lab3/serialized",FileMode.Create);
            for(int i=0;i<objects.Count;i++)
            {
                String objName = objectNames.Items[i].ToString();
                fstream.Write(BitConverter.GetBytes(objName.Length),0,4);
                fstream.Write(Encoding.UTF8.GetBytes(objName),0,objName.Length);
                String className = objects[i].GetType().FullName;
                fstream.Write(BitConverter.GetBytes(className.Length),0,4);
                fstream.Write(Encoding.UTF8.GetBytes(className),0,className.Length);
                var fields = objects[i].GetType().GetProperties(BindingFlags.FlattenHierarchy|BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                for(int j=0;j<fields.Length;j++)
                {                    
                    var value = fields[j].GetValue(objects[i]);
                    byte[] arr;
                    BinaryFormatter bf = new BinaryFormatter();
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bf.Serialize(ms, value);
                        arr=ms.ToArray(); 
                    }
                    fstream.Write(BitConverter.GetBytes(arr.Count()),0,4);
                    fstream.Write(arr, 0, arr.Count());
                }
            }
            fstream.Close();
        }

        public byte[] GetSomeBytes(byte[] arr,int offset,int count)
        {
            byte[] bytes = new byte[count];
            for(int i=offset;i<offset+count;i++)
            {
                bytes[i-offset] = arr[i];
            }
            return bytes;
        }

        public object FromByteArray(byte[] data)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(data, 0, data.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }

        private void deserializeBtn_Click(object sender, EventArgs e)
        {
            FileStream fstream = new FileStream("d://Lab3/serialized", FileMode.Open);
            int offset = 0;
            byte[] arr = new byte[fstream.Length];
            fstream.Read(arr, 0, arr.Length);
            while(offset<fstream.Length)
            {
                byte[] temp = GetSomeBytes(arr, offset, 4);
                int objectNameSize = BitConverter.ToInt32(temp, 0);
                offset += 4;
                temp =new byte[objectNameSize];
                temp=GetSomeBytes(arr,offset,objectNameSize);
                string objName = Encoding.UTF8.GetString(temp);
                objectNames.Items.Add(objName);
                offset+=objectNameSize;
                temp = new byte[4];
                temp = GetSomeBytes(arr, offset, 4);
                int classNameSize=BitConverter.ToInt32(temp, 0);
                offset += 4;
                temp=new byte[classNameSize];
                temp=GetSomeBytes(arr,offset, classNameSize);
                string className = Encoding.UTF8.GetString(temp);
                offset += classNameSize;
                object obj = Activator.CreateInstance(Type.GetType(className));
                objects.Add(obj);
                var fields = obj.GetType().GetProperties(BindingFlags.FlattenHierarchy|BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                for(int i=0; i<fields.Length; i++)
                {
                    temp = new byte[4];
                    temp = GetSomeBytes(arr, offset, 4);
                    int size = BitConverter.ToInt32(temp, 0);
                    offset += 4;
                    temp = new byte[size];
                    temp = GetSomeBytes(arr, offset, size);
                    offset+=size;
                    Type type=fields[i].PropertyType;
                    object objType = FromByteArray(temp);
                    object newValue = Convert.ChangeType(objType, type);
                    fields[i].SetValue(obj, newValue);
                }
            }
        }


    }
}
