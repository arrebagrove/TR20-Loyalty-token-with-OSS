using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeToken
{
    public partial class ExchangeTokenService : Form
    {
        string sourceTokenBalance, targetSourceBalance;

        public ExchangeTokenService()
        {
            InitializeComponent();
            initDataSource();
        }

        private void initDataSource()
        {
            this.cboAccount.DataSource = initDataSource<AccountInfo>("UserInfos");
            this.cboAccount.DisplayMember = "AccountName";
            this.txtAccountAddress.DataBindings.Add("Text", this.cboAccount.DataSource, "AccountPubAddress");

            this.cboSourceToken.DataSource = initDataSource<TokenInfo>("TokenInfos"); ;
            this.cboSourceToken.DisplayMember = "TokenName";
            this.cboTargetToken.DataSource = initDataSource<TokenInfo>("TokenInfos"); ;
            this.cboTargetToken.DisplayMember = "TokenName";

        }

        private List<T> initDataSource<T>(string entityName)
        {
            var serializedListObj = ExchangeToken.Properties.Settings.Default[entityName] as string;
            if (string.IsNullOrEmpty(serializedListObj))
            {
                return new List<T>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<T>>(serializedListObj);
            }
        }

        private async void CboSourceToken_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0) return;

            if (cboSourceToken.Text.Contains("Air"))
            {
                this.txtExchangeRate.Text = "120";
            }
            else
            {
                this.txtExchangeRate.Text = "80";
            }

            if (((TokenInfo)cboSourceToken.SelectedItem).TokenName == ((TokenInfo)cboTargetToken.SelectedItem).TokenName)
            {
                this.txtExchangeRate.Text = "0";
            }

            previousValue_source = null;
            previousValue_target = null;

            await updateBalance();

        }


        private string previousValue_target = null;
        private Color previousColor_target;
        private string previousValue_source = null;
        private Color previousColor_source;

        private async Task updateBalance()
        {
            var userAccount = ((AccountInfo)this.cboAccount.SelectedItem).AccountPubAddress;
            var targetTokenAddress = ((TokenInfo)this.cboTargetToken.SelectedItem).TokenContractAddress;
            var sourceTokenAddress = ((TokenInfo)this.cboSourceToken.SelectedItem).TokenContractAddress;

            this.txtTargetTokenBalance.Text = await GetBalance(targetTokenAddress, userAccount);
            this.txtSourceTokenBalance.Text = await GetBalance(sourceTokenAddress, userAccount);

            if (previousValue_target == null)
            {
                previousValue_target = this.txtTargetTokenBalance.Text;
                return;
            }

            if (previousValue_target == this.txtTargetTokenBalance.Text)
            {
                this.txtTargetTokenBalance.BackColor = this.previousColor_target;

            }
            else
            {
                this.previousValue_target = this.txtTargetTokenBalance.Text;
                this.previousColor_target = this.txtTargetTokenBalance.BackColor;

                this.txtTargetTokenBalance.BackColor = Color.Yellow;
            }

            //
            if (previousValue_source == null)
            {
                previousValue_source = this.txtSourceTokenBalance.Text;
                return;
            }

            if (previousValue_source == this.txtSourceTokenBalance.Text)
            {
                this.txtSourceTokenBalance.BackColor = this.previousColor_source;

            }
            else
            {
                this.previousValue_source = this.txtSourceTokenBalance.Text;
                this.previousColor_source = this.txtSourceTokenBalance.BackColor;

                this.txtSourceTokenBalance.BackColor = Color.Yellow;
            }

        }

        private async Task<string> GetBalance(string tokenContractAddress, string account)
        {
            var apiSvc = new APIService(ExchangeToken.Properties.Settings.Default.APILocation);
            return await apiSvc.GetBalance(tokenContractAddress, account);
        }

        private async void CboAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count > 0)
                await updateBalance();
        }

        private async void BtnExchangeToken_Click(object sender, EventArgs e)
        {
            var userAccount = ((AccountInfo)this.cboAccount.SelectedItem).AccountPubAddress;
            var targetTokenAddress = ((TokenInfo)this.cboTargetToken.SelectedItem).TokenContractAddress;
            var sourceTokenAddress = ((TokenInfo)this.cboSourceToken.SelectedItem).TokenContractAddress;
            var applicationAccount = ExchangeToken.Properties.Settings.Default.ApplicationAddress;


            var apiSvc = new APIService(ExchangeToken.Properties.Settings.Default.APILocation);
            await apiSvc.ExchangeTokens(ExchangeToken.Properties.Settings.Default.ExchangeTokenContractAddress,
                applicationAccount, userAccount,
                sourceTokenAddress, targetTokenAddress,
                int.Parse(txtExchangeRate.Text), int.Parse(txtTokenAmount.Text));

            //update Balance
            await updateBalance();

            previousValue_source = null;
            previousValue_target = null;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await updateBalance();
        }
    }
}
