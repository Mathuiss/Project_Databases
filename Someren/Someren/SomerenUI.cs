using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using Model;
using Logic;
using Data;

namespace Someren
{
    public class SomerenUI
    {
        Someren_Form form;
        Form formB;

        //Is in de klasse gedefinieerd omdat de event handeler anders een null reference exception gooit
        private ListView listView;
        private ListView listViewB;
        private TextBox tb_Aantal;
        private DateTimePicker kiesMinDatum;
        private DateTimePicker kiesMaxDatum;
        private Button button;
        private int selectedStudent;

        public SomerenUI(Someren_Form form)
        {
            this.form = form;
        }
        
        public Control ShowStudents(List<Student> studentList)
        {
            //Is in de functie geïnitialiseerd zodat de event handeler de juiste instantie pakt
            listView = new ListView();

            //List view eigenschappen
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            //Event handeler
            listView.ColumnClick += ListView_ColumnClick;

            //Kolommen voor in de list view
            listView.Columns.Add("StudentNr", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Voornaam", - 2, HorizontalAlignment.Left);
            listView.Columns.Add("Achternaam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Kamer Code", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Begeleider Code", -2, HorizontalAlignment.Left);

            //Vul de list view met data uit de studentenlijst
            foreach (Student student in studentList)
            {
                string[] items = new string[5];
                ListViewItem item;

                items[0] = student.Id.ToString();
                items[1] = student.Naam;
                items[2] = student.Achternaam;
                items[3] = student.KamerCode.ToString();
                items[4] = student.BegeleiderCode.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }
        
        public Control ShowKamers(List<Kamer> kamerList)
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.ColumnClick += ListView_ColumnClick;
            
            listView.Columns.Add("Kamer Code", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Max. Personen", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Is Docent Kamer", -2, HorizontalAlignment.Left);

            foreach (Kamer kamer in kamerList)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = kamer.KamerCode.ToString();
                items[1] = kamer.MaxPersonen.ToString();
                items[2] = kamer.IsBegeleider.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }
        
        public Control ShowDocenten(List<Docent> docentList)
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.ColumnClick += ListView_ColumnClick;
            
            listView.Columns.Add("Docent Code", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Voornaam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Achternaam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Is Begeleider", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Slaapt Op", -2, HorizontalAlignment.Left);

            foreach (Docent docent in docentList)
            {
                string[] items = new string[5];
                ListViewItem item;

                items[0] = docent.Id.ToString();
                items[1] = docent.Naam;
                items[2] = docent.Achternaam;
                items[3] = docent.Begeleider.ToString();
                items[4] = docent.KamerNummer.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }

        public Control ShowOmzetCalendar()
        {
            //var calender = new MonthCalendar();
            
            // Create a new DateTimePicker control and initialize it.
            kiesMinDatum = new DateTimePicker();
            kiesMaxDatum = new DateTimePicker();


            // Set the MinDate and MaxDate.
            kiesMinDatum.MinDate = new DateTime(2018, 3, 1);
            kiesMinDatum.MaxDate = DateTime.Today;

            kiesMaxDatum.MinDate = new DateTime(2018, 3, 1);
            kiesMaxDatum.MaxDate = DateTime.Today;

            
            // Set the CustomFormat string.
            //dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            kiesMinDatum.CustomFormat = "dddd dd MMMM yyyy";
            kiesMinDatum.Format = DateTimePickerFormat.Custom;

            kiesMaxDatum.CustomFormat = "dddd dd MMMM yyyy";
            kiesMaxDatum.Format = DateTimePickerFormat.Custom;

            return kiesMinDatum;           //return calender;
        }

        public Control AddMinDatumButton(int links, int boven)
        {
            var btn_SelecteerMinDatum = new DateTimePicker();
            btn_SelecteerMinDatum.Location = new Point(links, boven);

            return btn_SelecteerMinDatum;
        }

        public Control AddMaxDatumButton(int links, int boven)
        {
            var btn_SelecteerMaxDatum = new DateTimePicker();
            btn_SelecteerMaxDatum.Location = new Point(links, boven);

            return btn_SelecteerMaxDatum;
        }

        private void Btn_SelecteerDatum_Click(object sender, EventArgs e)
        {
            var manager = new AdministratieManager();
            manager.BerekenOmzet(kiesMinDatum.Value.Date);
        }
        
        public Control ShowKassaDranken(List<Drank> drankLijst)
        {
            //Is in de functie geïnitialiseerd zodat de event handeler de juiste instantie pakt
            listView = new ListView();

            //List view eigenschappen
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 200;
            listView.Location = new Point(0, 0);
            listView.CheckBoxes = true;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            //Event handeler
            listView.ColumnClick += ListView_ColumnClick;

            //Kolommen voor in de list view
            listView.Columns.Add("Naam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Prijs", -2, HorizontalAlignment.Left);

            foreach (Drank drank in drankLijst)
            {
                string[] items = new string[2];
                ListViewItem item;

                items[0] = drank.Naam;
                items[1] = drank.Prijs.ToString("0.00");

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }

        //STUDENTENSCHERM

        public Control ShowKassaStudenten(List<Student> studentLijst)
        {
            //Is in de functie geïnitialiseerd zodat de event handeler de juiste instantie pakt
            listView = new ListView();

            //List view eigenschappen
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 500;
            listView.Location = new Point(0, 0);
            listView.CheckBoxes = true;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            //Event handeler
            listView.ColumnClick += ListView_ColumnClick;

            //Kolommen voor in de list view
            listView.Columns.Add("Studentnummer", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Naam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Achternaam", -2, HorizontalAlignment.Left);

            foreach (Student student in studentLijst)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = student.Id.ToString();
                items[1] = student.Naam;
                items[2] = student.Achternaam;

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }
            
            return listView;
        }
        
        public Control AddStudentSelectButton()
        {
            button = new Button();
            button.Text = "Selecteer";
            button.Width = 70;
            button.Location = new Point(0, 320);

            button.Click += Btn_Selecteer_Click;

            return button;
        }
        
        private void Btn_Selecteer_Click(object sender, EventArgs e)
        {
            
            if (listView.CheckedItems.Count != 0)
            {
                form.panel1.Controls.Clear();
                selectedStudent = int.Parse(listView.CheckedItems[0].Text);
                var database = new SomerenDB();
                form.panel1.Controls.Add(ShowVoorraad(database.GetVoorraad()));

                Control[] controls = AddAantalDialog();
                form.panel1.Controls.AddRange(controls);
                form.panel1.Controls.Add(AddToevoegenBtn());
                form.panel1.Controls.Add(ShowBestelling());
                form.panel1.Controls.Add(AddBetaalBtn());
            }
            else
            {
                MessageBox.Show("Selecteer een student");
            }

        }

        //VOORRAADSCHERM

        public Control ShowVoorraad(List<VoorraadObject> voorraad)
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 200;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.CheckBoxes = true;

            listView.ColumnClick += ListView_ColumnClick;

            listView.Columns.Add("", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Drank", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Aantal", -2, HorizontalAlignment.Left);

            foreach (VoorraadObject drankje in voorraad)
            {
                string[] items = new string[3];

                items[1] = drankje.Naam;
                items[2] = drankje.Aantal.ToString();

                var item = new ListViewItem(items);

                listView.Items.Add(item);

                // Als het aantal kleiner dan 10 is worden de cellen rood gekleurd.
                if (drankje.Aantal < 10)
                {
                    item.SubItems[0].Text = "!!!"; // !!! of \uFF01 - full-width exclamation mark
                    item.SubItems[0].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    item.SubItems[0].Text = "✔";
                    item.SubItems[0].ForeColor = System.Drawing.Color.Green;
                }
            }

            return listView;
        }

        public Control ShowBestelling()
        {
            listViewB = new ListView();
            listViewB.View = View.Details;
            listViewB.Height = 300;
            listViewB.Width = 200;
            listViewB.AllowColumnReorder = true;
            listViewB.GridLines = true;
            listViewB.Sorting = SortOrder.Ascending;
            listViewB.CheckBoxes = true;
            listViewB.Location = new Point(300, 0);

            listViewB.Columns.Add("Drankje", -2, HorizontalAlignment.Left);
            listViewB.Columns.Add("Aantal", -2, HorizontalAlignment.Left);
            listViewB.Columns.Add("Prijs", -2, HorizontalAlignment.Left);

            return listViewB;
        }

        public Control AddToevoegenBtn()
        {
            button = new Button();
            button.Location = new Point(215, 160);
            button.Text = "Toevoegen";
            button.Click += Btn_Toevoegen_Click;

            return button;
        }

        public Control[] AddAantalDialog()
        {
            var dialog = new Control[3];

            var btn_Plus = new Button();
            btn_Plus.Location = new Point(220, 90);
            btn_Plus.Height = 20;
            btn_Plus.Width = 60;
            btn_Plus.Text = "+";
            btn_Plus.Click += Btn_Plus_Click;

            tb_Aantal = new TextBox();
            tb_Aantal.Location = new Point(220, 110);
            tb_Aantal.Height = 10;
            tb_Aantal.Width = 60;
            tb_Aantal.Text = "1";

            var btn_Min = new Button();
            btn_Min.Location = new Point(220, 130);
            btn_Min.Height = 20;
            btn_Min.Width = 60;
            btn_Min.Text = "-";
            btn_Min.Click += Btn_Min_Click;

            dialog[0] = btn_Plus;
            dialog[1] = tb_Aantal;
            dialog[2] = btn_Min;

            
            return dialog;
        }

        private void Btn_Min_Click(object sender, EventArgs e)
        {
            int n = int.Parse(tb_Aantal.Text);
            n--;
            tb_Aantal.Text = n.ToString();
        }

        private void Btn_Plus_Click(object sender, EventArgs e)
        {
            int n = int.Parse(tb_Aantal.Text);
            n++;
            tb_Aantal.Text = n.ToString();
        }

        private void Btn_Betaald_Click(object sender, EventArgs e)
        {
            var button = new Button();
            button.Text = "Betaal";
            button.Location = new Point(400, 320);

            button.Click += Btn_Betaald_Click;

            return button;
        }

        public Control ShowVoorraad(List<VoorraadObject> voorraad)
        {
            var processor = new AfrekenProcessor();
            var bestelling = new List<Order>();

            foreach (ListViewItem item in listViewB.Items)
            {
                bestelling.Add(new Order(selectedStudent, item.SubItems[0].Text, int.Parse(item.SubItems[1].Text), double.Parse(item.SubItems[2].Text)));
            }

            processor.RekenAf(bestelling);

            var database = new SomerenDB();
            List<Student> studenten = database.GetStudenten();

            form.panel1.Controls.Clear();
            form.panel1.Controls.Add(ShowKassaStudenten(studenten));
            form.panel1.Controls.Add(AddStudentSelectButton());
        }

        public Control ShowBegeleiders()
        {
            //Is in de functie geïnitialiseerd zodat de event handeler de juiste instantie pakt
            listView = new ListView();
            
            //List view eigenschappen
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 300;
            listView.Location = new Point(0, 0);
            listView.CheckBoxes = true;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            //Event handeler
            listView.ColumnClick += ListView_ColumnClick;

            //Kolommen voor in de list view
            listView.Columns.Add("Begeleiderscode", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Voornaam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Achternaam", -2, HorizontalAlignment.Left);

            var database = new BegeleiderDataController();
            List<Begeleider> begeleiders = database.GetBegeleiders();

            foreach (Begeleider begeleider in begeleiders)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = begeleider.BegeleiderCode.ToString();
                items[1] = begeleider.Naam;
                items[2] = begeleider.Achternaam;
                
                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }

        public Control AddBegeleiderOmzettenBtn()
        {
            var button = new Button();
            button.Text = "Voeg Toe";
            button.Location = new Point(350, 0);
            button.Width = 150;

            button.Click += Btn_VoegBegeleiderToe_Click;

            return button;
        }

        public Control AddRemoveBegeleiderBtn()
        {
            var button = new Button();
            button.Text = "Verwijder Begeleider";
            button.Location = new Point(350, 40);
            button.Width = 150;

            button.Click += Btn_RemoveBegeleider_Click;

            return button;
        }

        private void Btn_RemoveBegeleider_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Weet u zeker dat u deze begeleider wil verwijderen?",
                    "Begeleider Verwijderen",
                    MessageBoxButtons.YesNo
                    );
                if (dialogResult == DialogResult.Yes)
                {
                    var database = new BegeleiderDataController();

                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.Checked)
                        {
                            database.RemoveBegeleider(int.Parse(item.SubItems[0].Text));
                        }
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    form.panel1.Controls.Clear();
                    form.panel1.Controls.Add(ShowBegeleiders());
                }
            }
            else
            {
                MessageBox.Show("Selecteer een begeleider.");
            }

            form.panel1.Controls.Clear();
            form.panel1.Controls.Add(ShowBegeleiders());
            form.panel1.Controls.Add(AddBegeleiderOmzettenBtn());
            form.panel1.Controls.Add(AddRemoveBegeleiderBtn());
        }

        private void Btn_VoegBegeleiderToe_Click(object sender, EventArgs e)
        {
            var database = new BegeleiderDataController();
            List<Docent> docenten = database.GetDocenten();

            formB = new Form();
            formB.Width = 480;
            formB.Height = 480;
            formB.Text = "Voeg Begeleider Toe";

            var panel = new Panel();
            panel.Location = new Point(20, 20);
            panel.Width = 460;
            panel.Height = 460;

            listViewB = (ListView)ShowDocenten(docenten);
            listViewB.CheckBoxes = true;

            var button = new Button();
            button.Text = "Voeg Toe";
            button.Location = new Point(0, 350);
            button.Click += Btn_VoegToeClick;

            formB.Controls.Add(panel);
            panel.Controls.Add(listViewB);
            panel.Controls.Add(button);

            formB.Show();
        }

        private void Btn_VoegToeClick(object sender, EventArgs e)
        {
            var database = new BegeleiderDataController();

            foreach (ListViewItem item in listViewB.Items)
            {
                if (item.Checked)
                {
                    database.CreateBegeleider(int.Parse(item.SubItems[0].Text));
                }
            }

            formB.Close();
            form.panel1.Controls.Clear();
            form.panel1.Controls.Add(ShowBegeleiders());
            form.panel1.Controls.Add(AddBegeleiderOmzettenBtn());
            form.panel1.Controls.Add(AddRemoveBegeleiderBtn());
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            switch (listView.Sorting)
            {
                case SortOrder.Ascending:
                    listView.Sorting = SortOrder.Descending;
                    break;
                case SortOrder.Descending:
                    listView.Sorting = SortOrder.Ascending;
                    break;
                default:
                    listView.Sorting = SortOrder.Ascending;
                    break;
            }

            listView.Sort();
        }

        public Control AddUILabel(string text, int x, int y, int width)
        {
            Label l = new Label();
            l.Text = text;
            l.Location = new Point(x, y);
            l.Width = width;
            return l;
        }
    }
}