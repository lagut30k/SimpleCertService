using System;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Web;
using SimpleCertService.Bussiness.Helpers;
using SimpleCertService.Service;

namespace SimpleCertService
{
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
        }

        private void SimpleForm_Load(object sender, EventArgs e)
        {
            var host = new WebServiceHost(typeof(CertificateService), new Uri("http://localhost:8000/"));
            try
            {
                host.AddServiceEndpoint(typeof(ICertificateService), new WebHttpBinding(), "");
                host.Open();
            }
            catch (CommunicationException cex)
            {
                host.Abort();
                MessageBox.Show(cex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCertificateButton_Click(object sender, EventArgs e)
        {
            if (!X509Helper.ShowStoredCertificate())
            {
                MessageBox.Show("No certificate was viewed", "Go to browser", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
