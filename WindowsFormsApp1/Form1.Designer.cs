namespace WindowsFormsApp1
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.delete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add_ = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.disable = new System.Windows.Forms.Button();
            this.Service_seach = new System.Windows.Forms.Button();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(535, 30);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Начать поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(5, 16);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(497, 361);
            this.checkedListBox1.TabIndex = 3;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(535, 96);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(141, 46);
            this.delete.TabIndex = 4;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(-1, 31);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 418);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.checkedListBox3);
            this.tabPage1.Controls.Add(this.checkedListBox2);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(721, 389);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "В Реестре";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 215);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "HKEY_LOCAL_MACHINE:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "HKEY_CURRENT_USER:\r\n";
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(5, 238);
            this.checkedListBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(497, 140);
            this.checkedListBox3.TabIndex = 8;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(5, 30);
            this.checkedListBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(497, 140);
            this.checkedListBox2.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(551, 30);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 41);
            this.button2.TabIndex = 5;
            this.button2.Text = "Начать поиск";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(551, 96);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 46);
            this.button3.TabIndex = 7;
            this.button3.Text = "Удалить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.Add_);
            this.tabPage2.Controls.Add(this.Open);
            this.tabPage2.Controls.Add(this.checkedListBox1);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.delete);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(721, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "В Папках";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(535, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 7;
            // 
            // Add_
            // 
            this.Add_.Location = new System.Drawing.Point(535, 162);
            this.Add_.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add_.Name = "Add_";
            this.Add_.Size = new System.Drawing.Size(141, 46);
            this.Add_.TabIndex = 6;
            this.Add_.Text = "Добавить";
            this.Add_.UseVisualStyleBackColor = true;
            this.Add_.Click += new System.EventHandler(this.Add__Click);
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(535, 331);
            this.Open.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(141, 46);
            this.Open.TabIndex = 5;
            this.Open.Text = "Открыть папки";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.button5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.disable);
            this.tabPage3.Controls.Add(this.Service_seach);
            this.tabPage3.Controls.Add(this.checkedListBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(721, 389);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "В Службах";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(459, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(253, 72);
            this.label7.TabIndex = 7;
            this.label7.Text = "Внимание !\r\nНе выключайте системные\r\nслужбы Windows";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(464, 355);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 28);
            this.button5.TabIndex = 6;
            this.button5.Text = "ОК";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Службы в режиме автозагрузки:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(492, 192);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 41);
            this.button4.TabIndex = 4;
            this.button4.Text = "Добавить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // disable
            // 
            this.disable.Location = new System.Drawing.Point(492, 119);
            this.disable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.disable.Name = "disable";
            this.disable.Size = new System.Drawing.Size(141, 41);
            this.disable.TabIndex = 3;
            this.disable.Text = "Выключить";
            this.disable.UseVisualStyleBackColor = true;
            this.disable.Click += new System.EventHandler(this.disable_Click);
            // 
            // Service_seach
            // 
            this.Service_seach.Location = new System.Drawing.Point(492, 41);
            this.Service_seach.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Service_seach.Name = "Service_seach";
            this.Service_seach.Size = new System.Drawing.Size(141, 41);
            this.Service_seach.TabIndex = 2;
            this.Service_seach.Text = "Начать поиск";
            this.Service_seach.UseVisualStyleBackColor = true;
            this.Service_seach.Click += new System.EventHandler(this.Service_seach_Click);
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Location = new System.Drawing.Point(11, 41);
            this.checkedListBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(447, 344);
            this.checkedListBox4.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.Controls.Add(this.button6);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(721, 389);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Проверка системы";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(10, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal;
            this.richTextBox1.Size = new System.Drawing.Size(502, 375);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(533, 55);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(169, 47);
            this.button6.TabIndex = 1;
            this.button6.Text = "Начать проверку";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(-1, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Автозагрузки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Add_;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button Service_seach;
        private System.Windows.Forms.CheckedListBox checkedListBox4;
        private System.Windows.Forms.Button disable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

