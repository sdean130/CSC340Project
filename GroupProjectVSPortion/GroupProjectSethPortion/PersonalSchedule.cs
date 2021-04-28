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
    public partial class PersonalSchedule : Form
    {
        public string name, mStart, mEnd, tuStart, tuEnd, wStart, wEnd, trStart, trEnd, fStart, fEnd; // creating variables to store information for database

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void trStartPer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fStartPer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void trEndPer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fEndPer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public PersonalSchedule()
        {
            InitializeComponent();
        }

        public void saveInfo()
        {
            // save text box/combo box into created string variables
            name = Convert.ToString(workerName.Text);
            mStart = mStartPer.GetItemText(mStartPer.Text);
            mEnd = mEndPer.GetItemText(mEndPer.Text);
            tuStart = tuStartPer.GetItemText(tuStartPer.Text);
            tuEnd = tuEndPer.GetItemText(tuEndPer.Text);
            wStart = wStartPer.GetItemText(wStartPer.Text);
            wEnd = wEndPer.GetItemText(wEndPer.Text);
            trStart = trStartPer.GetItemText(trStartPer.Text);
            trEnd = trEndPer.GetItemText(trEndPer.Text);
            fStart = fStartPer.GetItemText(fStartPer.Text);
            fEnd = fEndPer.GetItemText(fEndPer.Text);
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // save created variables into database
                string sql = "INSERT INTO eventschedule (name, weekStart, mStartTime, mEndTime, tuStartTime, tuEndTime, wStartTime, wEndTime, trStartTime, trEndTime, fStartTime, fEndTime) VALUES (@uName, @uweekStart, @umStartTime, @umEndTime, @utuStartTime, @utuEndTime, @uwStartTime, @uwEndTime, @utrStartTime, @utrEndTime, @ufStartTime, @ufEndTime)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uName", name);
                cmd.Parameters.AddWithValue("@uweekStart", Form1.weekDate);
                cmd.Parameters.AddWithValue("@umStartTime", mStart);
                cmd.Parameters.AddWithValue("@umEndTime", mEnd);
                cmd.Parameters.AddWithValue("@utuStartTime", tuStart);
                cmd.Parameters.AddWithValue("@utuEndTime", tuEnd);
                cmd.Parameters.AddWithValue("@uwStartTime", wStart);
                cmd.Parameters.AddWithValue("@uwEndTime", wEnd);
                cmd.Parameters.AddWithValue("@utrStartTime", trStart);
                cmd.Parameters.AddWithValue("@utrEndTime", trEnd);
                cmd.Parameters.AddWithValue("@ufStartTime", fStart);
                cmd.Parameters.AddWithValue("@ufEndTime", fEnd);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

        private void save_button_Click(object sender, EventArgs e) 
        {
             
            /// save to database
            saveInfo();
            /// returning to original form
            Form1 frm = new Form1();
            frm.getUserList();
            frm.Show();
            
            this.Close();
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            /// cancels save and returns to original form
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
