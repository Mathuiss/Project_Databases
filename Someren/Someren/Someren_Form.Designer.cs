namespace Someren
{
    partial class Someren_Form
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Someren_Form));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuAfsluiten = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            docentenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toonDocentenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            zoekKamersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            bardienstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            drankvoorraadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            kassaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            omzetrapportageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            activiteitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            activiteitenlijstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            begeleidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            roosterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            overSomerenAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            groupBox1 = new System.Windows.Forms.GroupBox();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            notifyIcon1 = new System.Windows.Forms.NotifyIcon(components);
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            bestandToolStripMenuItem,
            toolStripMenuItem5,
            docentenToolStripMenuItem,
            toolStripMenuItem1,
            bardienstToolStripMenuItem,
            activiteitenToolStripMenuItem,
            helpToolStripMenuItem});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(839, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(menuStrip1_ItemClicked);
            // 
            // bestandToolStripMenuItem
            // 
            bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            dashboardToolStripMenuItem,
            toolStripSeparator1,
            menuAfsluiten});
            bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            bestandToolStripMenuItem.Text = "Bestand";
            // 
            // dashboardToolStripMenuItem
            // 
            dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            dashboardToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            dashboardToolStripMenuItem.Text = "Dashboard";
            dashboardToolStripMenuItem.Click += new System.EventHandler(dashboardToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(128, 6);
            // 
            // menuAfsluiten
            // 
            menuAfsluiten.Name = "menuAfsluiten";
            menuAfsluiten.Size = new System.Drawing.Size(131, 22);
            menuAfsluiten.Text = "Afsluiten";
            menuAfsluiten.Click += new System.EventHandler(toolStripMenuItem10_Click);
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem6});
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new System.Drawing.Size(73, 20);
            toolStripMenuItem5.Text = "Studenten";
            toolStripMenuItem5.Click += new System.EventHandler(toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new System.Drawing.Size(158, 22);
            toolStripMenuItem6.Text = "Toon Studenten";
            toolStripMenuItem6.Click += new System.EventHandler(toolStripMenuItem6_Click);
            // 
            // docentenToolStripMenuItem
            // 
            docentenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toonDocentenToolStripMenuItem});
            docentenToolStripMenuItem.Name = "docentenToolStripMenuItem";
            docentenToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            docentenToolStripMenuItem.Text = "Docenten";
            // 
            // toonDocentenToolStripMenuItem
            // 
            toonDocentenToolStripMenuItem.Name = "toonDocentenToolStripMenuItem";
            toonDocentenToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            toonDocentenToolStripMenuItem.Text = "Toon Docenten";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripMenuItem2,
            toolStripMenuItem3,
            zoekKamersToolStripMenuItem});
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(58, 20);
            toolStripMenuItem1.Text = "Kamers";
            toolStripMenuItem1.Visible = false;
            toolStripMenuItem1.Click += new System.EventHandler(toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            toolStripMenuItem2.Text = "Kamers";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(151, 22);
            toolStripMenuItem3.Text = "Kamerindeling";
            // 
            // zoekKamersToolStripMenuItem
            // 
            zoekKamersToolStripMenuItem.Name = "zoekKamersToolStripMenuItem";
            zoekKamersToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            zoekKamersToolStripMenuItem.Text = "Zoek Kamers";
            // 
            // bardienstToolStripMenuItem
            // 
            bardienstToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            drankvoorraadToolStripMenuItem,
            kassaToolStripMenuItem,
            omzetrapportageToolStripMenuItem});
            bardienstToolStripMenuItem.Name = "bardienstToolStripMenuItem";
            bardienstToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            bardienstToolStripMenuItem.Text = "Bardienst";
            // 
            // drankvoorraadToolStripMenuItem
            // 
            drankvoorraadToolStripMenuItem.Name = "drankvoorraadToolStripMenuItem";
            drankvoorraadToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            drankvoorraadToolStripMenuItem.Text = "Drankvoorraad";
            // 
            // kassaToolStripMenuItem
            // 
            kassaToolStripMenuItem.Name = "kassaToolStripMenuItem";
            kassaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            kassaToolStripMenuItem.Text = "Kassa";
            // 
            // omzetrapportageToolStripMenuItem
            // 
            omzetrapportageToolStripMenuItem.Name = "omzetrapportageToolStripMenuItem";
            omzetrapportageToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            omzetrapportageToolStripMenuItem.Text = "Omzetrapportage";
            // 
            // activiteitenToolStripMenuItem
            // 
            activiteitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            activiteitenlijstToolStripMenuItem,
            begeleidersToolStripMenuItem,
            roosterToolStripMenuItem});
            activiteitenToolStripMenuItem.Name = "activiteitenToolStripMenuItem";
            activiteitenToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            activiteitenToolStripMenuItem.Text = "Activiteiten";
            // 
            // activiteitenlijstToolStripMenuItem
            // 
            activiteitenlijstToolStripMenuItem.Name = "activiteitenlijstToolStripMenuItem";
            activiteitenlijstToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            activiteitenlijstToolStripMenuItem.Text = "Activiteitenlijst";
            // 
            // begeleidersToolStripMenuItem
            // 
            begeleidersToolStripMenuItem.Name = "begeleidersToolStripMenuItem";
            begeleidersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            begeleidersToolStripMenuItem.Text = "Begeleiders";
            // 
            // roosterToolStripMenuItem
            // 
            roosterToolStripMenuItem.Name = "roosterToolStripMenuItem";
            roosterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            roosterToolStripMenuItem.Text = "Rooster";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            overSomerenAppToolStripMenuItem});
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // overSomerenAppToolStripMenuItem
            // 
            overSomerenAppToolStripMenuItem.Name = "overSomerenAppToolStripMenuItem";
            overSomerenAppToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            overSomerenAppToolStripMenuItem.Text = "Over SomerenApp";
            overSomerenAppToolStripMenuItem.Click += new System.EventHandler(overSomerenAppToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panel1);
            groupBox1.Location = new System.Drawing.Point(12, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(580, 410);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "TODO lijst voor Someren";
            groupBox1.Enter += new System.EventHandler(groupBox1_Enter);
            // 
            // panel1
            // 
            panel1.Location = new System.Drawing.Point(6, 18);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(568, 385);
            panel1.TabIndex = 0;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Location = new System.Drawing.Point(598, 36);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(229, 178);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "SomerenAdministratie is gestart.";
            notifyIcon1.BalloonTipTitle = "SomerenAdministratie";
            notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            notifyIcon1.Text = "SomerenAdministratie";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(notifyIcon1_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1,
            toolStripStatusLabel2});
            statusStrip1.Location = new System.Drawing.Point(0, 427);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(839, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel1.Text = " ";
            toolStripStatusLabel1.Click += new System.EventHandler(toolStripStatusLabel1_Click);
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            toolStripStatusLabel2.Text = " ";
            // 
            // Someren_Form
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(839, 449);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            Icon = ((System.Drawing.Icon)(resources.GetObject("$Icon")));
            MainMenuStrip = menuStrip1;
            Name = "Someren_Form";
            Text = "SomerenAdministratie";
            Load += new System.EventHandler(Form1_Load);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAfsluiten;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem activiteitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overSomerenAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bardienstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drankvoorraadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kassaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem omzetrapportageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activiteitenlijstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem begeleidersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roosterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        public System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem zoekKamersToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem docentenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toonDocentenToolStripMenuItem;
    }
}

