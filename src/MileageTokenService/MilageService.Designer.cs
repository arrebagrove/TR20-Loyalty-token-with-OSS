namespace MileageTokenService
{
    partial class MilageService
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSendMileage = new System.Windows.Forms.Button();
            this.txtTokenAmount = new System.Windows.Forms.TextBox();
            this.txtMileageContractAddress = new System.Windows.Forms.TextBox();
            this.txtRecipientAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeployedMileageTokenContractAddress = new System.Windows.Forms.TextBox();
            this.txtTokenContractAddress = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(92, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(368, 29);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(521, 378);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(515, 50);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 59);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 316);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSendMileage);
            this.tabPage1.Controls.Add(this.txtTokenAmount);
            this.tabPage1.Controls.Add(this.txtMileageContractAddress);
            this.tabPage1.Controls.Add(this.txtRecipientAddress);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(507, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Send Mileage to Users";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSendMileage
            // 
            this.btnSendMileage.Location = new System.Drawing.Point(45, 228);
            this.btnSendMileage.Name = "btnSendMileage";
            this.btnSendMileage.Size = new System.Drawing.Size(155, 36);
            this.btnSendMileage.TabIndex = 2;
            this.btnSendMileage.Text = "Send Mileage";
            this.btnSendMileage.UseVisualStyleBackColor = true;
            this.btnSendMileage.Click += new System.EventHandler(this.BtnSendMileage_Click);
            // 
            // txtTokenAmount
            // 
            this.txtTokenAmount.Location = new System.Drawing.Point(45, 180);
            this.txtTokenAmount.Name = "txtTokenAmount";
            this.txtTokenAmount.Size = new System.Drawing.Size(413, 29);
            this.txtTokenAmount.TabIndex = 1;
            // 
            // txtMileageContractAddress
            // 
            this.txtMileageContractAddress.Location = new System.Drawing.Point(45, 42);
            this.txtMileageContractAddress.Name = "txtMileageContractAddress";
            this.txtMileageContractAddress.ReadOnly = true;
            this.txtMileageContractAddress.Size = new System.Drawing.Size(413, 29);
            this.txtMileageContractAddress.TabIndex = 1;
            this.txtMileageContractAddress.TabStop = false;
            // 
            // txtRecipientAddress
            // 
            this.txtRecipientAddress.Location = new System.Drawing.Point(45, 110);
            this.txtRecipientAddress.Name = "txtRecipientAddress";
            this.txtRecipientAddress.Size = new System.Drawing.Size(413, 29);
            this.txtRecipientAddress.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Token Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mileage Contract Token Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtDeployedMileageTokenContractAddress);
            this.tabPage2.Controls.Add(this.txtTokenContractAddress);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(507, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deploy Mileage Contract";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 21);
            this.label7.TabIndex = 3;
            this.label7.Text = "Deployed Token Address";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Token Contract Address";
            // 
            // txtDeployedMileageTokenContractAddress
            // 
            this.txtDeployedMileageTokenContractAddress.Location = new System.Drawing.Point(49, 212);
            this.txtDeployedMileageTokenContractAddress.Name = "txtDeployedMileageTokenContractAddress";
            this.txtDeployedMileageTokenContractAddress.Size = new System.Drawing.Size(407, 29);
            this.txtDeployedMileageTokenContractAddress.TabIndex = 2;
            // 
            // txtTokenContractAddress
            // 
            this.txtTokenContractAddress.Location = new System.Drawing.Point(49, 47);
            this.txtTokenContractAddress.Name = "txtTokenContractAddress";
            this.txtTokenContractAddress.Size = new System.Drawing.Size(407, 29);
            this.txtTokenContractAddress.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(407, 77);
            this.button1.TabIndex = 0;
            this.button1.Text = "Deploy Mileage Token";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MilageService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 378);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MilageService";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSendMileage;
        private System.Windows.Forms.TextBox txtTokenAmount;
        private System.Windows.Forms.TextBox txtRecipientAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTokenContractAddress;
        private System.Windows.Forms.TextBox txtMileageContractAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDeployedMileageTokenContractAddress;
    }
}

