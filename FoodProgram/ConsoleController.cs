namespace FoodProgram
{
    public class ConsoleController
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            Order order = new Order() { Id = 1 };
            var newOrder = order;
            while (true)
            {
                newOrder = MainMenu(newOrder);
                if(newOrder == null) { break; }
                if(orders.Find(item => item.Id == newOrder.Id) == null) { orders.Add(newOrder); }
            }
            orders.FindAll(item => item.AmountTotal() == 0).ForEach(item => orders.Remove(item));
            orders.ForEach(item => Console.WriteLine(item.Id));
        }

        private static Order MainMenu(Order order)
        {
            Console.Clear();
            Console.WriteLine($"Order: {order.Id}\n");
            Console.WriteLine(Const.MENU);
            var response = ReadLine();
            if (response > 0 && response < 7) { return ConsoleAddFoodToOrder(order, response); }
            return HandleConsoleChoices(order, response);
        }

        private static Order ConsoleAddFoodToOrder(Order order, int response) 
        {
            var updatedOrder = order;
            Console.WriteLine("How many would you like to buy?");
            var numOfItems = ReadInteger(Console.ReadLine());
            for(int i = 0; i < numOfItems; i++)
            {
                updatedOrder = updatedOrder.AddFoodToOrder(response);
            }
            return updatedOrder;
        }
        
        private static Order HandleConsoleChoices(Order order, int response)
        {
            Console.Clear();
            Order addOrder = order;
            switch(response)
            {
                case 7:
                    Console.WriteLine(order.ToString());
                    var total = order.AmountTotal();
                    Console.WriteLine($"Total: ${total}");
                    addOrder = ConsoleNewOrder(order);
                    break;
                case 8:
                    Console.WriteLine("Order cleared!");
                    addOrder.ResetOrder();
                    break;
                case 9:
                    Console.WriteLine("Thank you! Goodbye!");
                    return null;
            }
            Console.WriteLine("\nHit Enter to continue.");
            Console.ReadLine();
            return addOrder;
        }

        private static Order ConsoleNewOrder(Order currentOrder)
        {
            Console.WriteLine("\n\nWould you like to start a new order? (y/n)");
            var response = Console.ReadLine().ToLower().Trim();
            if(!response.Equals("y") && !response.Equals("n")) { Console.WriteLine("Not a valid response!"); return ConsoleNewOrder(currentOrder); }
            if(response.Equals("y"))
            {
                Console.WriteLine("Thank you for your order!");
                var id = currentOrder.Id + 1;
                return new Order() { Id = id };
            }
            return currentOrder;
        }

        private static int ReadInteger(string input)
        {
            input = input.ToLower().Trim();
            try
            {
                int num = Int32.Parse(input);
                if (num < 0) { throw new Exception(); }
                return num;
            }
            catch
            {
                Console.WriteLine("Sorry that was an invalid response.\n");
                return ReadInteger(Console.ReadLine());
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
