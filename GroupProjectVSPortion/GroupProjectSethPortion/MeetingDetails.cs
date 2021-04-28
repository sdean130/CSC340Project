using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProjectSethPortion
{
    public partial class MeetingDetails : Form
    {
        public MeetingDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /// save details
            saveInfo();
            this.Close();
        }

        public void saveInfo()
        {
            // save information to meeting choice form, so all of the information can be saved at once
            MeetingChoice.meetingTitle = eventTitle.Text;
            MeetingChoice.meetingNotes = eventNotes.Text;
            MeetingChoice.meetingdetails = eventDescription.Text;
        }
    }
}
