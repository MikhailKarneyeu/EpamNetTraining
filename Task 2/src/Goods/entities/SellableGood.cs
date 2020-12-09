using System;

namespace Goods.Entities
{
    /// <summary>
    /// Class for good with markup.
    /// </summary>
    public class SellableGood: Good
    {
        /// <summary>
        /// Good markup.
        /// </summary>
        public double Markup { get; }
        /// <summary>
        /// Costructor for sellable good.
        /// </summary>
        /// <param name="name">Good name.</param>
        /// <param name="basePrice">Good purchase price.</param>
        /// <param name="count">Good count.</param>
        /// <param name="markup">Good markup.</param>
        public SellableGood(string name, double basePrice, int count, double markup):base(name, basePrice, count)
        {
            Markup = markup;
        }
        /// <summary>
        /// Method to get price for one good.
        /// </summary>
        /// <returns>Price for one good in double type.</returns>
        public override double PriceForOne()
        {
            return base.PriceForOne() * Markup;
        }
        /// <summary>
        /// Method to get full price for this count of good.
        /// </summary>
        /// <returns>Full price in double type.</returns>
        public override double Price()
        {
            return base.Price()*Markup;
        }
        /// <summary>
        /// Method to convert sellable good to good.
        /// </summary>
        /// <param name="b">Sellable good.</param>
        /// <returns>The resulting good.</returns>
        public static Good ToGood(SellableGood b)
        {
            return new Good(b.Name, b.BasePrice, b.Count);
        }
        /// <summary>
        /// Method to convert good to sellable good.
        /// </summary>
        /// <param name="b">Good to convert.</param>
        /// <returns>The resulting sellable good.</returns>
        public static SellableGood ToSellableGood(Good b)
        {
            return new SellableGood(b.Name, b.BasePrice, b.Count, 1);
        }
        /// <summary>
        /// Operator to summ 2 sellable goods.
        /// </summary>
        /// <param name="a">First good.</param>
        /// <param name="b">Second good.</param>
        /// <returns>Sellable good with weighted average base price, markup and goods count summ.</returns>
        public static SellableGood operator +(SellableGood a, SellableGood b)
        {
            if (a.Name != b.Name)
            {
                throw new InvalidGoodNameExeption($"Good 1 name:{a.Name}. Good 2 name:{b.Name}.");
            }
            double basePrice = (a.BasePrice * a.Count + b.BasePrice * b.Count) / (a.Count + b.Count);
            double markup = (a.Markup * a.Count + b.Markup * b.Count) / (a.Count + b.Count);
            return new SellableGood(a.Name, basePrice, a.Count + b.Count, markup);
        }
        /// <summary>
        /// Operator to subtract integer from sellable good.
        /// </summary>
        /// <param name="a">Sellable good to subtract from.</param>
        /// <param name="b">Interger to subtract.</param>
        /// <returns>Sellable good with decreased count.</returns>
        public static SellableGood operator -(SellableGood a, int b)
        {
            return new SellableGood(a.Name, a.BasePrice, a.Count - b, a.Markup);
        }
        /// <summary>
        /// Ovveride method to convert sellable good to string.
        /// </summary>
        /// <returns>String "good name;base price;count;price for one; full price;markup"</returns>
        public override string ToString()
        {
            return $"{base.ToString()};{Markup}";
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
            if (obj.GetType() != this.GetType())
                return false;
            var item = obj as SellableGood;
            if (item.Name == Name && item.BasePrice == BasePrice && item.Count == Count && item.Markup == Markup)
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
