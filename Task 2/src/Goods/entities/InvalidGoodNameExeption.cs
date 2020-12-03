using System;

namespace Goods.entities
{
    class InvalidGoodNameExeption: Exception
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
