namespace SistemaGestaoEventos
{
    partial class AddClienteForm
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(96, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(287, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(96, 93);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(287, 27);
            textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(96, 152);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(287, 27);
            textBox3.TabIndex = 2;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(96, 209);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(287, 27);
            textBox4.TabIndex = 3;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(96, 266);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(287, 27);
            textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(96, 324);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(287, 27);
            textBox6.TabIndex = 5;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(96, 384);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(287, 27);
            textBox7.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 16);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 7;
            label1.Text = "NIF";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 70);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 8;
            label2.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 129);
            label3.Name = "label3";
            label3.Size = new Size(145, 20);
            label3.TabIndex = 9;
            label3.Text = "Número de Telefone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(96, 186);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 10;
            label4.Text = "Endereço";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 243);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 11;
            label5.Text = "ID da reserva";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(96, 301);
            label6.Name = "label6";
            label6.Size = new Size(46, 20);
            label6.TabIndex = 12;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(96, 361);
            label7.Name = "label7";
            label7.Size = new Size(27, 20);
            label7.TabIndex = 13;
            label7.Text = "CC";
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 20F);
            label8.Location = new Point(389, 22);
            label8.Name = "label8";
            label8.Size = new Size(404, 46);
            label8.TabIndex = 14;
            label8.Text = "Insira os dados do Cliente";
            label8.Click += label8_Click;
            // 
            // button1
            // 
            button1.Location = new Point(529, 383);
            button1.Name = "button1";
            button1.Size = new Size(187, 29);
            button1.TabIndex = 15;
            button1.Text = "Adicionar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(529, 348);
            button2.Name = "button2";
            button2.Size = new Size(187, 29);
            button2.TabIndex = 16;
            button2.Text = "Voltar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(416, 93);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(353, 228);
            dataGridView1.TabIndex = 17;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // AddClienteForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "AddClienteForm";
            Text = "AddClienteForm";
            Load += AddClienteForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
    }
}