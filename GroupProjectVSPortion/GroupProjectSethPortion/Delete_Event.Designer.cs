namespace GroupProjectSethPortion
{
    partial class Delete_Event
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
            this.yesAction = new System.Windows.Forms.Button();
            this.noAction = new System.Windows.Forms.Button();
            this.checksCondition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesAction
            // 
            this.yesAction.Location = new System.Drawing.Point(36, 82);
            this.yesAction.Name = "yesAction";
            this.yesAction.Size = new System.Drawing.Size(75, 23);
            this.yesAction.TabIndex = 0;
            this.yesAction.Text = "Yes";
            this.yesAction.UseVisualStyleBackColor = true;
            this.yesAction.Click += new System.EventHandler(this.yesAction_Click);
            // 
            // noAction
            // 
            this.noAction.Location = new System.Drawing.Point(128, 82);
            this.noAction.Name = "noAction";
            this.noAction.Size = new System.Drawing.Size(75, 23);
            this.noAction.TabIndex = 1;
            this.noAction.Text = "Cancel";
            this.noAction.UseVisualStyleBackColor = true;
            this.noAction.Click += new System.EventHandler(this.noAction_Click);
            // 
            // checksCondition
            // 
            this.checksCondition.AutoSize = true;
            this.checksCondition.Location = new System.Drawing.Point(33, 23);
            this.checksCondition.MinimumSize = new System.Drawing.Size(100, 40);
            this.checksCondition.Name = "checksCondition";
            this.checksCondition.Size = new System.Drawing.Size(100, 40);
            this.checksCondition.TabIndex = 2;
            this.checksCondition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Delete_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(237, 132);
            this.Controls.Add(this.checksCondition);
            this.Controls.Add(this.noAction);
            this.Controls.Add(this.yesAction);
            this.Name = "Delete_Event";
            this.Text = "Delete_Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesAction;
        private System.Windows.Forms.Button noAction;
        private System.Windows.Forms.Label checksCondition;
    }
}