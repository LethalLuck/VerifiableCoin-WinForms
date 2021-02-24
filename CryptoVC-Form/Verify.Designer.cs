
namespace CryptoVC_Form
{
    partial class Verify
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
            this.verifyBtn = new System.Windows.Forms.Button();
            this.txIDTxt = new System.Windows.Forms.TextBox();
            this.seedTxt = new System.Windows.Forms.TextBox();
            this.seedLbl = new System.Windows.Forms.Label();
            this.txIDLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rollLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.coinAmountTxt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // verifyBtn
            // 
            this.verifyBtn.Location = new System.Drawing.Point(12, 227);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(75, 23);
            this.verifyBtn.TabIndex = 0;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // txIDTxt
            // 
            this.txIDTxt.Location = new System.Drawing.Point(44, 38);
            this.txIDTxt.Name = "txIDTxt";
            this.txIDTxt.Size = new System.Drawing.Size(297, 20);
            this.txIDTxt.TabIndex = 1;
            // 
            // seedTxt
            // 
            this.seedTxt.Location = new System.Drawing.Point(44, 12);
            this.seedTxt.Name = "seedTxt";
            this.seedTxt.Size = new System.Drawing.Size(137, 20);
            this.seedTxt.TabIndex = 2;
            // 
            // seedLbl
            // 
            this.seedLbl.AutoSize = true;
            this.seedLbl.Location = new System.Drawing.Point(3, 15);
            this.seedLbl.Name = "seedLbl";
            this.seedLbl.Size = new System.Drawing.Size(35, 13);
            this.seedLbl.TabIndex = 3;
            this.seedLbl.Text = "Seed:";
            // 
            // txIDLbl
            // 
            this.txIDLbl.AutoSize = true;
            this.txIDLbl.Location = new System.Drawing.Point(3, 41);
            this.txIDLbl.Name = "txIDLbl";
            this.txIDLbl.Size = new System.Drawing.Size(25, 13);
            this.txIDLbl.TabIndex = 4;
            this.txIDLbl.Text = "Api:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 64);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 186);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Beacon Info:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rolled:";
            // 
            // rollLbl
            // 
            this.rollLbl.AutoSize = true;
            this.rollLbl.Location = new System.Drawing.Point(41, 97);
            this.rollLbl.Name = "rollLbl";
            this.rollLbl.Size = new System.Drawing.Size(13, 13);
            this.rollLbl.TabIndex = 10;
            this.rollLbl.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(187, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Coin Amount:";
            // 
            // coinAmountTxt
            // 
            this.coinAmountTxt.Location = new System.Drawing.Point(263, 12);
            this.coinAmountTxt.Name = "coinAmountTxt";
            this.coinAmountTxt.Size = new System.Drawing.Size(78, 20);
            this.coinAmountTxt.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(4, 113);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 108);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "The seed is \"generated\" by grabbing the last 7 DIGITS in the \"localRandomValue\" s" +
    "tring";
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.coinAmountTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rollLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txIDLbl);
            this.Controls.Add(this.seedLbl);
            this.Controls.Add(this.seedTxt);
            this.Controls.Add(this.txIDTxt);
            this.Controls.Add(this.verifyBtn);
            this.Name = "Verify";
            this.Text = "Verify | api.blockcypher.com";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button verifyBtn;
        private System.Windows.Forms.TextBox txIDTxt;
        private System.Windows.Forms.TextBox seedTxt;
        private System.Windows.Forms.Label seedLbl;
        private System.Windows.Forms.Label txIDLbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label rollLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coinAmountTxt;
        private System.Windows.Forms.TextBox textBox2;
    }
}