using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercitii
{
    public class Coffee
    {
        int coffeeID { get; set; }
        string coffeeType { get; set; }
        public double price { get; set; }
        double quantity { get; set; }
        bool itHasMilk { get; set; }
        bool itHasFoam { get; set; }
        bool itHasSugar { get; set; }
        

    public Coffee(int CoffeeID, string CoffeeType,double Price ,double Quantity ,bool ItHasMilk, bool ItHasFoam, bool ItHasSugar)
        {
            coffeeID = CoffeeID;
            coffeeType = CoffeeType;
            price = Price;
            quantity = Quantity;
            itHasMilk = ItHasMilk;
            itHasFoam = ItHasFoam;
            itHasSugar = ItHasSugar;
        }

        public static void PrintCoffeeData(Coffee coffeetoshow)
        {
            Console.WriteLine(coffeetoshow.coffeeID);
            Console.WriteLine(coffeetoshow.coffeeType);
            Console.WriteLine(coffeetoshow.price);
            Console.WriteLine(coffeetoshow.quantity);
            Console.WriteLine($"It has milk {coffeetoshow.itHasMilk}");
            Console.WriteLine($"It has foam {coffeetoshow.itHasFoam}");
            Console.WriteLine($"It has sugar {coffeetoshow.itHasSugar}");
        }

        public static double GetCoffeePrice(Coffee coffee)
        {
            return coffee.price;
        }
    }
}
