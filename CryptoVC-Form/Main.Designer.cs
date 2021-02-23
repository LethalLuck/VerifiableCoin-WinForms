
namespace CryptoVC_Form
{
    partial class VCPumps
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
            this.components = new System.ComponentModel.Container();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateTimeCalander = new System.Windows.Forms.MonthCalendar();
            this.beginBtn = new System.Windows.Forms.Button();
            this.countdownTimer = new System.Windows.Forms.Timer(this.components);
            this.countdownTimerLbl = new System.Windows.Forms.Label();
            this.btcRadio = new System.Windows.Forms.RadioButton();
            this.base64Btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ethRadio = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.underOneRadio = new System.Windows.Forms.RadioButton();
            this.underTenRadio = new System.Windows.Forms.RadioButton();
            this.tenPlusRadio = new System.Windows.Forms.RadioButton();
            this.btcPriceLbl = new System.Windows.Forms.Label();
            this.ethPriceLbl = new System.Windows.Forms.Label();
            this.coinLbl = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.verifyBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.coinCountLbl = new System.Windows.Forms.Label();
            this.rollLbl = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(12, 418);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.ShowUpDown = true;
            this.dateTimePicker.Size = new System.Drawing.Size(227, 20);
            this.dateTimePicker.TabIndex = 0;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // dateTimeCalander
            // 
            this.dateTimeCalander.Location = new System.Drawing.Point(12, 244);
            this.dateTimeCalander.MaxSelectionCount = 1;
            this.dateTimeCalander.Name = "dateTimeCalander";
            this.dateTimeCalander.TabIndex = 1;
            this.dateTimeCalander.TrailingForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dateTimeCalander.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.dateTimeCalendar_DateSelected);
            // 
            // beginBtn
            // 
            this.beginBtn.Location = new System.Drawing.Point(658, 404);
            this.beginBtn.Name = "beginBtn";
            this.beginBtn.Size = new System.Drawing.Size(130, 36);
            this.beginBtn.TabIndex = 3;
            this.beginBtn.Text = "Begin";
            this.beginBtn.UseVisualStyleBackColor = true;
            this.beginBtn.Click += new System.EventHandler(this.beginBtn_Click);
            // 
            // countdownTimer
            // 
            this.countdownTimer.Interval = 250;
            this.countdownTimer.Tick += new System.EventHandler(this.countdownTimer_Tick);
            // 
            // countdownTimerLbl
            // 
            this.countdownTimerLbl.AutoSize = true;
            this.countdownTimerLbl.Location = new System.Drawing.Point(655, 388);
            this.countdownTimerLbl.Name = "countdownTimerLbl";
            this.countdownTimerLbl.Size = new System.Drawing.Size(109, 13);
            this.countdownTimerLbl.TabIndex = 4;
            this.countdownTimerLbl.Text = "Countdown: 00:00:00";
            // 
            // btcRadio
            // 
            this.btcRadio.AutoSize = true;
            this.btcRadio.Checked = true;
            this.btcRadio.Location = new System.Drawing.Point(6, 19);
            this.btcRadio.Name = "btcRadio";
            this.btcRadio.Size = new System.Drawing.Size(46, 17);
            this.btcRadio.TabIndex = 6;
            this.btcRadio.TabStop = true;
            this.btcRadio.Text = "BTC";
            this.btcRadio.UseVisualStyleBackColor = true;
            // 
            // base64Btn
            // 
            this.base64Btn.Location = new System.Drawing.Point(577, 417);
            this.base64Btn.Name = "base64Btn";
            this.base64Btn.Size = new System.Drawing.Size(75, 23);
            this.base64Btn.TabIndex = 7;
            this.base64Btn.Text = "Base64";
            this.base64Btn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ethRadio);
            this.groupBox1.Controls.Add(this.btcRadio);
            this.groupBox1.Location = new System.Drawing.Point(251, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 64);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crypto type";
            // 
            // ethRadio
            // 
            this.ethRadio.AutoSize = true;
            this.ethRadio.Location = new System.Drawing.Point(6, 42);
            this.ethRadio.Name = "ethRadio";
            this.ethRadio.Size = new System.Drawing.Size(47, 17);
            this.ethRadio.TabIndex = 7;
            this.ethRadio.Text = "ETH";
            this.ethRadio.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(458, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(330, 249);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.underOneRadio);
            this.groupBox2.Controls.Add(this.underTenRadio);
            this.groupBox2.Controls.Add(this.tenPlusRadio);
            this.groupBox2.Location = new System.Drawing.Point(251, 314);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 92);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price limit";
            // 
            // underOneRadio
            // 
            this.underOneRadio.AutoSize = true;
            this.underOneRadio.Checked = true;
            this.underOneRadio.Location = new System.Drawing.Point(6, 65);
            this.underOneRadio.Name = "underOneRadio";
            this.underOneRadio.Size = new System.Drawing.Size(86, 17);
            this.underOneRadio.TabIndex = 10;
            this.underOneRadio.TabStop = true;
            this.underOneRadio.Text = "Less than $1";
            this.underOneRadio.UseVisualStyleBackColor = true;
            // 
            // underTenRadio
            // 
            this.underTenRadio.AutoSize = true;
            this.underTenRadio.Location = new System.Drawing.Point(6, 42);
            this.underTenRadio.Name = "underTenRadio";
            this.underTenRadio.Size = new System.Drawing.Size(140, 17);
            this.underTenRadio.TabIndex = 9;
            this.underTenRadio.TabStop = true;
            this.underTenRadio.Text = "Less than $10 above $1";
            this.underTenRadio.UseVisualStyleBackColor = true;
            // 
            // tenPlusRadio
            // 
            this.tenPlusRadio.AutoSize = true;
            this.tenPlusRadio.Location = new System.Drawing.Point(6, 19);
            this.tenPlusRadio.Name = "tenPlusRadio";
            this.tenPlusRadio.Size = new System.Drawing.Size(97, 17);
            this.tenPlusRadio.TabIndex = 8;
            this.tenPlusRadio.TabStop = true;
            this.tenPlusRadio.Text = "$10 and above";
            this.tenPlusRadio.UseVisualStyleBackColor = true;
            // 
            // btcPriceLbl
            // 
            this.btcPriceLbl.AutoSize = true;
            this.btcPriceLbl.Location = new System.Drawing.Point(12, 9);
            this.btcPriceLbl.Name = "btcPriceLbl";
            this.btcPriceLbl.Size = new System.Drawing.Size(78, 13);
            this.btcPriceLbl.TabIndex = 11;
            this.btcPriceLbl.Text = "Bitcoin Price: 0";
            // 
            // ethPriceLbl
            // 
            this.ethPriceLbl.AutoSize = true;
            this.ethPriceLbl.Location = new System.Drawing.Point(12, 22);
            this.ethPriceLbl.Name = "ethPriceLbl";
            this.ethPriceLbl.Size = new System.Drawing.Size(87, 13);
            this.ethPriceLbl.TabIndex = 12;
            this.ethPriceLbl.Text = "Etherium Price: 0";
            // 
            // coinLbl
            // 
            this.coinLbl.AutoSize = true;
            this.coinLbl.Location = new System.Drawing.Point(455, 264);
            this.coinLbl.Name = "coinLbl";
            this.coinLbl.Size = new System.Drawing.Size(100, 13);
            this.coinLbl.TabIndex = 13;
            this.coinLbl.Text = "Selected Coin: XXX";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(577, 267);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(211, 118);
            this.textBox2.TabIndex = 14;
            // 
            // verifyBtn
            // 
            this.verifyBtn.Location = new System.Drawing.Point(577, 391);
            this.verifyBtn.Name = "verifyBtn";
            this.verifyBtn.Size = new System.Drawing.Size(75, 23);
            this.verifyBtn.TabIndex = 15;
            this.verifyBtn.Text = "Verify";
            this.verifyBtn.UseVisualStyleBackColor = true;
            this.verifyBtn.Click += new System.EventHandler(this.verifyBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(371, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Coin Count:";
            // 
            // coinCountLbl
            // 
            this.coinCountLbl.AutoSize = true;
            this.coinCountLbl.Location = new System.Drawing.Point(430, 15);
            this.coinCountLbl.Name = "coinCountLbl";
            this.coinCountLbl.Size = new System.Drawing.Size(13, 13);
            this.coinCountLbl.TabIndex = 17;
            this.coinCountLbl.Text = "0";
            // 
            // rollLbl
            // 
            this.rollLbl.AutoSize = true;
            this.rollLbl.Location = new System.Drawing.Point(374, 32);
            this.rollLbl.Name = "rollLbl";
            this.rollLbl.Size = new System.Drawing.Size(49, 13);
            this.rollLbl.TabIndex = 18;
            this.rollLbl.Text = "Rolled: 0";
            // 
            // VCPumps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rollLbl);
            this.Controls.Add(this.coinCountLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.verifyBtn);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.coinLbl);
            this.Controls.Add(this.ethPriceLbl);
            this.Controls.Add(this.btcPriceLbl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.base64Btn);
            this.Controls.Add(this.countdownTimerLbl);
            this.Controls.Add(this.beginBtn);
            this.Controls.Add(this.dateTimeCalander);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "VCPumps";
            this.Text = "Verifiable Coin Pumps";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.MonthCalendar dateTimeCalander;
        private System.Windows.Forms.Button beginBtn;
        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Label countdownTimerLbl;
        private System.Windows.Forms.RadioButton btcRadio;
        private System.Windows.Forms.Button base64Btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ethRadio;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton underOneRadio;
        private System.Windows.Forms.RadioButton underTenRadio;
        private System.Windows.Forms.RadioButton tenPlusRadio;
        private System.Windows.Forms.Label btcPriceLbl;
        private System.Windows.Forms.Label ethPriceLbl;
        private System.Windows.Forms.Label coinLbl;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button verifyBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label coinCountLbl;
        private System.Windows.Forms.Label rollLbl;
    }
}

