using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenWallet
{
    public partial class Wallet : Form
    {
        public Wallet()
        {
            InitializeComponent();
            InitializeAppInfos();
            InitializeUserInfos();
            TokenWallet.Properties.Settings.Default.PropertyChanged += Default_PropertyChanged;

            //CheckBalance().GetAwaiter().GetResult();
        }

        private void Default_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "AccountInfos":
                    this.cboUser.DataBindings.Clear();
                    this.txtUserAccount.DataBindings.Clear();
                    this.txtcfgUserAddress.DataBindings.Clear();
                    this.txtcfgUserName.DataBindings.Clear();
                    InitializeUserInfos();

                    break;

                case "TokenInfos":
                    this.cboToken.DataBindings.Clear();
                    this.txtTokenAddress.DataBindings.Clear();
                    this.txtcfgTokenAddress.DataBindings.Clear();
                    this.txtcfgTokenName.DataBindings.Clear();
                    InitializeAppInfos();
                    break;

                default:
                    break;
            }
        }

        private async Task CheckBalance()
        {
            if (this.cboToken.SelectedItem != null && this.cboUser.SelectedItem != null)
            {
                var apiSvc = new APIService(TokenWallet.Properties.Settings.Default.APILocation);
                var tokenInfo = (TokenInfo)this.cboToken.SelectedItem;
                var userInfo = (AccountInfo)this.cboUser.SelectedItem;

               var balance =
                    await  apiSvc.GetBalance(tokenInfo.TokenContractAddress, userInfo.AccountPubAddress);

                this.txtBalance.Text = balance;

                var tokeninfo =
                    await apiSvc.GetTokenInfo(tokenInfo.TokenContractAddress);

                this.lblSymbol.Text = tokeninfo.Symbol;
            }
        }

        private void InitializeUserInfos()
        {
            this.cboUser.DataSource = InitDataSource<AccountInfo>("AccountInfos");
            this.cboUser.DisplayMember = "AccountName";

            this.txtUserAccount.DataBindings.Add("Text", this.cboUser.DataSource, "AccountPubAddress");
            this.txtcfgUserAddress.DataBindings.Add("Text", this.cboUser.DataSource, "AccountPubAddress");
            this.txtcfgUserName.DataBindings.Add("Text", this.cboUser.DataSource, "AccountName");
        }


        private void InitializeAppInfos()
        {
            this.cboToken.DataSource = InitDataSource<TokenInfo>("TokenInfos");
            this.cboToken.DisplayMember = "TokenName";

            this.txtTokenAddress.DataBindings.Add("Text", this.cboToken.DataSource, "TokenContractAddress");
            this.txtcfgTokenAddress.DataBindings.Add("Text", this.cboToken.DataSource, "TokenContractAddress");
            this.txtcfgTokenName.DataBindings.Add("Text", this.cboToken.DataSource, "TokenName");
        }

        private List<T> InitDataSource<T>(string EntityName)
        {
            var settings = TokenWallet.Properties.Settings.Default[EntityName].ToString();
            if (!string.IsNullOrEmpty(settings))
            {
                return JsonConvert.DeserializeObject<List<T>>(settings);
            }
            else
            {
                var lstObjs = new List<T>();
                TokenWallet.Properties.Settings.Default[EntityName] = JsonConvert.SerializeObject(lstObjs);
                TokenWallet.Properties.Settings.Default.Save();
                return lstObjs;
            }
        }

        private void btnNewTokenInfo_Click(object sender, EventArgs e)
        {
            ClearTokenConfigSection();
        }

        private void ClearTokenConfigSection()
        {
            this.txtcfgTokenAddress.DataBindings.Clear();
            this.txtcfgTokenAddress.Clear();
            this.txtcfgTokenName.DataBindings.Clear();
            this.txtcfgTokenName.Clear();
        }

        private void ClearUserConfigSection()
        {
            this.txtcfgUserAddress.DataBindings.Clear();
            this.txtcfgUserAddress.Clear();
            this.txtcfgUserName.DataBindings.Clear();
            this.txtcfgUserName.Clear();
        }

        private void btnUpdaeTokenInfo_Click(object sender, EventArgs e)
        {
            var tokenInfo = new TokenInfo()
            {
                TokenName = this.txtcfgTokenName.Text,
                TokenContractAddress = this.txtcfgTokenAddress.Text
            };
            var tokenInfos = ((List<TokenInfo>)this.cboToken.DataSource);
            tokenInfos.Add(tokenInfo);
            TokenWallet.Properties.Settings.Default["TokenInfos"] = JsonConvert.SerializeObject(tokenInfos);
            TokenWallet.Properties.Settings.Default.Save();
        }

        private void btncfgRemoveToken_Click(object sender, EventArgs e)
        {
            var tokenInfos = ((List<TokenInfo>)this.cboToken.DataSource);
            tokenInfos.Remove((TokenInfo)this.cboToken.SelectedItem);
            ClearTokenConfigSection();

            TokenWallet.Properties.Settings.Default["TokenInfos"] = JsonConvert.SerializeObject(tokenInfos);
            TokenWallet.Properties.Settings.Default.Save();
        }

        private void brncfgAddNewUser_Click(object sender, EventArgs e)
        {
            ClearUserConfigSection();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var userInfo = new AccountInfo()
            {
                AccountName = this.txtcfgUserName.Text,
                AccountPubAddress = this.txtcfgUserAddress.Text
            };
            var accountInfos = ((List<AccountInfo>)this.cboUser.DataSource);
            accountInfos.Add(userInfo);
            ClearUserConfigSection();

            TokenWallet.Properties.Settings.Default["AccountInfos"] = JsonConvert.SerializeObject(accountInfos);
            TokenWallet.Properties.Settings.Default.Save();
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            var accountInfos = ((List<AccountInfo>)this.cboUser.DataSource);
            accountInfos.Remove((AccountInfo)this.cboUser.SelectedItem);
            ClearUserConfigSection();

            TokenWallet.Properties.Settings.Default["AccountInfos"] = JsonConvert.SerializeObject(accountInfos);
            TokenWallet.Properties.Settings.Default.Save();
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tblWallet.SelectedIndex == 0)
            {
               await CheckBalance();
            }
        }

        private async void CboToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CheckBalance();
            this.Text = $"{((TokenInfo)this.cboToken.SelectedItem).TokenName} Token Wallet - {this.txtTokenAddress.Text}";
        }

        private async void CboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            await CheckBalance();
            this.Text = $"{((TokenInfo)this.cboToken.SelectedItem).TokenName} Token Wallet - {this.txtTokenAddress.Text}";
        }

        private void ChkMonitor_CheckedChanged(object sender, EventArgs e)
        {
            this.timerAccount.Enabled = this.chkMonitor.Checked;
        }

        private async void TimerAccount_Tick(object sender, EventArgs e)
        {
            await CheckBalance();
            Debug.Print("Timer Fired....");
        }

        private async void BtnTransfer_Click(object sender, EventArgs e)
        {
            var apiSvc = new APIService(TokenWallet.Properties.Settings.Default.APILocation);
            var tokenInfo = (TokenInfo)this.cboToken.SelectedItem;
            var userInfo = (AccountInfo)this.cboUser.SelectedItem;

            await apiSvc.Transfer(tokenInfo.TokenContractAddress, userInfo.AccountPubAddress, txtRecipient.Text, Double.Parse(this.txtTokenAmount.Text));
        }

        private async void BtnApporve_Click(object sender, EventArgs e)
        {
            var apiSvc = new APIService(TokenWallet.Properties.Settings.Default.APILocation);
            var tokenInfo = (TokenInfo)this.cboToken.SelectedItem;
            var userInfo = (AccountInfo)this.cboUser.SelectedItem;

            var result = await apiSvc.Approve(tokenInfo.TokenContractAddress, userInfo.AccountPubAddress, txtSpenderAddress.Text, double.Parse(this.txtApprovedAmount.Text));

            MessageBox.Show($"Approved : \n Approver : {userInfo.AccountName}\n Spender : {txtSpenderAddress.Text}\n Approved Amount : {txtApprovedAmount.Text}");
        }
    }
    
}
