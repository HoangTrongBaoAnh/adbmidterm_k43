using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2019
{
    [Serializable]
    public class Employee
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string Skill { get; set; }
        public Company HomeBase { get; set; }
        public Employee Manager { get; set; }
        public double Salary { get; set; }

        public Employee(string fullName, string skill, Company homeBase, double salary)
        {
            //ID = Guid.NewGuid();
            FullName = fullName;
            Skill = skill;
            HomeBase = homeBase;
           
            Salary = salary;
        }

        public Employee()
        {
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} ({2})", FullName, Skill, Salary);
        }
    }
}
