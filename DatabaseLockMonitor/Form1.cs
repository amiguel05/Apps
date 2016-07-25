using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DatabaseLockMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string ConnectionString { set; get; }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm form1 = new LoginForm();
            form1.ShowDialog();

            if (form1.DialogResult != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
            ConnectionString = form1.ConnStr;

            LoadDatabase();
        }


        void LoadDatabase()
        {
            string sql = "Select database_id Id, name Name from Sys.Databases";

            SqlDataAdapter da = new SqlDataAdapter(sql, this.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                cmbDatabase.DataSource = dt;
                cmbDatabase.ValueMember = "Id";
                cmbDatabase.DisplayMember = "Name";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            


        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindLocks();
        }

        void FindLocks()
        {
            string sLockQuery = "";
            System.IO.StreamReader oReader = new System.IO.StreamReader("LockQuery.txt");

            sLockQuery = oReader.ReadToEnd();
            sLockQuery = sLockQuery.Replace("@dbId", cmbDatabase.SelectedValue.ToString());

            SqlDataAdapter da = new SqlDataAdapter(sLockQuery, this.ConnectionString);
            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            

        }

        private void killCurrentSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int iProcessId = -1;
            try
            {
                iProcessId = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value);
                KillSession(iProcessId);

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

            

        }


        void KillSession(int piSessionId)
        {
            string sql = "KILL " + piSessionId.ToString();

            SqlConnection oConn = new SqlConnection(ConnectionString);
            SqlCommand oCommand = new SqlCommand(sql);
            try
            {
                oCommand.Connection = oConn;
                oConn.Open();
                oCommand.ExecuteNonQuery();
                oConn.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();
            }


        }

    }
}
