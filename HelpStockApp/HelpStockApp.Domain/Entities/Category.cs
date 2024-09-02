using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpStockApp.Domain.Entities
{
    internal class Category : Entity
    {
        public string name { get; set; }

        public Category(string name)
        {
            this.name = name;
        }
        public Entity
    }
}
