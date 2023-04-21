namespace FoodProgram
{
    public static class FoodHelpers
    {
        public static FoodOptions AddFoodToOrder(this FoodOptions order, int response)
        {
            var newOrder = order;
            switch(response)
            {
                case 1:
                    newOrder.HotDog++;
                    break;
                case 2:
                    newOrder.Brat++;
                    break;
                case 3:
                    newOrder.Hamburger++;
                    break;
                case 4:
                    newOrder.Fries++;
                    break;
                case 5:
                    newOrder.Soda++;
                    break;
                case 6:
                    newOrder.Water++;
                    break;
            }
            return newOrder;
        }
    }
}
