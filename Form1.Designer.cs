namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            listView1 = new ListView();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 24);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // listView1
            // 
            listView1.Location = new Point(0, 50);
            listView1.Margin = new Padding(3, 2, 3, 2);
            listView1.Name = "listView1";
            listView1.Size = new Size(561, 279);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(567, 77);
            radioButton1.Margin = new Padding(3, 2, 3, 2);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(80, 19);
            radioButton1.TabIndex = 3;
            radioButton1.TabStop = true;
            radioButton1.Text = "Убывание";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(567, 100);
            radioButton2.Margin = new Padding(3, 2, 3, 2);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(94, 19);
            radioButton2.TabIndex = 4;
            radioButton2.TabStop = true;
            radioButton2.Text = "Возрастание";
            radioButton2.UseVisualStyleBackColor = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(567, 50);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(110, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(textBox1);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(listView1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private ListView listView1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
    }
}
