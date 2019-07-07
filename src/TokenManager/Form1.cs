using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TR20.Loyalty.API;
namespace TokenManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "ERC20 Token Manager";
        }



        private async void btnCreateToken_Click(object sender, EventArgs e)
        {
            string apiLocation = TokenManager.Properties.Settings.Default.APILocation;
            APIService svc = new APIService(apiLocation);

            var tokenInfo = await svc.CreateTokenAsync(double.Parse(txtAmount.Text), txtTokenName.Text, int.Parse(txtDecimal.Text), txtSymbol.Text);
            txtTokenAddress.Text = tokenInfo.ContractAddress;

            string serializedString = TokenManager.Properties.Settings.Default["TokenInfos"] as string;

            List<TokenInfo> tokenInfos = null;

            if (!string.IsNullOrEmpty(serializedString))
            {
                tokenInfos = JsonConvert.DeserializeObject<List<TokenInfo>>(serializedString);
            }
            else
            {
                tokenInfos = new List<TokenInfo>();
            }
           
            tokenInfos.Add(tokenInfo);


            //TokenManager.Properties.Settings.Default.
            TokenManager.Properties.Settings.Default["TokenInfos"] = JsonConvert.SerializeObject(tokenInfos);
            TokenManager.Properties.Settings.Default.Save();

        }

        private void TabSelected(object sender, EventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 1)
            {
                string serializedString = TokenManager.Properties.Settings.Default["TokenInfos"] as string;
                if (!string.IsNullOrEmpty(serializedString))
                {
                    var tokenInfos = JsonConvert.DeserializeObject<List<TokenInfo>>(serializedString);
                    
                    lstTokens.DataSource = tokenInfos;
                    lstTokens.DisplayMember = "Name";

                    this.txtDeployedTokenAddress.DataBindings.Clear();
                    this.txtTokenAmount.DataBindings.Clear();
                    this.txtTokenSymbol.DataBindings.Clear();
                    this.txtDeployedTokenAddress.DataBindings.Add("Text", tokenInfos, "ContractAddress", false, DataSourceUpdateMode.Never);
                    this.txtTokenAmount.DataBindings.Add("Text", tokenInfos, "TotalSupplied", false, DataSourceUpdateMode.Never);
                    this.txtTokenSymbol.DataBindings.Add("Text", tokenInfos, "Symbol", false, DataSourceUpdateMode.Never);

                }

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
