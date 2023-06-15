using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chop_Is_Dish
{
    internal struct Dish
    {
        public Dish(object[] properties)
        {
            Name = properties[0].ToString();
            Photo = (byte[])properties[1];
        }
        public string Name { get; set; }
        public byte[] Photo { get; set; }

    }
}
