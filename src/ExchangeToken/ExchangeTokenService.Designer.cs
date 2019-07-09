namespace ExchangeToken
{
    partial class ExchangeTokenService
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTargetToken = new System.Windows.Forms.ComboBox();
            this.cboSourceToken = new System.Windows.Forms.ComboBox();
            this.txtExchangeRate = new System.Windows.Forms.TextBox();
            this.txtTokenAmount = new System.Windows.Forms.TextBox();
            this.txtTargetTokenBalance = new System.Windows.Forms.TextBox();
            this.txtSourceTokenBalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExchangeToken = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.txtAccountAddress = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Token";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Target Token";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Exchange rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 274);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Amount Token";
            // 
            // cboTargetToken
            // 
            this.cboTargetToken.FormattingEnabled = true;
            this.cboTargetToken.Location = new System.Drawing.Point(147, 146);
            this.cboTargetToken.Name = "cboTargetToken";
            this.cboTargetToken.Size = new System.Drawing.Size(178, 29);
            this.cboTargetToken.TabIndex = 1;
            this.cboTargetToken.SelectedIndexChanged += new System.EventHandler(this.CboSourceToken_SelectedIndexChanged);
            // 
            // cboSourceToken
            // 
            this.cboSourceToken.FormattingEnabled = true;
            this.cboSourceToken.Location = new System.Drawing.Point(147, 90);
            this.cboSourceToken.Name = "cboSourceToken";
            this.cboSourceToken.Size = new System.Drawing.Size(178, 29);
            this.cboSourceToken.TabIndex = 1;
            this.cboSourceToken.SelectedIndexChanged += new System.EventHandler(this.CboSourceToken_SelectedIndexChanged);
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(147, 208);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(178, 29);
            this.txtExchangeRate.TabIndex = 2;
            this.txtExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTokenAmount
            // 
            this.txtTokenAmount.Location = new System.Drawing.Point(147, 271);
            this.txtTokenAmount.Name = "txtTokenAmount";
            this.txtTokenAmount.Size = new System.Drawing.Size(178, 29);
            this.txtTokenAmount.TabIndex = 2;
            this.txtTokenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTargetTokenBalance
            // 
            this.txtTargetTokenBalance.Location = new System.Drawing.Point(342, 146);
            this.txtTargetTokenBalance.Name = "txtTargetTokenBalance";
            this.txtTargetTokenBalance.Size = new System.Drawing.Size(345, 29);
            this.txtTargetTokenBalance.TabIndex = 2;
            this.txtTargetTokenBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSourceTokenBalance
            // 
            this.txtSourceTokenBalance.Location = new System.Drawing.Point(342, 90);
            this.txtSourceTokenBalance.Name = "txtSourceTokenBalance";
            this.txtSourceTokenBalance.Size = new System.Drawing.Size(345, 29);
            this.txtSourceTokenBalance.TabIndex = 2;
            this.txtSourceTokenBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Your Balance";
            // 
            // btnExchangeToken
            // 
            this.btnExchangeToken.Location = new System.Drawing.Point(430, 193);
            this.btnExchangeToken.Name = "btnExchangeToken";
            this.btnExchangeToken.Size = new System.Drawing.Size(175, 57);
            this.btnExchangeToken.TabIndex = 3;
            this.btnExchangeToken.Text = "Exchange Token!";
            this.btnExchangeToken.UseVisualStyleBackColor = true;
            this.btnExchangeToken.Click += new System.EventHandler(this.BtnExchangeToken_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Account";
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(147, 39);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(178, 29);
            this.cboAccount.TabIndex = 1;
            this.cboAccount.SelectedIndexChanged += new System.EventHandler(this.CboAccount_SelectedIndexChanged);
            // 
            // txtAccountAddress
            // 
            this.txtAccountAddress.Location = new System.Drawing.Point(342, 39);
            this.txtAccountAddress.Name = "txtAccountAddress";
            this.txtAccountAddress.Size = new System.Drawing.Size(345, 29);
            this.txtAccountAddress.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(338, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Account Address";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(342, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Your Balance";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh Balance";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ExchangeTokenService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExchangeToken);
            this.Controls.Add(this.txtTokenAmount);
            this.Controls.Add(this.txtAccountAddress);
            this.Controls.Add(this.txtSourceTokenBalance);
            this.Controls.Add(this.txtTargetTokenBalance);
            this.Controls.Add(this.txtExchangeRate);
            this.Controls.Add(this.cboAccount);
            this.Controls.Add(this.cboSourceToken);
            this.Controls.Add(this.cboTargetToken);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ExchangeTokenService";
            this.Text = "Token Exchanger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTargetToken;
        private System.Windows.Forms.ComboBox cboSourceToken;
        private System.Windows.Forms.TextBox txtExchangeRate;
        private System.Windows.Forms.TextBox txtTokenAmount;
        private System.Windows.Forms.TextBox txtTargetTokenBalance;
        private System.Windows.Forms.TextBox txtSourceTokenBalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExchangeToken;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.TextBox txtAccountAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}

