using System;

namespace Goods.entities
{
    class SellableGood: Good
    {
        public double Markup { get; }
        public SellableGood(string name, double basePrice, int count, double markup):base(name, basePrice, count)
        {
            Markup = markup;
        }
        public override double PriceForOne()
        {
            return base.PriceForOne() * Markup;
        }
        public override double Price()
        {
            return base.Price()*Markup;
        }
        public static Good ToGood(SellableGood b)
        {
            return new Good(b.Name, b.BasePrice, b.Count);
        }
        public static SellableGood ToSellableGood(Good b)
        {
            return new SellableGood(b.Name, b.BasePrice, b.Count, 1);
        }

        public static SellableGood operator +(SellableGood a, SellableGood b)
        {
            if (a.Name != b.Name)
            {
                throw new InvalidOperationException();
            }
            double basePrice = (a.BasePrice * a.Count + b.BasePrice * b.Count) / (a.Count + b.Count);
            double markup = (a.Markup * a.Count + b.Markup * b.Count) / (a.Count + b.Count);
            return new SellableGood(a.Name, basePrice, a.Count + b.Count, markup);
        }
        public static SellableGood operator -(SellableGood a, int b)
        {
            return new SellableGood(a.Name, a.BasePrice, a.Count - b, a.Markup);
        }
        public override string ToString()
        {
            return $"{base.ToString()};{Markup}";
        }
    }
}
