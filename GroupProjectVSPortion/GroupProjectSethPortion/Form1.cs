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
    
    public partial class Form1 : Form
    {
        public string userName; // save user name from login in screen
        public static string eventName; // save name from selection in eventView
        public static string weekDate; // save the date for the week so it can display that date specifically
        public ArrayList eList;
        public static string[] roomList = new string[50]; // save into array to create columns in event check form
        public static int columnCount = 1;
        public Form1()
        {
            InitializeComponent();
            // grabbing date when initialized
            weekDate = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            // initializing listviews
            initView();
            getUserList();
            getRoomList();
            getEvent();
        }
        /// used to check if there is an event 
        private void button3_Click(object sender, EventArgs e)
        {
            // shows event details
            Show_Event frm = new Show_Event();
            frm.Show();
            this.Close();
        }

        private void eventOne_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void getUserList()
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            // connection to database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM eventschedule WHERE weekStart = @uWeekStart";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uWeekStart", weekDate);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.userName = row["Name"].ToString();
                eventList.Add(newEvent);
            }
            eList = eventList; // puts eventlist into temporary list
            // runs through loop to put data into the participants list view
            for (int i = 0; i < eventList.Count; i++)
            {
                Event thisEvent = (Event)eList[i];
                string[] row = { thisEvent.getUserName() , thisEvent.getUserName()};
                var listViewItem = new ListViewItem(row);
                participantsView.Items.Add(listViewItem);
            }
            eList = new ArrayList();
        }

        public void getRoomList()
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            // connection to database
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM eventhall WHERE weekStart = @uWeekStart";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uWeekStart", weekDate);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.roomName = row["Name"].ToString();
                eventList.Add(newEvent);
            }
            eList = eventList; // puts eventlist into temporary list
            // runs through loop to put data into the room list view
            for (int i = 0; i < eventList.Count; i++)
            {
                Event thisEvent = (Event)eList[i];
                string[] row = { thisEvent.getRoomName(), thisEvent.getRoomName() };
                var listViewItem = new ListViewItem(row);
                roomView.Items.Add(listViewItem);
            }
            eList = new ArrayList();
        }

        public void getEvent()
        {
            ArrayList eventList = new ArrayList();  //a list to save the events
            //prepare an SQL query to retrieve all the events on the same, specified date
            DataTable myTable = new DataTable();
            string connStr = "server=csdatabase.eku.edu;user=seth_dean;database=dean;port=3306;password=Dean5;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM coordinatormeeting WHERE Date = @uWeekStart";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@uWeekStart", weekDate);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myAdapter.Fill(myTable);
                Console.WriteLine("Table is ready.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            //convert the retrieved data to events and save them to the list
            foreach (DataRow row in myTable.Rows)
            {
                Event newEvent = new Event();
                newEvent.eventTitle = row["Title"].ToString();
                newEvent.meetingDate = weekDate;
                newEvent.meetingStart = row["STime"].ToString();
                newEvent.meetingEnd = row["ETime"].ToString();
                newEvent.meetingParticipants = row["Participants"].ToString();
                newEvent.meetingDescription = row["Description"].ToString();
                eventList.Add(newEvent);
            }
            eList = eventList; // puts eventlist into temporary list
            // runs through loop to put data into the event list view
            for (int i = 0; i < eventList.Count; i++)
            {
                Event thisEvent = (Event)eList[i];
                string[] row = { thisEvent.getEventTitle(), thisEvent.getMeetingDate(), thisEvent.getMeetingStart(), thisEvent.getMeetingEnd(), thisEvent.getMeetingParticipants(), thisEvent.getMeetingDescription() };
                var listViewItem = new ListViewItem(row);
                eventView.Items.Add(listViewItem);
            }
            eList = new ArrayList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // checks which items are checked in both list views
            checkedItems();
            // shows meeting choices and details
            MeetingChoice frm = new MeetingChoice();
            frm.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // grab string date
            weekDate = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            // create individuals schedule
            PersonalSchedule prsFrm = new PersonalSchedule();
            prsFrm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // create room schedule
            MeetingSchedule mtScheduleFrm = new MeetingSchedule();
            mtScheduleFrm.Show();
            this.Close();
        }
        public void initView()
        {
            // initailize each listview
            participantsView.View = View.Details;
            roomView.View = View.Details;
            eventView.View = View.Details;

            // allow listview to have checkboxes
            participantsView.CheckBoxes = true;
            // titles for listviews
            participantsView.Columns.Add("", 20);
            participantsView.Columns.Add("Name", 142);

            // allow listview to have checkboxes
            roomView.CheckBoxes = true;
            // titles for listviews
            roomView.Columns.Add("", 20);
            roomView.Columns.Add("Room", 142);

            // titles for listviews
            eventView.Columns.Add("Title", 150);
            eventView.Columns.Add("Date", 68);
            eventView.Columns.Add("Start Time", 68);
            eventView.Columns.Add("End Time", 68);
            eventView.Columns.Add("Participants", 68);
            eventView.Columns.Add("Description", 300);
        }

        private void eventView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // when the selected index is changed, give eventName that string choice
            ListViewItem item = eventView.SelectedItems[0];
            eventName = item.SubItems[0].Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // reset views when date is change
            participantsView.Items.Clear();
            roomView.Items.Clear();
            eventView.Items.Clear();
            // grab choosen date
            weekDate = monthCalendar1.SelectionStart.Date.ToString("yyyy-MM-dd");
            // redisplay the information
            getUserList();
            getRoomList();
            getEvent();
        }

        private void participantsView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void roomView_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void checkedItems()
        {
            foreach(ListViewItem item in roomView.CheckedItems)
            {
                // put checked items into a string array, update column count
                roomList[columnCount++] = item.SubItems[1].Text;
            }
            foreach(ListViewItem item in participantsView.CheckedItems)
            {
                // put checked items into a string array, update column count
                roomList[columnCount++] = item.SubItems[1].Text;
            }
        }
    }
}
