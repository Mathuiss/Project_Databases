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
        private DateTimePicker tijdStart;
        private DateTimePicker tijdEind;
        private List<Begeleider> begeleiders;

        public SomerenUI(Someren_Form form)
        {
            this.form = form;
        }

        
        
        public Control ShowStudents(List<Student> studentList)
        {
            //Is in de functie geÃ¯nitialiseerd zodat de event handeler de juiste instantie pakt
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
            listView.Columns.Add("Voornaam", -2, HorizontalAlignment.Left);
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





            
            // Set the CustomFormat string.
            //dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            kiesMinDatum.CustomFormat = "dddd dd MMMM yyyy";
            kiesMinDatum.Format = DateTimePickerFormat.Custom;



            return kiesMinDatum;           //return calender;
        }

        public Control AddMinDatumButton(int links, int boven)
        {
            kiesMinDatum = new DateTimePicker();

            // een begin en einddatum opgeven
            kiesMinDatum.MinDate = new DateTime(2018, 3, 1);
            kiesMinDatum.MaxDate = DateTime.Today;

            kiesMinDatum.Location = new Point(links, boven);
            // de volgorde opgeven
            kiesMinDatum.CustomFormat = "dddd dd MMMM yyyy";
            kiesMinDatum.Format = DateTimePickerFormat.Custom;

            return kiesMinDatum;
        }

        public Control AddMaxDatumButton(int links, int boven)
        {
            kiesMaxDatum = new DateTimePicker();
            kiesMaxDatum.Location = new Point(links, boven);

            // een begin en einddatum opgeven
            kiesMaxDatum.MinDate = new DateTime(2018, 3, 1);
            kiesMaxDatum.MaxDate = DateTime.Today;
            
            // de volgorde opgeven
            kiesMaxDatum.CustomFormat = "dddd dd MMMM yyyy";
            kiesMaxDatum.Format = DateTimePickerFormat.Custom;

            return kiesMaxDatum;
        }
        
        public Control AddDateSelectorBtn()
        { 
            var btn_BerekenTijdVerschil = new Button();
            btn_BerekenTijdVerschil.Location = new Point(0, 30);
            btn_BerekenTijdVerschil.Text = "Bereken Omzet";
            btn_BerekenTijdVerschil.Click += Btn_BerekenTijdVerschil_Click;


            return btn_BerekenTijdVerschil;
        }

        private void Btn_BerekenTijdVerschil_Click(object sender, EventArgs e)
        {
            var administratie = new AdministratieDownloader();
            List<Omzetrapportage> omzetRapportage = administratie.GetOmzetRapportage(kiesMinDatum.Value.ToString("yyyy/MM/dd"),
                kiesMaxDatum.Value.ToString("yyyy/MM/dd"));

            form.panel1.Controls.Add(ShowOmzetRapportage(omzetRapportage));
        }

        public Control ShowOmzetRapportage()
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.Columns.Add("Transactie ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Tijd", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Bedrag", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Student nummer", -2, HorizontalAlignment.Left);

            var database = new AdministratieDownloader();
            List<Omzetrapportage> omzetRapportage = database.GetOmzetRapportage();

            foreach (Omzetrapportage n in omzetRapportage)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = n.Id.ToString();
                items[1] = n.Time.ToString();
                items[2] = n.Mutatie.ToString();
                items[3] = n.StudentNr.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }

        public Control ShowOmzetRapportage(List<Omzetrapportage> omzetRapportage)
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.Columns.Add("Transactie ID", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Tijd", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Bedrag", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Student nummer", -2, HorizontalAlignment.Left);
            
            foreach (Omzetrapportage n in omzetRapportage)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = n.Id.ToString();
                items[1] = n.Time.ToString();
                items[2] = n.Mutatie.ToString();
                items[3] = n.StudentNr.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
        }

        public Control ShowKassaDranken(List<Drank> drankLijst)
        {
            //Is in de functie geÃ¯nitialiseerd zodat de event handeler de juiste instantie pakt
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

        //Bardienst
        //Kassa

        public Control ShowKassaStudenten(List<Student> studentLijst)
        {
            //Is in de functie geÃ¯nitialiseerd zodat de event handeler de juiste instantie pakt
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
                    item.SubItems[0].Text = "\u2714";
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

        public Control ShowRooster()
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 350;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.CheckBoxes = true;

            listView.ColumnClick += ListView_ColumnClick;

            listView.Columns.Add("activiteit", -2, HorizontalAlignment.Left);
            listView.Columns.Add("begeleider", -2, HorizontalAlignment.Left);
            listView.Columns.Add("datum", -2, HorizontalAlignment.Left);
            listView.Columns.Add("starttijd", -2, HorizontalAlignment.Left);
            listView.Columns.Add("eindtijd", -2, HorizontalAlignment.Left);

            var database = new SomerenDB();
            List<Rooster> roosterLijst = database.GetRooster();

            foreach (Rooster activiteit in roosterLijst)
            {
                
                string[] items = new string[5];

                items[0] = activiteit.ActiviteitNaam.ToString();
                items[1] = activiteit.BegeleiderNaam.ToString();
                items[2] = activiteit.Datum.ToString("dd/MM/yyyy");
                items[3] = activiteit.StartTijd.ToString("HH:mm:ss");
                items[4] = activiteit.EindTijd.ToString("HH:mm:ss");

                var item = new ListViewItem(items);

                listView.Items.Add(item);
            }
            return listView;
        }

        public Control AddRoosterBtn()
        {
            button = new Button();
            button.Location = new Point(370, 40);
            button.Width = 160;
            button.Text = "Nieuw item toevoegen";
            button.Click += Btn_AddRooster_Click;

            return button;
        }

        public Control ChangeRoosterBtn()
        {
            button = new Button();
            button.Location = new Point(370, 70);
            button.Width = 160;
            button.Text = "Items verwisselen";
            button.Click += Btn_ChangeRooster_Click;

            return button;
        }

        private void Btn_ChangeRooster_Click(object sender, EventArgs e)
        {
            form.panel1.Controls.Clear();
            form.groupBox1.Text = "Rooster items wisselen";

            listView.CheckBoxes = true;

            if (listView.CheckedItems.Count == 2)
            {
                var database = new RoosterManager();
                database.VerwisselItems(
                    listView.CheckedItems[0].SubItems[0].Text,
                    listView.CheckedItems[1].SubItems[0].Text
                    );
            }
            else
            {
                MessageBox.Show("U kunt maar 2 items met elkaar verwisselen");
            }

            form.panel1.Controls.Clear();
            form.panel1.Controls.Add(ShowRooster());
            form.panel1.Controls.Add(AddRoosterBtn());
            form.panel1.Controls.Add(ChangeRoosterBtn());
        }

        private void Btn_AddRooster_Click(object sender, EventArgs e)
        {
            form.panel1.Controls.Clear();
            form.groupBox1.Text = "Rooster item toevoegen";

            listView = (ListView)ShowActiviteiten();
            listView.CheckBoxes = true;
            form.panel1.Controls.Add(listView);

            var datum = new DateTimePicker();
            datum.MinDate = DateTime.Today;
            datum.Location = new Point(380, 40);
            datum.CustomFormat = "dd MMMM yyyy";
            datum.Width = 150;
            datum.Format = DateTimePickerFormat.Custom;

            tijdStart = new DateTimePicker();
            tijdStart.MinDate = DateTime.Today;
            tijdStart.Location = new Point(380, 60);
            tijdStart.Width = 70;
            tijdStart.CustomFormat = "HH:mm:ss";
            tijdStart.Format = DateTimePickerFormat.Time;
            tijdStart.ShowUpDown = true;

            tijdEind = new DateTimePicker();
            tijdEind.MinDate = DateTime.Today;
            tijdEind.Location = new Point(460, 60);
            tijdEind.Width = 70;
            tijdEind.CustomFormat = "HH:mm:ss";
            tijdEind.Format = DateTimePickerFormat.Time;
            tijdEind.ShowUpDown = true;

            var button = new Button();
            button.Text = "Activiteit toevoegen";
            button.Location = new Point(380, 160);
            button.Width = 150;
            button.Click += Btn_ActiviteitToevoegenAanRooster_Click;
            
            Button begeleiderBtn = (Button)AddBegeleiderOmzettenBtn();
            begeleiderBtn.Location = new Point(380, 120);
            begeleiderBtn.Text = "Begeleider Toevoegen";
            begeleiderBtn.Click -= Btn_VoegBegeleiderToe_Click;
            begeleiderBtn.Click += Btn_DocentAanActiviteitToevoegen_Click;

            form.panel1.Controls.Add(datum);
            form.panel1.Controls.Add(tijdStart);
            form.panel1.Controls.Add(tijdEind);
            form.panel1.Controls.Add(button);
            form.panel1.Controls.Add(begeleiderBtn);
        }

        private void Btn_DocentAanActiviteitToevoegen_Click(object sender, EventArgs e)
        {
            var database = new BegeleiderDataController();
            List<Docent> docenten = database.GetDocenten();

            formB = new Form();
            formB.Width = 480;
            formB.Height = 420;
            formB.Text = "Voeg Begeleider Toe";

            var panel = new Panel();
            panel.Location = new Point(20, 20);
            panel.Width = 460;
            panel.Height = 400;

            listViewB = (ListView)ShowDocenten(docenten);
            listViewB.CheckBoxes = true;

            var button = new Button();
            button.Text = "Voeg Toe";
            button.Location = new Point(0, 320);
            button.Click += Btn_BegeleiderAanActiviteitFinal_Click;

            formB.Controls.Add(panel);
            panel.Controls.Add(listViewB);
            panel.Controls.Add(button);

            formB.Show();
        }

        private void Btn_BegeleiderAanActiviteitFinal_Click(object sender, EventArgs e)
        {
            var database = new BegeleiderDataController();
            begeleiders = new List<Begeleider>();

            foreach (ListViewItem item in listViewB.Items)
            {
                if (item.Checked)
                {
                    begeleiders.Add(new Begeleider(int.Parse(item.SubItems[0].Text), item.SubItems[1].Text, item.SubItems[2].Text));
                }
            }

            formB.Close();
        }

        private void Btn_ActiviteitToevoegenAanRooster_Click(object sender, EventArgs e)
        {
            if (tijdStart.Value >= tijdEind.Value)
            {
                MessageBox.Show("De geselecteerde eindtijd is eerder dan de begintijd.");
            }
            else
            {
                //form.panel1.Controls.Add(Data.RoosterDataController);
                //form.panel1.Controls.Add(ShowDocenten());
            }
        }

        public Control AddToevoegenBtn()
        {
            button = new Button();
            button.Location = new Point(215, 160);
            button.Text = "Toevoegen";
            button.Click += Btn_Toevoegen_Click;

            return button;
        }

        private void Btn_Toevoegen_Click(object sender, EventArgs e)
        {
            if (listView.CheckedItems.Count != 0 || tb_Aantal.Text == "0")
            {
                foreach (ListViewItem item in listView.Items)
                {
                    if (item.Checked)
                    {
                        string naam = item.SubItems[1].Text;
                        int aantal = int.Parse(tb_Aantal.Text);

                        var calc = new DataCalculator();
                        double prijs = calc.GetPrijs(naam, aantal);

                        string[] items = new string[3];
                        items[0] = naam;
                        items[1] = aantal.ToString();
                        items[2] = prijs.ToString();

                        listViewB.Items.Add(new ListViewItem(items));
                    }
                }
            }
            else
            {
                MessageBox.Show("Voer een drank in.");
            }
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

        public Control AddBetaalBtn()
        {
            var button = new Button();
            button.Text = "Betaal";
            button.Location = new Point(400, 320);

            button.Click += Btn_Betaald_Click;

            return button;
        }

        private void Btn_Betaald_Click(object sender, EventArgs e)
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
            //Is in de functie geÃ¯nitialiseerd zodat de event handeler de juiste instantie pakt
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
            formB.Height = 420;
            formB.Text = "Voeg Begeleider Toe";

            var panel = new Panel();
            panel.Location = new Point(20, 20);
            panel.Width = 460;
            panel.Height = 400;

            listViewB = (ListView)ShowDocenten(docenten);
            listViewB.CheckBoxes = true;

            var button = new Button();
            button.Text = "Voeg Toe";
            button.Location = new Point(0, 320);
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

        public Control ShowActiviteiten()
        {
            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 370;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.ColumnClick += ListView_ColumnClick;

            var database = new SomerenDB();
            List<Activiteiten> activiteitenLijst = database.GetActiviteiten();

            listView.Columns.Add("Activiteiten code", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Omschrijving", -2, HorizontalAlignment.Left);
            listView.Columns.Add("aantal studenten", -2, HorizontalAlignment.Left);
            listView.Columns.Add("aantal begeleiders", -2, HorizontalAlignment.Left);

            foreach(Activiteiten activiteit in activiteitenLijst)
            {
                string[] items = new string[4];
                ListViewItem item;

                items[0] = activiteit.ActiviteitsCode.ToString();
                items[1] = activiteit.Omschrijving;
                items[2] = activiteit.AantalStudenten.ToString();
                items[3] = activiteit.BegeleiderCode.ToString();

                item = new ListViewItem(items);
                listView.Items.Add(item);
            }
            return listView;
        } 

        public Control ActiviteitToevoegenButton(List<Activiteiten> activiteitenlijst)
        {
            //hier een button toevoegen 

            button = new Button();
            button.Text = "toevoegen";
            button.Width = 70;
            button.Location = new Point(0, 320);

            return button;
        }

        public Control ActiviteitVerwijderenButton(List<Activiteiten> activiteitenlijst)
        {
            //hier een button toevoegen 

            button = new Button();
            button.Text = "verwijderen ";
            button.Width = 70;
            button.Location = new Point(80, 320);

            return button;
        }

        public Control ActiviteitBewerkenButton(List<Activiteiten> activiteitenlijst)
        {
            //hier een button toevoegen 

            button = new Button();
            button.Text = "bewerken";
            button.Width = 70;
            button.Location = new Point(160, 320);

            return button;
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
    }
}