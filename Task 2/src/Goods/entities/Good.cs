using System;

namespace Goods.Entities
{
    /// <summary>
    /// Class representing good.
    /// </summary>
    public class Good
    {
        /// <summary>
        /// Good name.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Good purchase price.
        /// </summary>
        public double BasePrice { get; }
        /// <summary>
        /// Good count.
        /// </summary>
        public int Count { get; }
        /// <summary>
        /// Good constructor.
        /// </summary>
        /// <param name="name">Good name.</param>
        /// <param name="basePrice">Good purchase price.</param>
        /// <param name="count">Good count.</param>
        public Good(string name, double basePrice, int count)
        {
            Name = name;
            BasePrice = basePrice;
            Count = count;
        }
        /// <summary>
        /// Method to get price for one good.
        /// </summary>
        /// <returns>Price for one good in double type.</returns>
        public virtual double PriceForOne()
        {
            return BasePrice;
        }
        /// <summary>
        /// Method to get full price for this count of good.
        /// </summary>
        /// <returns>Full price in double type.</returns>
        public virtual double Price()
        {
            return BasePrice * Count;
        }
        /// <summary>
        /// Method to convert good to double.
        /// </summary>
        /// <returns>Full price on double type.</returns>
        public double ToDouble()
        {
            return Price();
        }
        /// <summary>
        /// Method to convert good ti int;
        /// </summary>
        /// <returns>Full price in kopeks.</returns>
        public int ToInt()
        {
            return (int)(Price() * 100);
        }
        /// <summary>
        /// Operator to summ 2 goods.
        /// </summary>
        /// <param name="a">First good.</param>
        /// <param name="b">Second good.</param>
        /// <returns>Good with weighted average base price and goods count summ.</returns>
        public static Good operator +(Good a, Good b)
        {
            if(a.Name!= b.Name)
            {
                throw new InvalidGoodNameExeption($"Good 1 name:{a.Name}. Good 2 name:{b.Name}.");
            }
            double basePrice = (a.BasePrice*a.Count+b.BasePrice*b.Count) / (a.Count+b.Count);
            return new Good(a.Name, basePrice, a.Count+b.Count);
        }
        /// <summary>
        /// Operator to subtract integer from good.
        /// </summary>
        /// <param name="a">Good to subtract from.</param>
        /// <param name="b">Interger to subtract.</param>
        /// <returns>Good with decreased count.</returns>
        public static Good operator -(Good a, int b)
        {
            return new Good(a.Name, a.BasePrice, a.Count - b);
        }
        /// <summary>
        /// Ovveride method to convert good to string.
        /// </summary>
        /// <returns>String "good name;base price;count;price for one; full price"</returns>
        public override string ToString()
        {
            return $"{Name};{BasePrice};{Count};{PriceForOne()};{Price()}";
        }
        /// <summary>
        /// Method to compare two goods.
        /// </summary>
        /// <param name="obj">Good to compare.</param>
        /// <returns>Boolean result of the comparison.</returns>
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
        /// <summary>
        /// Method to get hash code of good.
        /// </summary>
        /// <returns>Integer hash code.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
