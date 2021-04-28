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
using System.Collections;

namespace GroupProjectSethPortion
{
    public partial class MeetingChoice : Form
    {
        public static string meetingTitle, meetingdetails, meetingNotes, rowCheck;
        public MeetingChoice()
        {
            InitializeComponent();
            /// creates rows for information to be populated in
            /// should use to add information about schedule
            dataGridView1.ColumnCount = Form1.columnCount;
            for(int i = 1; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Name = Form1.roomList[i];
            }

            // create colors for rows
            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = Color.Red;
            // create times in first row
            string[] row = new string[] { "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "21:00", "22:00", "23:00"};
            for(int i = 0; i < row.Length; i++)
            {
                dataGridView1.Rows.Add(row[i]);
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style = CellStyle;
                }
            }
            //checkListRoom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /// allows user to add details to the meeting topic
            MeetingDetails frm = new MeetingDetails();
            frm.Show();
        }
        // makes the gridview colored which shows which event can go where and the availablity 
        public void checkListRoom()
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            // connect to database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM eventhall WHERE weekStart = @uWeekStart"; // grab items from a certain hall
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uWeekStart", Form1.weekDate);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //conn.Close();

            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.roomName = row["Name"].ToString();
                newEvent.fStart = row["fStartTime"].ToString();
                newEvent.fEnd = row["fEndTime"].ToString();
                eventList.Add(newEvent);
            }
            // changes the availability to green to show when a certain room is available 
            Event thisEvent = new Event();
            for (int i = 0; i < eventList.Count; i++)
            {
                thisEvent = (Event)eventList[i];
            }
                for (int j = 0; j < dataGridView1.Rows.Count; j++) {
                
                rowCheck = dataGridView1.Rows[j].Cells.ToString();
                MessageBox.Show(rowCheck);
                    if (thisEvent.getFStart() == rowCheck )
                    {
                        MessageBox.Show("Hello");
                    }
                }
                
            //}
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// response to say that information is closing and is being saved
            /// save to database
            saveEvent();
            // clear the array for future events
            for(int i = 0; i < Form1.columnCount; i++)
            {
                Form1.roomList[i] = null;
            }
            // column length set back to original length
            Form1.columnCount = 1;
            // return to original form
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /// information will not be saved
            /// clear array for future events
            for (int i = 0; i < Form1.columnCount; i++)
            {
                Form1.roomList[i] = null;
            }
            // column length set back to original length
            Form1.columnCount = 1;
            // return to original form
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        public void saveEvent()
        {
            // connect to database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "INSERT INTO coordinatormeeting (date, title, Location, Description) VALUES (@udate, @utitle, @ulocation, @udescription)"; // insert specific values into database
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@udate", Form1.weekDate);
                cmd.Parameters.AddWithValue("@utitle", meetingTitle);
                //cmd.Parameters.AddWithValue("@usTime", sTime);
                //cmd.Parameters.AddWithValue("@ueTime", eTime);
                cmd.Parameters.AddWithValue("@ulocation", Form1.roomList[1]);
                //cmd.Parameters.AddWithValue("@uparticipants", dParticipants);
                cmd.Parameters.AddWithValue("@udescription", meetingdetails);
                cmd.ExecuteNonQuery();
                //Form1.editEvent = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }
    }
}
