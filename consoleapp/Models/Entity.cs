using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleapp.Models
{
    public abstract class Entity : IEntityWithName
    {
        private int _id;
        private string _name;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Entity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract string DisplayInformation();
    }
}
