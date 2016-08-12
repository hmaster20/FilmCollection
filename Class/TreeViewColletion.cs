using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmCollection
{
    public class Employee
    {
        public int nodeId { get; set; }
        public int? ParentId { get; set; }
       // public string Parent { get; set; }
        public string Name { get; set; }

        public bool Equals(Employee emp)
        {
            if (emp is Employee && emp != null)
            {
                Employee temp;
                temp = (Employee)emp;
                if (temp.Name == this.Name)
                //&& temp.Parent == this.Parent)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }

    class TreeViewColletion
    {
        public TreeViewColletion()
        {
            Employees = new List<Employee>();
        }

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; }
        }

        public void Add(Employee _emp)
        {
            Employees.Add(_emp);
        }

        public void Add(int _nodeId, int? _parentId, string _nodeName)
        //public void Add(string _parentName, string _nodeName)
        {
            var employee = new Employee
            {
                nodeId = _nodeId,
                ParentId = _parentId,
                Name = _nodeName
            };
        //FirstName = FirstNames[MyRandom.Next(0, FirstNames.Length - 1)],
        //LastName = LastNames[MyRandom.Next(0, LastNames.Length - 1)]
        Employees.Add(employee);
        }
          //  if () { System.Windows.Forms.MessageBox.Show("Test");}
    }
}
