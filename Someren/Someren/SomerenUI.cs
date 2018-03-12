using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using System.Drawing;
using Logic;
using Data;

namespace Someren
{
    public class SomerenUI
    {
        Someren_Form form;

        public SomerenUI(Someren_Form form)
        {
            this.form = form;
        }
        
        //Is in de klasse gedefinieerd omdat de event handeler anders een null reference exception gooit
        private ListView listView;
        private TextBox tb_Aantal;
        private DateTimePicker kiesDatum;
        private Button button;

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
            kiesDatum = new DateTimePicker();

            // Set the MinDate and MaxDate.
            kiesDatum.MinDate = new DateTime(2018, 3, 1);
            kiesDatum.MaxDate = DateTime.Today;

            var btn_SelecteerDatum = new Button();
            btn_SelecteerDatum.Click += Btn_SelecteerDatum_Click;

            // Set the CustomFormat string.
            //dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
            kiesDatum.CustomFormat = "dd MMMM yyyy";
            kiesDatum.Format = DateTimePickerFormat.Custom;

            return kiesDatum;         
           //return calender;
        }

        private void Btn_SelecteerDatum_Click(object sender, EventArgs e)
        {
            //var manager = new AdministratieManager();
            //manager.BerekenOmzet(kiesDatum.Value.Date);
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
            form.panel1.Controls.Clear();
        }

        public Control AddBetaalBtn()
        {
            var button = new Button();
            button.Text = "Betaal";
            button.Location = new Point(360, 320);

            button.Click += Btn_Betaald_Click;

            return button;
        }

        private void Btn_Betaald_Click(object sender, EventArgs e)
        {
            
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

        public Control showVoorraad(List<VoorraadObject> voorraad)
            // showVoorraad gebruikt momenteel nog List<Kamer>, zodat er geen errors getoond worden.
        {

            listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.ColumnClick += ListView_ColumnClick;

            listView.Columns.Add("Drankje", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Aantal", -2, HorizontalAlignment.Left);

            foreach (VoorraadObject drankje in voorraad)
            {
                string[] items = new string[3];
                ListViewItem item;

                items[0] = drankje.Id.ToString();
                items[1] = drankje.Naam.ToString();
                items[2] = drankje.Aantal.ToString();

                item = new ListViewItem(items);

                listView.Items.Add(item);
            }

            return listView;
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
