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
    public partial class Form2 : Form
    {
        public string userName, passwordText; // for when user enters username and password
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // save username and password from text boxes
            userName = Convert.ToString(userNameEntry.Text);
            passwordText = Convert.ToString(passwordEntry.Text);
            // checks if information is correct
            if (userName.Equals("seth_dean") && passwordText.Equals("Dean5"))
            { 
                // opens main form
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();
            }
        }
    }
}
