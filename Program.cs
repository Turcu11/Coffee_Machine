using System;

namespace Exercitii
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = -1;
            double credit = 0.0;
            Console.WriteLine("Loading...");
            Console.WriteLine("Welcome to Turcu's coffee machine !");
            NavHelper();
            do
            {
                switch (option)
                {
                    case 1:
                        Info(credit);
                        break;

                    case 2:
                        Menu();
                        OrderCoffee(SelectCoffee(), credit);
                        credit = SubtractCredit(credit, Coffee.GetCoffeePrice(SelectCoffee()));
                        break;

                    case 3:
                        Console.Write($"Plese enter the ammount you want to add: ");
                        credit = AddCredit(credit, Convert.ToDouble(Console.ReadLine()));
                        break;
                }
                Console.Write($"Please select your option: ");
                option = Convert.ToInt32(Console.ReadLine());
                NavHelper();
            }
            while (option > 0);
        }

        public static void Info(double credit)
        {
            Console.WriteLine($"Status = RUNNING");
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"Credit = {credit}");
        }

        public static void NavHelper()
        {
            Console.Clear();
            Console.WriteLine($"1. Show info.");
            Console.WriteLine($"2. Order coffeee.");
            Console.WriteLine($"3. Add credit.");
            Console.WriteLine();
        }

        public static double AddCredit(double currentCredit, double sumToAdd)
        {
            while(sumToAdd <= 0)
            {
                Console.WriteLine($"You need to add a pozitive ammount of credit !");
                Console.Write($"Credit to add: ");
                sumToAdd = Convert.ToDouble(Console.ReadLine());
            }
            return currentCredit + sumToAdd;
        }

        public static void Menu()
        {
            Console.WriteLine($"1. Black - just a simple coffe - Price: 1.8");
            Console.WriteLine($"2. Latte - steamed milk - Price: 2.3");
            Console.WriteLine($"3. Capuccino - espresso steamed milk and sugar - Price: 3.5");
            Console.WriteLine($"4. Americano - espresso hot water - Price: 2.8");
            Console.WriteLine($"5. Lungo - long coffee - Price: 3.2");
        }

        public static void OrderCoffee(Coffee coffeeToOrder,double currentCredit)
        {
            if (currentCredit >= coffeeToOrder.price)
            {
                Console.WriteLine("Starting the brewing procees...");
                Console.WriteLine(".....Please wait.....");
                Console.WriteLine($"{coffeeToOrder.coffeeType} is ready, ENJOY :)");
                //Coffee.PrintCoffeeData(coffeeToOrder);
                currentCredit = SubtractCredit(currentCredit, coffeeToOrder.price);
            }
            else
            {
                Console.WriteLine($"You don't have enough credit, you may add at least {coffeeToOrder.price - currentCredit}");
                currentCredit = AddCredit(currentCredit, Convert.ToDouble(Console.ReadLine()));
            }
        }

        public static double SubtractCredit(double credit, double price)
        {
            return credit - price; 
        }

        public static Coffee SelectCoffee()
        {
            int option = Convert.ToInt32(Console.ReadLine());

            switch(option)
            {
                case 1:
                    Coffee BlackCoffee = new Coffee(1, "Black", 1.8, 140, Convert.ToBoolean(0), Convert.ToBoolean(0), Convert.ToBoolean(0));
                    return BlackCoffee;
                    break;

                case 2:
                    Coffee LatteCoffee = new Coffee(2, "Latte", 2.3, 160, Convert.ToBoolean(0), Convert.ToBoolean(1), Convert.ToBoolean(0));
                    return LatteCoffee;
                    break;

                case 3:
                    Coffee CapuccinoCoffee = new Coffee(3, "Capuccino", 3.5, 225, Convert.ToBoolean(1), Convert.ToBoolean(1), Convert.ToBoolean(1));
                    return CapuccinoCoffee;
                    break;

                case 4:
                    Coffee AmericanoCoffee = new Coffee(4, "Americano", 2.8, 180, Convert.ToBoolean(0), Convert.ToBoolean(0), Convert.ToBoolean(1));
                    return AmericanoCoffee;
                    break;

                case 5:
                    Coffee LungoCoffee = new Coffee(5, "Lungo", 3.2, 260, Convert.ToBoolean(0), Convert.ToBoolean(0), Convert.ToBoolean(1));
                    return LungoCoffee;
                    break;

                default:
                    return null;
                    break;
            }
        }
    }
}
