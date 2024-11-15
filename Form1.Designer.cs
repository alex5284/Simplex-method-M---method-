namespace lab1
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
            this.dgMatrix = new System.Windows.Forms.DataGridView();
            this.btnCalc = new System.Windows.Forms.Button();
            this.tbn = new System.Windows.Forms.TextBox();
            this.tbm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dg2 = new System.Windows.Forms.DataGridView();
            this.btnTest = new System.Windows.Forms.Button();
            this.dgF = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgF)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMatrix
            // 
            this.dgMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMatrix.Location = new System.Drawing.Point(58, 182);
            this.dgMatrix.Name = "dgMatrix";
            this.dgMatrix.RowHeadersWidth = 51;
            this.dgMatrix.RowTemplate.Height = 24;
            this.dgMatrix.Size = new System.Drawing.Size(775, 349);
            this.dgMatrix.TabIndex = 0;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(1024, 297);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(82, 37);
            this.btnCalc.TabIndex = 1;
            this.btnCalc.Text = "Calc";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // tbn
            // 
            this.tbn.Location = new System.Drawing.Point(1005, 174);
            this.tbn.Name = "tbn";
            this.tbn.Size = new System.Drawing.Size(57, 22);
            this.tbn.TabIndex = 2;
            this.tbn.Text = "3";
            // 
            // tbm
            // 
            this.tbm.Location = new System.Drawing.Point(1123, 174);
            this.tbm.Name = "tbm";
            this.tbm.Size = new System.Drawing.Size(57, 22);
            this.tbm.TabIndex = 3;
            this.tbm.Text = "4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(975, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "n =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1089, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "m =";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(1024, 231);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(82, 36);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dg2
            // 
            this.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg2.Location = new System.Drawing.Point(856, 182);
            this.dg2.Name = "dg2";
            this.dg2.RowHeadersWidth = 51;
            this.dg2.RowTemplate.Height = 24;
            this.dg2.Size = new System.Drawing.Size(97, 349);
            this.dg2.TabIndex = 7;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1123, 231);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(88, 36);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // dgF
            // 
            this.dgF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgF.Location = new System.Drawing.Point(58, 56);
            this.dgF.Name = "dgF";
            this.dgF.RowHeadersWidth = 51;
            this.dgF.RowTemplate.Height = 24;
            this.dgF.Size = new System.Drawing.Size(775, 87);
            this.dgF.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(843, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "->";
            // 
            // cb
            // 
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] {
            "MIN",
            "MAX"});
            this.cb.Location = new System.Drawing.Point(874, 109);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(79, 24);
            this.cb.TabIndex = 11;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(1005, 372);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(223, 132);
            this.listBox1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 616);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgF);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.dg2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbm);
            this.Controls.Add(this.tbn);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.dgMatrix);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMatrix;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox tbn;
        private System.Windows.Forms.TextBox tbm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.DataGridView dg2;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.DataGridView dgF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb;
        private System.Windows.Forms.ListBox listBox1;
    }
}

