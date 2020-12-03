using System;

namespace Goods.entities
{
    class Good: IConvertible
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
        public TypeCode GetTypeCode()
        {
            throw new InvalidCastException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return (decimal)Price();
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Price();
        }

        public short ToInt16(IFormatProvider provider)
        {
            return (short)(Price() * 100);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return (int)(Price() * 100);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return (long)(Price() * 100);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            return (float)Price();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return (ushort)(Price() * 100);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return (uint)(Price() * 100);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)(Price() * 100);
        }
        public static Good operator +(Good a, Good b)
        {
            if(a.Name!= b.Name)
            {
                throw new InvalidGoodNameExeption($"Good 1 name:{a.Name}. Good 2 name:{b.Name}.");
            }
            double basePrice = (a.BasePrice*a.Count+b.BasePrice*b.BasePrice) / (a.Count+b.Count);
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
            if(ToString()!= obj.ToString())
            {
                return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
