namespace GroupProjectSethPortion
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.participantsView = new System.Windows.Forms.ListView();
            this.roomView = new System.Windows.Forms.ListView();
            this.eventView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Individual Schedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Meeting Place Time";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(59, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Show Event";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(59, 363);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Check Event";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // participantsView
            // 
            this.participantsView.CheckBoxes = true;
            this.participantsView.Location = new System.Drawing.Point(277, 18);
            this.participantsView.Name = "participantsView";
            this.participantsView.Size = new System.Drawing.Size(163, 162);
            this.participantsView.TabIndex = 5;
            this.participantsView.UseCompatibleStateImageBehavior = false;
            this.participantsView.SelectedIndexChanged += new System.EventHandler(this.participantsView_SelectedIndexChanged);
            // 
            // roomView
            // 
            this.roomView.CheckBoxes = true;
            this.roomView.Location = new System.Drawing.Point(509, 18);
            this.roomView.Name = "roomView";
            this.roomView.Size = new System.Drawing.Size(163, 162);
            this.roomView.TabIndex = 6;
            this.roomView.UseCompatibleStateImageBehavior = false;
            this.roomView.SelectedIndexChanged += new System.EventHandler(this.roomView_SelectedIndexChanged);
            // 
            // eventView
            // 
            this.eventView.Location = new System.Drawing.Point(277, 192);
            this.eventView.Name = "eventView";
            this.eventView.Size = new System.Drawing.Size(395, 194);
            this.eventView.TabIndex = 7;
            this.eventView.UseCompatibleStateImageBehavior = false;
            this.eventView.SelectedIndexChanged += new System.EventHandler(this.eventView_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(711, 425);
            this.Controls.Add(this.eventView);
            this.Controls.Add(this.roomView);
            this.Controls.Add(this.participantsView);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListView participantsView;
        private System.Windows.Forms.ListView roomView;
        private System.Windows.Forms.ListView eventView;
    }
}

