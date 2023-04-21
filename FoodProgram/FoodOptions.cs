namespace FoodProgram
{
    public class FoodOptions
    {
        public int HotDog { get; set; } = 0;
        public int Brat { get; set; } = 0;
        public int Hamburger { get; set; } = 0;
        public int Fries { get; set; } = 0;
        public int Soda { get; set; } = 0;
        public int Water { get; set; } = 0;

        public double AmountTotal()
        {
            var total = 0.00;
            total += HotDog * 2.50;
            total += Brat * 3.50;
            total += Hamburger * 5.00;
            total += Fries * 2.00;
            total += Soda * 2.00;
            return total;
        } 

        public int TotalItems()
        {
            var total = 0;
            total += HotDog;
            total += Brat;
            total += Hamburger;
            total += Fries;
            total += Soda;
            total += Water;
            return total;
        }

        override public string ToString()
        {
            var result = string.Empty;
            result += $"Hot Dogs: {HotDog}\n";
            result += $"Brats: {Brat}\n";
            result += $"Hamburgers: {Hamburger}\n";
            result += $"Fires: {Fries}\n";
            result += $"Sodas: {Soda}\n";
            result += $"Waters: {Water}\n";
            return result;
        }
    }
}
