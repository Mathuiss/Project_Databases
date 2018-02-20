using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Someren
{
    public class SomerenModel
    {
        public struct Student
        {
            int id;
            string naam;

            public Student(int id, string naam)
            {
                this.id = id;
                this.naam = naam;
            }
            
            public int Id { get => id; set => id = value; }
            public string Naam { get => naam; set => naam = value; }
        }

        public class StudentList
        {
            List<SomerenModel.Student> sl = new List<SomerenModel.Student>();
            
            public void addList(SomerenModel.Student s) {
                sl.Add(s);
            }

            public List<SomerenModel.Student> getList()
            {
                return sl;
            }
        }
    }
}
