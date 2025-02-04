namespace form1
{
    partial class Form4
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
            this.btnorder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpph = new System.Windows.Forms.MaskedTextBox();
            this.txtconsole = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnorder
            // 
            this.btnorder.AutoSize = true;
            this.btnorder.BackColor = System.Drawing.Color.Lime;
            this.btnorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.btnorder.Location = new System.Drawing.Point(600, 355);
            this.btnorder.Name = "btnorder";
            this.btnorder.Size = new System.Drawing.Size(188, 86);
            this.btnorder.TabIndex = 18;
            this.btnorder.Text = "Add";
            this.btnorder.UseVisualStyleBackColor = false;
            this.btnorder.Click += new System.EventHandler(this.btnorder_Click);
            this.btnorder.MouseEnter += new System.EventHandler(this.btnorder_MouseEnter);
            this.btnorder.MouseLeave += new System.EventHandler(this.btnorder_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(469, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 58);
            this.label3.TabIndex = 17;
            this.label3.Text = "$";
            // 
            // txtpph
            // 
            this.txtpph.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.txtpph.Location = new System.Drawing.Point(321, 245);
            this.txtpph.Mask = "00.00";
            this.txtpph.Name = "txtpph";
            this.txtpph.Size = new System.Drawing.Size(142, 64);
            this.txtpph.TabIndex = 16;
            // 
            // txtconsole
            // 
            this.txtconsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.txtconsole.Location = new System.Drawing.Point(321, 126);
            this.txtconsole.Name = "txtconsole";
            this.txtconsole.Size = new System.Drawing.Size(364, 64);
            this.txtconsole.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(162, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 58);
            this.label2.TabIndex = 14;
            this.label2.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(142, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 58);
            this.label1.TabIndex = 13;
            this.label1.Text = "Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(169, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(436, 58);
            this.label5.TabIndex = 12;
            this.label5.Text = "Adding New Order";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnorder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtpph);
            this.Controls.Add(this.txtconsole);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnorder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtpph;
        private System.Windows.Forms.TextBox txtconsole;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}