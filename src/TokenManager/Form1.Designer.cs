namespace TokenManager
{
    partial class Form1
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
            this.tbl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCreateToken = new System.Windows.Forms.Button();
            this.txtTokenAddress = new System.Windows.Forms.TextBox();
            this.txtDecimal = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.txtTokenName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTokenSymbol = new System.Windows.Forms.TextBox();
            this.txtTokenAmount = new System.Windows.Forms.TextBox();
            this.txtDeployedTokenAddress = new System.Windows.Forms.TextBox();
            this.tbl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl1
            // 
            this.tbl1.Controls.Add(this.tabPage1);
            this.tbl1.Controls.Add(this.tabPage2);
            this.tbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbl1.Location = new System.Drawing.Point(0, 0);
            this.tbl1.Name = "tbl1";
            this.tbl1.SelectedIndex = 0;
            this.tbl1.Size = new System.Drawing.Size(605, 492);
            this.tbl1.TabIndex = 0;
            this.tbl1.SelectedIndexChanged += new System.EventHandler(this.TabSelected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCreateToken);
            this.tabPage1.Controls.Add(this.txtTokenAddress);
            this.tabPage1.Controls.Add(this.txtDecimal);
            this.tabPage1.Controls.Add(this.txtAmount);
            this.tabPage1.Controls.Add(this.txtSymbol);
            this.tabPage1.Controls.Add(this.txtTokenName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(597, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create Token";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCreateToken
            // 
            this.btnCreateToken.Location = new System.Drawing.Point(358, 298);
            this.btnCreateToken.Name = "btnCreateToken";
            this.btnCreateToken.Size = new System.Drawing.Size(170, 36);
            this.btnCreateToken.TabIndex = 5;
            this.btnCreateToken.Text = "Create Token";
            this.btnCreateToken.UseVisualStyleBackColor = true;
            this.btnCreateToken.Click += new System.EventHandler(this.btnCreateToken_Click);
            // 
            // txtTokenAddress
            // 
            this.txtTokenAddress.AcceptsTab = true;
            this.txtTokenAddress.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenAddress.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtTokenAddress.Location = new System.Drawing.Point(49, 375);
            this.txtTokenAddress.Name = "txtTokenAddress";
            this.txtTokenAddress.ReadOnly = true;
            this.txtTokenAddress.Size = new System.Drawing.Size(479, 33);
            this.txtTokenAddress.TabIndex = 0;
            this.txtTokenAddress.TabStop = false;
            // 
            // txtDecimal
            // 
            this.txtDecimal.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecimal.Location = new System.Drawing.Point(181, 242);
            this.txtDecimal.Name = "txtDecimal";
            this.txtDecimal.Size = new System.Drawing.Size(347, 33);
            this.txtDecimal.TabIndex = 4;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(181, 173);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(347, 33);
            this.txtAmount.TabIndex = 3;
            // 
            // txtSymbol
            // 
            this.txtSymbol.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.Location = new System.Drawing.Point(181, 107);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(347, 33);
            this.txtSymbol.TabIndex = 2;
            // 
            // txtTokenName
            // 
            this.txtTokenName.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTokenName.Location = new System.Drawing.Point(181, 47);
            this.txtTokenName.Name = "txtTokenName";
            this.txtTokenName.Size = new System.Drawing.Size(347, 33);
            this.txtTokenName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Created Token Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Token Decimal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Token Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Token Symbol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Token Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtDeployedTokenAddress);
            this.tabPage2.Controls.Add(this.txtTokenAmount);
            this.tabPage2.Controls.Add(this.txtTokenSymbol);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lstTokens);
            this.tabPage2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(597, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Token Infos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstTokens
            // 
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.ItemHeight = 25;
            this.lstTokens.Location = new System.Drawing.Point(18, 55);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(267, 379);
            this.lstTokens.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Deployed Tokens";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Token Symbol";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Token Amount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(305, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 25);
            this.label10.TabIndex = 1;
            this.label10.Text = "Deployed Address";
            // 
            // txtTokenSymbol
            // 
            this.txtTokenSymbol.Location = new System.Drawing.Point(310, 86);
            this.txtTokenSymbol.Name = "txtTokenSymbol";
            this.txtTokenSymbol.ReadOnly = true;
            this.txtTokenSymbol.Size = new System.Drawing.Size(263, 33);
            this.txtTokenSymbol.TabIndex = 2;
            this.txtTokenSymbol.TabStop = false;
            // 
            // txtTokenAmount
            // 
            this.txtTokenAmount.Location = new System.Drawing.Point(310, 171);
            this.txtTokenAmount.Name = "txtTokenAmount";
            this.txtTokenAmount.ReadOnly = true;
            this.txtTokenAmount.Size = new System.Drawing.Size(263, 33);
            this.txtTokenAmount.TabIndex = 2;
            this.txtTokenAmount.TabStop = false;
            // 
            // txtDeployedTokenAddress
            // 
            this.txtDeployedTokenAddress.Location = new System.Drawing.Point(310, 264);
            this.txtDeployedTokenAddress.Multiline = true;
            this.txtDeployedTokenAddress.Name = "txtDeployedTokenAddress";
            this.txtDeployedTokenAddress.ReadOnly = true;
            this.txtDeployedTokenAddress.Size = new System.Drawing.Size(263, 79);
            this.txtDeployedTokenAddress.TabIndex = 2;
            this.txtDeployedTokenAddress.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 492);
            this.Controls.Add(this.tbl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tbl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.TextBox txtTokenName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreateToken;
        private System.Windows.Forms.TextBox txtTokenAddress;
        private System.Windows.Forms.TextBox txtDecimal;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.TextBox txtDeployedTokenAddress;
        private System.Windows.Forms.TextBox txtTokenAmount;
        private System.Windows.Forms.TextBox txtTokenSymbol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

