using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Data;

namespace Someren
{
    public partial class Someren_Form : Form
    {
        private SomerenUI SomerenUI;
        private List<Student> studentLijst;
        private List<Docent> docentLijst;
        private List<Kamer> kamerLijst;
        private List<VoorraadObject> voorraadLijst;
        private List<Rooster> roosterLijst;
        private List<Activiteiten> activiteitenLijst;
        private SomerenDB database;
        private static Someren_Form instance;

        public Someren_Form()
        {
            SomerenUI = new SomerenUI(this);
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
            l.Height =500;
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
            studentLijst = database.GetStudenten();
            SomerenUI.ShowStudents(studentLijst);
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
            // Schoont het veld op en toont een tabel met studenten
            panel1.Controls.Clear();
            groupBox1.Text = "Studenten";

            try
            {
                studentLijst = database.GetStudenten();
                panel1.Controls.Add(SomerenUI.ShowStudents(studentLijst));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

        private void toonDocentenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //eventuele data laten verdwijnen
            panel1.Controls.Clear();
            groupBox1.Text = "Docenten";

            try
            {
                //toont de tabel met docenten.
                docentLijst = database.GetDocenten();
                //panel1.Controls.Add(SomerenUI.ShowDocenten());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // kamers
            panel1.Controls.Clear();
            groupBox1.Text = "Kamers";

            try
            {
                kamerLijst = database.GetKamers();
                panel1.Controls.Add(SomerenUI.ShowKamers(kamerLijst));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString();
        }

        private void kassaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Kassa";

            try
            {
                studentLijst = database.GetStudenten();

                panel1.Controls.Add(SomerenUI.ShowKassaStudenten(studentLijst));
                panel1.Controls.Add(SomerenUI.AddStudentSelectButton());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void omzetrapportageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Omzetrapportage";

            //panel1.Controls.Add(SomerenUI.ShowOmzetCalendar());
            panel1.Controls.Add(SomerenUI.AddMaxDatumButton(5,5));
            panel1.Controls.Add(SomerenUI.AddMinDatumButton(225,5));

            panel1.Controls.Add(SomerenUI.AddDateSelectorBtn());

            //uitslag als derde button voor de uitslag

            panel1.Controls.Add(SomerenUI.ShowOmzetRapportage());
        }

        private void begeleidersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Begeleiders";

            panel1.Controls.Add(SomerenUI.ShowBegeleiders());
            panel1.Controls.Add(SomerenUI.AddBegeleiderOmzettenBtn());
            panel1.Controls.Add(SomerenUI.AddRemoveBegeleiderBtn());
        }

        private void drankvoorraadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Drankvoorraad";

            try
            {
                //toont de tabel met voorraad.
                voorraadLijst = database.GetVoorraad();
                panel1.Controls.Add(SomerenUI.ShowVoorraad(voorraadLijst));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void roosterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            groupBox1.Text = "Rooster";

            try
            {
                //toont de tabel met voorraad.
                roosterLijst = database.GetRooster();
                panel1.Controls.Add(SomerenUI.ShowRooster());
                panel1.Controls.Add(SomerenUI.AddRoosterBtn());
                panel1.Controls.Add(SomerenUI.ChangeRoosterBtn());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void activiteitenlijstToolStripMenuItem_Click(object sender, EventArgs e) /// de show activiteiten moet nog worden geactiveerd
        {
            //pagina aanmaken en tussenkopje laten zien. 
            panel1.Controls.Clear();
            groupBox1.Text = "Activiteitenlijst";
            
            //verwijzen naar somerenUI
            var database = new SomerenDB();
            panel1.Controls.Add(SomerenUI.ShowActiviteiten(database.GetActiviteiten()));
            panel1.Controls.Add(SomerenUI.ActiviteitToevoegenButton());
            panel1.Controls.Add(SomerenUI.ActiviteitVerwijderenButton());
            panel1.Controls.Add(SomerenUI.ActiviteitBewerkenButton());
        }
    }
}
