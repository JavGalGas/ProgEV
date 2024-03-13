namespace Classes
{
    public class Jar
    {
        private double capacity=0; //Cuanto liquido cabe
        private double quantity=0; //Cuanto espacio sobra

        public double SetQuantity(double value)
        {
            if (value < 0)
                return quantity = 0;
            else if (value > capacity)
                return quantity = capacity;
            return quantity = value;
        }

        public double GetQuantity()
        {
            return quantity;
        }

        public double SetCapacity(double value)
        {
            if (value < 0)
                return capacity;
            else if (value < quantity)
                return quantity = capacity;
            return capacity=value;
        }

        public double GetCapacity()
        {
            return capacity;
        }

        public double GetPercentage()
        {
            return quantity/capacity;
        }

        public double GetRemain()
        {
            return capacity-quantity;
        }

        public double AddQuantity(double value)
        {
            return SetQuantity(quantity += value);
        }
    }
}
