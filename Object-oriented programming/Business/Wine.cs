using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_oriented_programming.Business
{
    public class Wine : Drink
    {
        private const string Category = "Vino";

        public Wine(int quantity) : base(quantity) { }

        public override string GetCategory() => Category;
    }
}
