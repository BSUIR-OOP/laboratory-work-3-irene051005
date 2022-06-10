namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.objectNames = new System.Windows.Forms.ListBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.serializeBtn = new System.Windows.Forms.Button();
            this.deserializeBtn = new System.Windows.Forms.Button();
            this.objectTextBox = new System.Windows.Forms.TextBox();
            this.classNames = new System.Windows.Forms.ComboBox();
            this.objectValueTypes = new System.Windows.Forms.ListBox();
            this.objectValues = new System.Windows.Forms.ListBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectNames
            // 
            this.objectNames.FormattingEnabled = true;
            this.objectNames.ItemHeight = 16;
            this.objectNames.Location = new System.Drawing.Point(63, 41);
            this.objectNames.Name = "objectNames";
            this.objectNames.Size = new System.Drawing.Size(194, 212);
            this.objectNames.TabIndex = 0;
            this.objectNames.SelectedIndexChanged += new System.EventHandler(this.objectNames_SelectedIndexChanged);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(12, 375);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(89, 31);
            this.createBtn.TabIndex = 1;
            this.createBtn.Text = "Создать";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(119, 375);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(89, 31);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Удалить";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // serializeBtn
            // 
            this.serializeBtn.Location = new System.Drawing.Point(227, 375);
            this.serializeBtn.Name = "serializeBtn";
            this.serializeBtn.Size = new System.Drawing.Size(130, 31);
            this.serializeBtn.TabIndex = 3;
            this.serializeBtn.Text = "Сериализовать";
            this.serializeBtn.UseVisualStyleBackColor = true;
            this.serializeBtn.Click += new System.EventHandler(this.serializeBtn_Click);
            // 
            // deserializeBtn
            // 
            this.deserializeBtn.Location = new System.Drawing.Point(372, 375);
            this.deserializeBtn.Name = "deserializeBtn";
            this.deserializeBtn.Size = new System.Drawing.Size(133, 31);
            this.deserializeBtn.TabIndex = 4;
            this.deserializeBtn.Text = "Десериализовать";
            this.deserializeBtn.UseVisualStyleBackColor = true;
            this.deserializeBtn.Click += new System.EventHandler(this.deserializeBtn_Click);
            // 
            // objectTextBox
            // 
            this.objectTextBox.Location = new System.Drawing.Point(63, 300);
            this.objectTextBox.Name = "objectTextBox";
            this.objectTextBox.Size = new System.Drawing.Size(164, 22);
            this.objectTextBox.TabIndex = 5;
            // 
            // classNames
            // 
            this.classNames.FormattingEnabled = true;
            this.classNames.Location = new System.Drawing.Point(252, 300);
            this.classNames.Name = "classNames";
            this.classNames.Size = new System.Drawing.Size(121, 24);
            this.classNames.TabIndex = 6;
            // 
            // objectValueTypes
            // 
            this.objectValueTypes.FormattingEnabled = true;
            this.objectValueTypes.ItemHeight = 16;
            this.objectValueTypes.Location = new System.Drawing.Point(410, 41);
            this.objectValueTypes.Name = "objectValueTypes";
            this.objectValueTypes.Size = new System.Drawing.Size(190, 212);
            this.objectValueTypes.TabIndex = 7;
            // 
            // objectValues
            // 
            this.objectValues.FormattingEnabled = true;
            this.objectValues.ItemHeight = 16;
            this.objectValues.Location = new System.Drawing.Point(597, 41);
            this.objectValues.Name = "objectValues";
            this.objectValues.Size = new System.Drawing.Size(190, 212);
            this.objectValues.TabIndex = 8;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(468, 302);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(164, 22);
            this.ValueTextBox.TabIndex = 9;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(659, 296);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(89, 31);
            this.acceptBtn.TabIndex = 10;
            this.acceptBtn.Text = "Ввести";
            this.acceptBtn.UseVisualStyleBackColor = true;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 473);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.objectValues);
            this.Controls.Add(this.objectValueTypes);
            this.Controls.Add(this.classNames);
            this.Controls.Add(this.objectTextBox);
            this.Controls.Add(this.deserializeBtn);
            this.Controls.Add(this.serializeBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.objectNames);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox objectNames;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button serializeBtn;
        private System.Windows.Forms.Button deserializeBtn;
        private System.Windows.Forms.TextBox objectTextBox;
        private System.Windows.Forms.ComboBox classNames;
        private System.Windows.Forms.ListBox objectValueTypes;
        private System.Windows.Forms.ListBox objectValues;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Button acceptBtn;
    }
}

