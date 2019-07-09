using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MileageTokenService
{
    public partial class MilageService : Form
    {
        public MilageService()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var companyInfo = MileageTokenService.Properties.Settings.Default.CompanyInfo;
            var serializedObj = JsonConvert.DeserializeObject(companyInfo);

            this.comboBox1.DataSource = serializedObj;
            this.comboBox1.DisplayMember = "Name";

            this.txtTokenContractAddress.DataBindings.Add("Text", serializedObj, "TokenAddress");
            this.txtMileageContractAddress.DataBindings.Add("Text", serializedObj, "ContractAddress");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            JObject companyInfo = ((JObject)this.comboBox1.SelectedItem);
            string CompanyName = companyInfo.SelectToken("Name").ToString();
            string CompanyAddress = companyInfo.SelectToken("Address").ToString();
            this.Text = $"{CompanyName} Mileage token Service - {CompanyAddress}";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtTokenContractAddress.Text))
            {
                JObject companyInfo = ((JObject)this.comboBox1.SelectedItem);
                string CompanyName = companyInfo.SelectToken("Name").ToString();
                string CompanyAddress = companyInfo.SelectToken("Address").ToString();
                string CompanyTokenAddress = companyInfo.SelectToken("TokenAddress").ToString();

                //deploy token with information
                APIService svc = new APIService(MileageTokenService.Properties.Settings.Default.APILocation);

                this.txtDeployedMileageTokenContractAddress.Text = 
                    await svc.DeployRewardMileageContract(CompanyTokenAddress, CompanyAddress, CompanyName);
            }
        }

        private async void BtnSendMileage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtRecipientAddress.Text) &&
                !string.IsNullOrEmpty(this.txtTokenAmount.Text))
            {
                APIService svc = new APIService(MileageTokenService.Properties.Settings.Default.APILocation);

                JObject companyInfo = ((JObject)this.comboBox1.SelectedItem);
                string companyAddress = companyInfo.SelectToken("Address").ToString();

                
                await svc.SendRewardToken(this.txtMileageContractAddress.Text, 
                    companyAddress,
                    this.txtRecipientAddress.Text, Double.Parse(this.txtTokenAmount.Text));
            }
        }
    }
}
