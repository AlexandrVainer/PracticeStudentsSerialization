using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeStudentsSerialization
{
    internal class Student
    {
        public Student(string id,string name,int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Id},{Name},{Age}";
        }
    }
}
