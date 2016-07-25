using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace DatabaseLockMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        const string sConn = "Data Source=[datasource];Initial Catalog=master;User ID=[username];Password=[password]";

        const string sConnIntegrate = "Data Source=[datasource];Initial Catalog=master;Integrated Security=SSPI;";

        public string ConnStr { set; get; }

        void LoadCombo()
        {
            foreach(string s in System.Configuration.ConfigurationManager.AppSettings.Keys)
            {
                if (s.Substring(0,2) == "db")
                {
                    cmbConection.Items.Add(System.Configuration.ConfigurationManager.AppSettings[s].ToString());
                }
            }

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string sConstr = "";
            bool bRetorno = false;

            if(chkIntegrate.Checked)
            {
                sConstr = sConnIntegrate;
            }
            else
            {
                sConstr = sConn ;
            }

            sConstr = sConstr.Replace("[datasource]", cmbConection.Text);
            sConstr = sConstr.Replace("[username]", txtUserName.Text);
            sConstr = sConstr.Replace("[password]", txtClave.Text);

            SqlConnection oConn = new SqlConnection(sConstr);         

            try
            {
                oConn.Open();
                bRetorno = true;
                ConnStr = sConstr;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();
            }


            if (bRetorno == true)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
    }
}
