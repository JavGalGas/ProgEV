using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongodemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoClient mongoClient  = new MongoClient("mongodb+srv://javgalgas:1234@cluster0.mw9t4dc.mongodb.net/");
            var database = mongoClient.GetDatabase("mongodemo");
            var collection = database.GetCollection<BsonDocument>("oficinas");

            var filter = Builders<BsonDocument>.Filter.Eq("ciudad", "Valencia");

            var oficina = collection.Find(filter).FirstOrDefault();

            //Oficina oficinaVal = BsonSerializer.Deserialize<Oficina>(oficina);
            //StringBuilder stringBuilder = new StringBuilder();
            //stringBuilder.Append(oficinaVal.CodOficina);
            //stringBuilder.Append(" - ");
            //stringBuilder.Append(oficinaVal.Ciudad);
            //stringBuilder.Append(" - ");

            //Console.WriteLine(stringBuilder);
            //Console.ReadLine();
            /*
            Oficina newOficina = new Oficina();
            newOficina.CodOficina = "ALI-ES";
            newOficina.Ciudad = "Alicante";
            newOficina.Pais = "España";
            newOficina.CodPostal = "20001";
            newOficina.Telefono = "123456789";


            collection.InsertOne(newOficina.ToBsonDocument());
            */

            var filter2 = Builders<BsonDocument>.Filter.Eq("codOficina", "VAL-ES");

            //collection.DeleteMany(filter2);

            UpdateDefinition<BsonDocument> ud = Builders<BsonDocument>.Update.Set("ciudad", "Valencia");

            collection.UpdateOne(filter2, ud);
        }
    }
}
