namespace TokenWallet
{
    partial class Wallet
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTokenAddress = new System.Windows.Forms.TextBox();
            this.cboToken = new System.Windows.Forms.ComboBox();
            this.lblTokenName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserAccount = new System.Windows.Forms.TextBox();
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tblWallet = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.txtTokenAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.chkMonitor = new System.Windows.Forms.CheckBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.lblSymbol = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnApporve = new System.Windows.Forms.Button();
            this.txtApprovedAmount = new System.Windows.Forms.TextBox();
            this.txtSpenderAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSpender = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.brncfgAddNewUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.txtcfgUserAddress = new System.Windows.Forms.TextBox();
            this.txtcfgUserName = new System.Windows.Forms.TextBox();
            this.lblcfgUserName = new System.Windows.Forms.Label();
            this.lblcfgUserAddress = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewTokenInfo = new System.Windows.Forms.Button();
            this.btncfgRemoveToken = new System.Windows.Forms.Button();
            this.btnUpdaeTokenInfo = new System.Windows.Forms.Button();
            this.txtcfgTokenAddress = new System.Windows.Forms.TextBox();
            this.txtcfgTokenName = new System.Windows.Forms.TextBox();
            this.lblcfgTokenNam = new System.Windows.Forms.Label();
            this.lblcfgTokenAddress = new System.Windows.Forms.Label();
            this.timerAccount = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tblWallet.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(771, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTokenAddress);
            this.panel1.Controls.Add(this.cboToken);
            this.panel1.Controls.Add(this.lblTokenName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 42);
            this.panel1.TabIndex = 0;
            // 
            // txtTokenAddress
            // 
            this.txtTokenAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTokenAddress.Location = new System.Drawing.Point(343, 7);
            this.txtTokenAddress.Name = "txtTokenAddress";
            this.txtTokenAddress.ReadOnly = true;
            this.txtTokenAddress.Size = new System.Drawing.Size(402, 29);
            this.txtTokenAddress.TabIndex = 2;
            this.txtTokenAddress.TabStop = false;
            // 
            // cboToken
            // 
            this.cboToken.FormattingEnabled = true;
            this.cboToken.Location = new System.Drawing.Point(118, 7);
            this.cboToken.Name = "cboToken";
            this.cboToken.Size = new System.Drawing.Size(219, 29);
            this.cboToken.TabIndex = 1;
            this.cboToken.SelectedIndexChanged += new System.EventHandler(this.CboToken_SelectedIndexChanged);
            // 
            // lblTokenName
            // 
            this.lblTokenName.AutoSize = true;
            this.lblTokenName.Location = new System.Drawing.Point(10, 10);
            this.lblTokenName.Name = "lblTokenName";
            this.lblTokenName.Size = new System.Drawing.Size(102, 21);
            this.lblTokenName.TabIndex = 0;
            this.lblTokenName.Text = "TokenName";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUserAccount);
            this.panel2.Controls.Add(this.cboUser);
            this.panel2.Controls.Add(this.lblUser);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 57);
            this.panel2.Margin = new System.Windows.Forms.Padding(5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1323, 42);
            this.panel2.TabIndex = 1;
            // 
            // txtUserAccount
            // 
            this.txtUserAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserAccount.Location = new System.Drawing.Point(343, 7);
            this.txtUserAccount.Name = "txtUserAccount";
            this.txtUserAccount.ReadOnly = true;
            this.txtUserAccount.Size = new System.Drawing.Size(402, 29);
            this.txtUserAccount.TabIndex = 2;
            this.txtUserAccount.TabStop = false;
            // 
            // cboUser
            // 
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(118, 7);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(219, 29);
            this.cboUser.TabIndex = 1;
            this.cboUser.SelectedIndexChanged += new System.EventHandler(this.CboUser_SelectedIndexChanged);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(10, 10);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(44, 21);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tblWallet);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(5, 109);
            this.panel3.Margin = new System.Windows.Forms.Padding(5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1323, 491);
            this.panel3.TabIndex = 2;
            // 
            // tblWallet
            // 
            this.tblWallet.Controls.Add(this.tabPage1);
            this.tblWallet.Controls.Add(this.tabPage3);
            this.tblWallet.Controls.Add(this.tabPage2);
            this.tblWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblWallet.Location = new System.Drawing.Point(0, 0);
            this.tblWallet.Name = "tblWallet";
            this.tblWallet.SelectedIndex = 0;
            this.tblWallet.Size = new System.Drawing.Size(1323, 491);
            this.tblWallet.TabIndex = 0;
            this.tblWallet.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.lblSymbol);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1315, 457);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Wallet (Balance)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnTransfer);
            this.groupBox4.Controls.Add(this.txtTokenAmount);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtRecipient);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(10, 130);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(731, 145);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transfer Token";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Location = new System.Drawing.Point(578, 76);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(112, 29);
            this.btnTransfer.TabIndex = 2;
            this.btnTransfer.Text = "Transfer";
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.BtnTransfer_Click);
            // 
            // txtTokenAmount
            // 
            this.txtTokenAmount.Location = new System.Drawing.Point(144, 76);
            this.txtTokenAmount.Name = "txtTokenAmount";
            this.txtTokenAmount.Size = new System.Drawing.Size(391, 29);
            this.txtTokenAmount.TabIndex = 1;
            this.txtTokenAmount.TabStop = false;
            this.txtTokenAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Amount";
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(144, 41);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRecipient.Size = new System.Drawing.Size(391, 29);
            this.txtRecipient.TabIndex = 1;
            this.txtRecipient.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipient";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBalance);
            this.groupBox3.Controls.Add(this.chkMonitor);
            this.groupBox3.Controls.Add(this.lblBalance);
            this.groupBox3.Location = new System.Drawing.Point(10, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(731, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Balance";
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(144, 41);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(229, 29);
            this.txtBalance.TabIndex = 1;
            this.txtBalance.TabStop = false;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkMonitor
            // 
            this.chkMonitor.AutoSize = true;
            this.chkMonitor.Location = new System.Drawing.Point(413, 45);
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.Size = new System.Drawing.Size(184, 25);
            this.chkMonitor.TabIndex = 3;
            this.chkMonitor.Text = "Monitor my account";
            this.chkMonitor.UseVisualStyleBackColor = true;
            this.chkMonitor.CheckedChanged += new System.EventHandler(this.ChkMonitor_CheckedChanged);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(32, 43);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(70, 21);
            this.lblBalance.TabIndex = 0;
            this.lblBalance.Text = "Balance";
            // 
            // lblSymbol
            // 
            this.lblSymbol.AutoSize = true;
            this.lblSymbol.Location = new System.Drawing.Point(341, 24);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(0, 21);
            this.lblSymbol.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnApporve);
            this.tabPage3.Controls.Add(this.txtApprovedAmount);
            this.tabPage3.Controls.Add(this.txtSpenderAddress);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.lblSpender);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1315, 457);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Approve";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnApporve
            // 
            this.btnApporve.Location = new System.Drawing.Point(435, 202);
            this.btnApporve.Name = "btnApporve";
            this.btnApporve.Size = new System.Drawing.Size(215, 41);
            this.btnApporve.TabIndex = 4;
            this.btnApporve.Text = "Approve Delegation";
            this.btnApporve.UseVisualStyleBackColor = true;
            this.btnApporve.Click += new System.EventHandler(this.BtnApporve_Click);
            // 
            // txtApprovedAmount
            // 
            this.txtApprovedAmount.Location = new System.Drawing.Point(259, 146);
            this.txtApprovedAmount.Name = "txtApprovedAmount";
            this.txtApprovedAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtApprovedAmount.Size = new System.Drawing.Size(391, 29);
            this.txtApprovedAmount.TabIndex = 2;
            this.txtApprovedAmount.TabStop = false;
            // 
            // txtSpenderAddress
            // 
            this.txtSpenderAddress.Location = new System.Drawing.Point(259, 57);
            this.txtSpenderAddress.Name = "txtSpenderAddress";
            this.txtSpenderAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSpenderAddress.Size = new System.Drawing.Size(391, 29);
            this.txtSpenderAddress.TabIndex = 3;
            this.txtSpenderAddress.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Token Amount";
            // 
            // lblSpender
            // 
            this.lblSpender.AutoSize = true;
            this.lblSpender.Location = new System.Drawing.Point(104, 60);
            this.lblSpender.Name = "lblSpender";
            this.lblSpender.Size = new System.Drawing.Size(137, 21);
            this.lblSpender.TabIndex = 0;
            this.lblSpender.Text = "Spender Address";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1315, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.brncfgAddNewUser);
            this.groupBox2.Controls.Add(this.btnRemoveUser);
            this.groupBox2.Controls.Add(this.btnUpdateUser);
            this.groupBox2.Controls.Add(this.txtcfgUserAddress);
            this.groupBox2.Controls.Add(this.txtcfgUserName);
            this.groupBox2.Controls.Add(this.lblcfgUserName);
            this.groupBox2.Controls.Add(this.lblcfgUserAddress);
            this.groupBox2.Location = new System.Drawing.Point(28, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(713, 138);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "UserInfo";
            // 
            // brncfgAddNewUser
            // 
            this.brncfgAddNewUser.Location = new System.Drawing.Point(576, 22);
            this.brncfgAddNewUser.Name = "brncfgAddNewUser";
            this.brncfgAddNewUser.Size = new System.Drawing.Size(111, 29);
            this.brncfgAddNewUser.TabIndex = 2;
            this.brncfgAddNewUser.Text = "New";
            this.brncfgAddNewUser.UseVisualStyleBackColor = true;
            this.brncfgAddNewUser.Click += new System.EventHandler(this.brncfgAddNewUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.Location = new System.Drawing.Point(576, 94);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(111, 31);
            this.btnRemoveUser.TabIndex = 2;
            this.btnRemoveUser.Text = "Remove";
            this.btnRemoveUser.UseVisualStyleBackColor = true;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(576, 57);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(111, 31);
            this.btnUpdateUser.TabIndex = 2;
            this.btnUpdateUser.Text = "Update";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // txtcfgUserAddress
            // 
            this.txtcfgUserAddress.Location = new System.Drawing.Point(165, 85);
            this.txtcfgUserAddress.Name = "txtcfgUserAddress";
            this.txtcfgUserAddress.Size = new System.Drawing.Size(391, 29);
            this.txtcfgUserAddress.TabIndex = 1;
            // 
            // txtcfgUserName
            // 
            this.txtcfgUserName.Location = new System.Drawing.Point(165, 33);
            this.txtcfgUserName.Name = "txtcfgUserName";
            this.txtcfgUserName.Size = new System.Drawing.Size(312, 29);
            this.txtcfgUserName.TabIndex = 1;
            // 
            // lblcfgUserName
            // 
            this.lblcfgUserName.AutoSize = true;
            this.lblcfgUserName.Location = new System.Drawing.Point(26, 36);
            this.lblcfgUserName.Name = "lblcfgUserName";
            this.lblcfgUserName.Size = new System.Drawing.Size(90, 21);
            this.lblcfgUserName.TabIndex = 0;
            this.lblcfgUserName.Text = "UserName";
            // 
            // lblcfgUserAddress
            // 
            this.lblcfgUserAddress.AutoSize = true;
            this.lblcfgUserAddress.Location = new System.Drawing.Point(26, 88);
            this.lblcfgUserAddress.Name = "lblcfgUserAddress";
            this.lblcfgUserAddress.Size = new System.Drawing.Size(134, 21);
            this.lblcfgUserAddress.TabIndex = 0;
            this.lblcfgUserAddress.Text = "UserPubAddress";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewTokenInfo);
            this.groupBox1.Controls.Add(this.btncfgRemoveToken);
            this.groupBox1.Controls.Add(this.btnUpdaeTokenInfo);
            this.groupBox1.Controls.Add(this.txtcfgTokenAddress);
            this.groupBox1.Controls.Add(this.txtcfgTokenName);
            this.groupBox1.Controls.Add(this.lblcfgTokenNam);
            this.groupBox1.Controls.Add(this.lblcfgTokenAddress);
            this.groupBox1.Location = new System.Drawing.Point(28, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TokenInfo";
            // 
            // btnNewTokenInfo
            // 
            this.btnNewTokenInfo.Location = new System.Drawing.Point(576, 22);
            this.btnNewTokenInfo.Name = "btnNewTokenInfo";
            this.btnNewTokenInfo.Size = new System.Drawing.Size(111, 29);
            this.btnNewTokenInfo.TabIndex = 2;
            this.btnNewTokenInfo.Text = "New";
            this.btnNewTokenInfo.UseVisualStyleBackColor = true;
            this.btnNewTokenInfo.Click += new System.EventHandler(this.btnNewTokenInfo_Click);
            // 
            // btncfgRemoveToken
            // 
            this.btncfgRemoveToken.Location = new System.Drawing.Point(576, 94);
            this.btncfgRemoveToken.Name = "btncfgRemoveToken";
            this.btncfgRemoveToken.Size = new System.Drawing.Size(111, 31);
            this.btncfgRemoveToken.TabIndex = 2;
            this.btncfgRemoveToken.Text = "Remove";
            this.btncfgRemoveToken.UseVisualStyleBackColor = true;
            this.btncfgRemoveToken.Click += new System.EventHandler(this.btncfgRemoveToken_Click);
            // 
            // btnUpdaeTokenInfo
            // 
            this.btnUpdaeTokenInfo.Location = new System.Drawing.Point(576, 57);
            this.btnUpdaeTokenInfo.Name = "btnUpdaeTokenInfo";
            this.btnUpdaeTokenInfo.Size = new System.Drawing.Size(111, 31);
            this.btnUpdaeTokenInfo.TabIndex = 2;
            this.btnUpdaeTokenInfo.Text = "Update";
            this.btnUpdaeTokenInfo.UseVisualStyleBackColor = true;
            this.btnUpdaeTokenInfo.Click += new System.EventHandler(this.btnUpdaeTokenInfo_Click);
            // 
            // txtcfgTokenAddress
            // 
            this.txtcfgTokenAddress.Location = new System.Drawing.Point(165, 88);
            this.txtcfgTokenAddress.Name = "txtcfgTokenAddress";
            this.txtcfgTokenAddress.Size = new System.Drawing.Size(391, 29);
            this.txtcfgTokenAddress.TabIndex = 1;
            // 
            // txtcfgTokenName
            // 
            this.txtcfgTokenName.Location = new System.Drawing.Point(165, 36);
            this.txtcfgTokenName.Name = "txtcfgTokenName";
            this.txtcfgTokenName.Size = new System.Drawing.Size(312, 29);
            this.txtcfgTokenName.TabIndex = 1;
            // 
            // lblcfgTokenNam
            // 
            this.lblcfgTokenNam.AutoSize = true;
            this.lblcfgTokenNam.Location = new System.Drawing.Point(26, 39);
            this.lblcfgTokenNam.Name = "lblcfgTokenNam";
            this.lblcfgTokenNam.Size = new System.Drawing.Size(102, 21);
            this.lblcfgTokenNam.TabIndex = 0;
            this.lblcfgTokenNam.Text = "TokenName";
            // 
            // lblcfgTokenAddress
            // 
            this.lblcfgTokenAddress.AutoSize = true;
            this.lblcfgTokenAddress.Location = new System.Drawing.Point(26, 91);
            this.lblcfgTokenAddress.Name = "lblcfgTokenAddress";
            this.lblcfgTokenAddress.Size = new System.Drawing.Size(116, 21);
            this.lblcfgTokenAddress.TabIndex = 0;
            this.lblcfgTokenAddress.Text = "TokenAddress";
            // 
            // timerAccount
            // 
            this.timerAccount.Interval = 3000;
            this.timerAccount.Tick += new System.EventHandler(this.TimerAccount_Tick);
            // 
            // Wallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 437);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Wallet";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tblWallet.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTokenAddress;
        private System.Windows.Forms.Label lblTokenName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUserAccount;
        private System.Windows.Forms.ComboBox cboUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboToken;
        private System.Windows.Forms.TabControl tblWallet;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNewTokenInfo;
        private System.Windows.Forms.Button btnUpdaeTokenInfo;
        private System.Windows.Forms.TextBox txtcfgTokenAddress;
        private System.Windows.Forms.TextBox txtcfgTokenName;
        private System.Windows.Forms.Label lblcfgTokenNam;
        private System.Windows.Forms.Label lblcfgTokenAddress;
        private System.Windows.Forms.Button btncfgRemoveToken;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button brncfgAddNewUser;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.TextBox txtcfgUserAddress;
        private System.Windows.Forms.TextBox txtcfgUserName;
        private System.Windows.Forms.Label lblcfgUserName;
        private System.Windows.Forms.Label lblcfgUserAddress;
        private System.Windows.Forms.Label lblSymbol;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.CheckBox chkMonitor;
        private System.Windows.Forms.Timer timerAccount;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.TextBox txtTokenAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblSpender;
        private System.Windows.Forms.Button btnApporve;
        private System.Windows.Forms.TextBox txtApprovedAmount;
        private System.Windows.Forms.TextBox txtSpenderAddress;
        private System.Windows.Forms.Label label3;
    }
}

