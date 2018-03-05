using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;

namespace Someren
{
    public partial class Someren_Form : Form
    {
        private List<Student> studentList;
<<<<<<< HEAD
        private List<Docent> docentList;
=======
        private List<Kamer> kamerList;
>>>>>>> Sander
        private SomerenDB database;
        private static Someren_Form instance;

        public Someren_Form()
        {
            database = new SomerenDB();
            InitializeComponent();
        }

        public static Someren_Form Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Someren_Form();
                }
                return instance;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showDashboard();
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void showDashboard()
        {
            panel1.Controls.Clear();
            
            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "-bierfust controleren";
            l.Text += "\r\n-kamerindeling maken";
            panel1.Controls.Add(l);
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            // toon hier een message "Weet je zeker dat je wilt afsluiten?"
            // Message msg = new Message();
            if ((MessageBox.Show("Weet je zeker dat je SomerenAdministratie wilt afsluiten?", "SomerenAdministratie Afsluiten?",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1) == DialogResult.Yes))
            {
                Application.Exit();
            }
           
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            studentList = database.DB_gettudents();
            SomerenUI.showStudents(studentList);
        }

        private void overSomerenAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            groupBox1.Text = "TODO LIJST";
            Label l = new Label();
            l.Height = 500;
            l.Text = "Deze applicatie is ontwikkeld voor 1.3 Project Databases, opleiding Informatica, Hogeschool Inholland Haarlem";
            
            panel1.Controls.Add(l);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // er gebeurt niks als je op de menustrip drukt
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showDashboard();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Studenten";

            studentList = database.DB_gettudents();
            panel1.Controls.Add(SomerenUI.showStudents(studentList));
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Focus();
            Enabled = true;
            Visible = true;
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            Focus();
            Enabled = true;
            Visible = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

<<<<<<< HEAD
        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Docenten";

            docentList = database.GetDocenten();
            panel1.Controls.Add(SomerenUI.showDocenten(docentList));
=======
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // kamers
            panel1.Controls.Clear();
            groupBox1.Text = "Kamers";

            kamerList = database.GetKamers();
            panel1.Controls.Add(SomerenUI.showKamers(kamerList));
>>>>>>> Sander
        }
    }
}
