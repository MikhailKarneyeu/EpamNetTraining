using System;

namespace Goods.Entities
{
    public class InvalidGoodNameExeption: Exception
    {
        public InvalidGoodNameExeption()
        { 
        }
        public InvalidGoodNameExeption(string message): base(message)
        { 
        }
        public InvalidGoodNameExeption(string message, Exception inner)
        : base(message, inner)
        { 
        }
    }
}
