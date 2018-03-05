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
            listView.Height = 1000;
            listView.Width = 500;

            listView.Columns.Add("StudentNr");
            listView.Columns.Add("Voornaam");
            listView.Columns.Add("Achternaam");
            listView.Columns.Add("Kamer Code");
            listView.Columns.Add("Begeleider Code");

            foreach (Student student in studentList)
            {
                listView.Items.Add(new ListViewItem(new string[] {student.Id.ToString(), student.Naam, student.Achternaam,
                    student.KamerCode.ToString(), student.BegeleiderCode.ToString() }));
            }

            return listView;
        }

        public static Control showKamers(List<Kamer> kamerList)
        {
            ListView listView = new ListView();
            listView.Height = 1000;

            foreach (Kamer kamer in kamerList)
            {
                listView.Items.Add(new ListViewItem(kamer.KamerCode.ToString(), kamer.MaxPersonen));
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
            int aantal = docentList.Count();

            ListView listView = new ListView();
            listView.Height = 1000;

            foreach (Docent docent in docentList)
            {
                listView.Items.Add(new ListViewItem(docent.Naam));
            }

            return listView;
        }


    }
}
