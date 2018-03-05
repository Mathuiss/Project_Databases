using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;

namespace Someren
{
    public static class SomerenUI
    {
        public static Control showStudents(List<Student> studentList)
        {
            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

            listView.Columns.Add("StudentNr", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Voornaam", - 2, HorizontalAlignment.Left);
            listView.Columns.Add("Achternaam", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Kamer Code", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Begeleider Code", -2, HorizontalAlignment.Left);

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

        public static Control showKamers(List<Kamer> kamerList)
        {
            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

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

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }

        public static Control showDocenten(List<Docent> docentList)
        {
            ListView listView = new ListView();
            listView.View = View.Details;
            listView.Height = 300;
            listView.Width = 400;
            listView.AllowColumnReorder = true;
            listView.GridLines = true;
            listView.Sorting = SortOrder.Ascending;

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


    }
}
