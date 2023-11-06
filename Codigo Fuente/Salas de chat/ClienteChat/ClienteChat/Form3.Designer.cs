namespace ClienteChat
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 14);
            label1.TabIndex = 0;
            label1.Tag = "salaname";
            label1.Text = "Nombre de sala";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Unispace", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(697, 9);
            label2.Name = "label2";
            label2.Size = new Size(105, 14);
            label2.TabIndex = 1;
            label2.Tag = "username";
            label2.Text = "nombre usuario";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 413);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(689, 23);
            textBox1.TabIndex = 2;
            textBox1.Tag = "mensaje";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Font = new Font("Unispace", 9.749999F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(707, 403);
            button1.Name = "button1";
            button1.Size = new Size(89, 40);
            button1.TabIndex = 3;
            button1.Tag = "enviarBoton";
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(29, 29, 29);
            panel1.Controls.Add(richTextBox1);
            panel1.Location = new Point(12, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 332);
            panel1.TabIndex = 4;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.MenuText;
            richTextBox1.Location = new Point(18, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(741, 291);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Form3";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button button1;
        private Panel panel1;
        private RichTextBox richTextBox1;
    }
}