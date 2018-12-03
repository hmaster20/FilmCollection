using System;
using System.Collections.Generic;

namespace FC.Provider
{
    public class Catalog
    {
        public int nodeId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }

        public bool Equals(Catalog emp)
        {
            if (emp != null)
            {
                Catalog temp;
                temp = (Catalog)emp;
                if (temp.Name == this.Name
                    && temp.ParentId == this.ParentId)
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

    //class TreeViewColletion
    //{
    //    public TreeViewColletion()
    //    {
    //        Employees = new List<Catalog>();
    //    }

    //    private List<Employee> _employees;
    //    public List<Catalog> Employees { get; set; }
    //    public void Add(Catalog _emp)
    //    {
    //        Employees.Add(_emp);
    //    }

    //    public void Add(int _nodeId, int? _parentId, string _nodeName)
    //    {
    //        var employee = new Catalog
    //        {
    //            nodeId = _nodeId,
    //            ParentId = _parentId,
    //            Name = _nodeName
    //        };
    //        Employees.Add(employee);
    //    }

    //    public bool Equals(Employee other)
    //    {
    //        if (other == null) { return false; }
    //        else
    //        {
    //            //f (this.Employees.)
    //            return (this.Employees.Equals(other));
    //        }
    //    }


    //    public bool Contains(T item)
    //    {
    //        foreach (T member in list)
    //            if (member.Equals(item))
    //                return true;
    //        return false;
    //    }
    //}
}
