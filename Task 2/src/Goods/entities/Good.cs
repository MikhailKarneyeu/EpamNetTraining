using System;

namespace Goods.Entities
{
    public class Good
    {
        public string Name { get;}
        public double BasePrice { get; }
        public int Count { get; }
        public Good(string name, double basePrice, int count)
        {
            Name = name;
            BasePrice = basePrice;
            Count = count;
        }
        public virtual double PriceForOne()
        {
            return BasePrice;
        }
        public virtual double Price()
        {
            return BasePrice * Count;
        }

        public double ToDouble()
        {
            return Price();
        }

        public int ToInt()
        {
            return (int)(Price() * 100);
        }

        public static Good operator +(Good a, Good b)
        {
            if(a.Name!= b.Name)
            {
                throw new InvalidGoodNameExeption($"Good 1 name:{a.Name}. Good 2 name:{b.Name}.");
            }
            double basePrice = (a.BasePrice*a.Count+b.BasePrice*b.Count) / (a.Count+b.Count);
            return new Good(a.Name, basePrice, a.Count+b.Count);
        }
        public static Good operator -(Good a, int b)
        {
            return new Good(a.Name, a.BasePrice, a.Count - b);
        }
        public override string ToString()
        {
            return $"{Name};{BasePrice};{Count};{PriceForOne()};{Price()};";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            var item = obj as Good;
            if (item.Name == Name && item.BasePrice == BasePrice && item.Count == Count)
            {
                return true;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
