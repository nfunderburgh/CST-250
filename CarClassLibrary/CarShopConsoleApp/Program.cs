using CarClassLibrary;
using System;


namespace CarShopConsoleApp
{
    public class Program
    {

        static Store CarStore = new Store(); 
        static void Main(string[] args)
        {
            Console.Out.WriteLine("Welcome to the car store. First you must create some " +
                "cars and put them into the store inventory. Then you may add cars to the cart." +
                " Finally, you may checkout, which will calculate your total bill.");
            int action = chooseAction();
            while(action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.Out.WriteLine("You chose to add a new car to the store:");

                        String carMake = "";
                        String carModel = "";
                        decimal carPrice = 0;
                        string carColor = "";
                        int carYear = 0;

                        Console.Out.WriteLine("What is the car make? Ford, GM, Toyota, etc");
                        carMake = Console.ReadLine();

                        Console.Out.WriteLine("What is the car model? Corvette, Focus, Ranger ");
                        carModel = Console.ReadLine();

                        Boolean correctType = false;
                        while(correctType == false)
                        {
                            Console.Out.WriteLine("What is the car price? Only numbers please ");
                            try
                            {
                                carPrice = decimal.Parse(Console.ReadLine());
                                correctType = true;
                            }
                            catch
                            {
                                correctType = false;
                            }
                        }

                        Console.Out.WriteLine("What is the car color? Red, Blue, Yellow ");
                        carColor = Console.ReadLine();

                        correctType = false;
                        while (correctType == false)
                        {
                            Console.Out.WriteLine("What is the car year? Only numbers please ");
                            try
                            {
                                carYear = int.Parse(Console.ReadLine());
                                correctType = true;
                            }
                            catch
                            {
                                correctType = false;
                            }
                        }

                        Car newCar = new Car();
                        newCar.Make = carMake;
                        newCar.Model = carModel;
                        newCar.Price = carPrice;
                        newCar.Color = carColor;
                        newCar.Year = carYear;
                        CarStore.CarList.Add(newCar);
                        printStoreInventory(CarStore);
                        break;
                    case 2:
                        printStoreInventory(CarStore);
                        int choice = 0;
                        Console.Out.Write("Which car would you like to add to the cart? (number) ");
                        choice = int.Parse(Console.ReadLine());
                        CarStore.ShoppingList.Add(CarStore.CarList[choice]);
                        printShoppingCart(CarStore);
                        break;
                    case 3:
                        printShoppingCart(CarStore);
                        Console.Out.WriteLine("Your total cost is ${0}", CarStore.checkout());
                        break;
                    default:
                        break;
                }
                action = chooseAction();
            }
        }

        static public int chooseAction()
        {
            int choice = 0;
            Console.Out.WriteLine("Choose an action (0) quit (1) add a car (2) add item to cart (3) checkout");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }

        static public void printStoreInventory(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in the store inventory:");
            int i = 0;
            foreach(var item in carStore.CarList)
            {
                Console.Out.WriteLine(String.Format("Car # = {0} {1} ", i, item.Display));
                i++;
            }
        }

        static public void printShoppingCart(Store carStore)
        {
            Console.Out.WriteLine("These are the cars in your shopping cart:");
            int i = 0;
            foreach (var item in carStore.ShoppingList)
            {
                Console.Out.WriteLine(String.Format("Car # = {0} {1} ", i, item.Display));
                i++;
            }
        }
    }

}