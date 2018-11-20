using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.IO;


namespace DataAcess
{
    public class MongoHelper
    {
        public MongoHelper()
        {

        }
        private static MongoClient Client => new MongoClient("192.168.99.100:32768");
        private IMongoDatabase campus_net => Client.GetDatabase("campus_net");
        public IMongoCollection<BsonDocument> Posts => campus_net.GetCollection<BsonDocument>("posts");
        public IMongoCollection<BsonDocument> Questions => campus_net.GetCollection<BsonDocument>("questions");
        public IMongoCollection<BsonDocument> Users => campus_net.GetCollection<BsonDocument>("users");

    }
}
