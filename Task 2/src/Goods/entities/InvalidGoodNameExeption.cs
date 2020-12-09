using System;

namespace Goods.Entities
{
    /// <summary>
    /// Class for unequal goods names in add operation exeption.
    /// </summary>
    public class InvalidGoodNameExeption: Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public InvalidGoodNameExeption()
        { 
        }
        /// <summary>
        /// Constructor with exeption message.
        /// </summary>
        /// <param name="message">Exeption message,</param>
        public InvalidGoodNameExeption(string message): base(message)
        { 
        }
        /// <summary>
        /// Constructor with exeption message and inner exeption.
        /// </summary>
        /// <param name="message">Exeption message.</param>
        /// <param name="inner">Inner exeption.</param>
        public InvalidGoodNameExeption(string message, Exception inner)
        : base(message, inner)
        { 
        }
    }
}
