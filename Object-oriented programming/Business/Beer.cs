
using System.Threading.Channels;

namespace Object_oriented_programming.Business
{
    public class Beer : Drink, ISalable, ISend
    {
        private const string Category = "Cerveza";

        private decimal _alcohol;
        public string Name { get; set; }
        protected decimal Price { get; set; }

        public static int QuantityObjects;

        public decimal Alcohol
        {
            get { return _alcohol; }
            set
            {
                if (value < 0)
                    value = 0;
                _alcohol = value;
            }
        }
        public string SAlcohol
        {
            get
            {
                return "Alcohol: " + _alcohol.ToString();
            }
        }

        public Beer(string name, decimal price, decimal alcohol, int quantity) :
            base(quantity)
        {
            Name = name;
            Price = price;
            Alcohol = alcohol;
            QuantityObjects++;
        }

        public virtual string GetInfo()
        {
            return "Nombre: " + Name + ", Precio: $ " + Price + ", Alcohol: " + Alcohol;
        }

        public string GetInfo(string message)
        {
            return message + " " + GetInfo();
        }

        public string GetInfo(int number)
        {
            return number +".- " + GetInfo();
        }

        public override string GetCategory()
        {
            return Category;
        }

        public decimal GetPrice()
            => Price;

        public void Send()
            => Console.WriteLine("Se envia por correo: " + GetInfo());



    }
}
