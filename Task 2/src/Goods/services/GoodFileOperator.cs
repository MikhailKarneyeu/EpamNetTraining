using Goods.entities;
using System.Collections.Generic;

namespace Goods.services
{
    class GoodFileOperator
    {
        public static List<Good> ReadAll(string filePath)
        {
            string json = System.IO.File.ReadAllText(filePath);
            var goods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Good>>(json);
            return goods;
        }
        public static void WriteAll(string filePath, List<Good> goods)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(goods.ToArray());
            System.IO.File.WriteAllText(filePath, json);
        }
    }
}
