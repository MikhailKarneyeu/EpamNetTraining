using Goods.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Goods.Services
{
    public class GoodFileOperator
    {
        public static List<Good> ReadAll(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            var goods = JsonConvert.DeserializeObject<List<Good>>(json, settings);
            return goods;
        }
        public static void WriteAll(string filePath, List<Good> goods)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
            string json = JsonConvert.SerializeObject(goods.ToArray(), settings);
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
