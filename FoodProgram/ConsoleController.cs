namespace FoodProgram
{
    public class ConsoleController
    {
        static void Main(string[] args)
        {
            FoodOptions order = new FoodOptions();
            order = MainMenu(order);
        }
        private static FoodOptions MainMenu(FoodOptions order)
        {
            Console.Clear();
            Console.WriteLine(Const.MENU);
            var response = ReadLine();
            if (response > 1 && response < 7) { return order.AddFoodToOrder(response); }
            HandleConsoleChoices(order, response);
            return order;
        }

        private static void HandleConsoleChoices(FoodOptions order, int response)
        {
            Console.Clear();
            switch(response)
            {
                case 7:
                    Console.WriteLine(order.ToString());
                    var total = order.AmountTotal;
                    Console.WriteLine($"\nTotal: ${total}");
                    break;
                case 8:
                    Console.WriteLine("Order cleared!");
                    order = new FoodOptions();
                    break;
                case 9:
                    Console.WriteLine("Thank you! Goodbye!");
                    Environment.Exit(0);
                    break;
            }
        }

        private static int ReadLine()
        {
            try
            {
                var response = Int32.Parse(Console.ReadLine().ToLower().Trim());
                if (response < 1 || response > 9) { throw new Exception(); }
                return response;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Sorry that was an invalid response.\n");
                Console.WriteLine(Const.MENU);
                return ReadLine();
            }
        }
    }
}
