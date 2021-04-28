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
    public partial class Show_Event : Form
    {
        public Show_Event()
        {
            InitializeComponent();
            showEvent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// return to event list
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /// goes to seperate form to ask if user wants to delete this event
            Delete_Event frm = new Delete_Event();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
            /// edit the event
        }

        public void showEvent()
        {
            // connect to database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";

            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            // checks if there are no issues with database
            try
            {
                conn.Open(); // opens database

                string sql = "SELECT * FROM coordinatormeeting WHERE Title = @uTitle"; // grab data from the database

                MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@uTitle", Form1.eventName);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    eventDate.Text = myReader["Date"].ToString();
                    eventTitle.Text = myReader["Title"].ToString();
                    eventStart.Text = myReader["STime"].ToString();
                    eventEnd.Text = myReader["ETime"].ToString();
                    eventRoom.Text = myReader["Location"].ToString();
                    eventParticipants.Text = myReader["Participants"].ToString();
                    eventDetails.Text = myReader["Description"].ToString();
                }
                myReader.Close();
            }
            // if there is an issue, don't execute database function
            catch (Exception ex)
            {
                // displays error
                Console.WriteLine(ex.ToString());

            }
            // closes database
            conn.Close();
        }
    }
}
