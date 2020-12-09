using Goods.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Goods.Services
{
    /// <summary>
    /// Class for operations with xml files.
    /// </summary>
    public class GoodFileOperator
    {
        /// <summary>
        /// Method to get list of goods from xml file.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <returns>List of goods.</returns>
        public static List<Good> ReadAll(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var goods = JsonConvert.DeserializeObject<List<Good>>(json, settings);
            return goods;
        }
        /// <summary>
        /// Method to save good list to xml file.
        /// </summary>
        /// <param name="filePath">Path to file.</param>
        /// <param name="goods">Good list to save.</param>
        public static void WriteAll(string filePath, List<Good> goods)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(goods.ToArray(), settings);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
