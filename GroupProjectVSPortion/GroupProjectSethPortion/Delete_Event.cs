using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GroupProjectSethPortion
{
    public partial class Delete_Event : Form
    {
        public Delete_Event()
        {
            InitializeComponent();
            // displays what is being deleted and if the user wants to
            checksCondition.Text = "Are you sure you want to delete: \r\n" + Form1.eventName +"?"; 
        }

        private void yesAction_Click(object sender, EventArgs e)
        {
            /// should save so system can close the open event and delete from table
            deleteEvent();
            // opens new start to refresh data
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void noAction_Click(object sender, EventArgs e)
        {
            /// just cancels action
            Show_Event frm = new Show_Event();
            frm.Show();
            this.Close();
        }

        public void deleteEvent()
        {
            // sql string to log into database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySqlConnection conn = new MySqlConnection(connStr); // connection to database
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "DELETE FROM coordinatormeeting WHERE Title = @utitle"; // deleting row based on title event the user has selected
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@utitle", Form1.eventName);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
    }
}
