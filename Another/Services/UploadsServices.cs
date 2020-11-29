using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;
using Another.Models;

namespace Another.Services
{
    public class UploadsServices
    {
        private readonly IMongoCollection<Uploads> _uploads;

        public UploadsServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _uploads = database.GetCollection<Uploads>("Uploads");
        }

        public Uploads Create(Uploads uploads)
        {
            _uploads.InsertOne(uploads);
            return uploads;
        }

        public IList<Uploads> Read() => _uploads.Find(up => true).ToList();
        public Uploads Find(string id) => _uploads.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Uploads uploads) => _uploads.ReplaceOne(sub => sub.Id == uploads.Id, uploads);
        public void Delete(string id) => _uploads.DeleteOne(sub => sub.Id == id);
    }
}
