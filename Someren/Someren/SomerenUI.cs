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
            int aantal = studentList.Count();

            ListView listView = new ListView();
            listView.Height = 1000;

            foreach (Student student in studentList)
            {
                listView.Items.Add(new ListViewItem(student.Naam, student.Id));
            }

            return listView;
        }

        public static Control addUILabel(string text)
        {
            Label l = new Label();
            l.Text = text;
            return l;
        }
        

    }
}
