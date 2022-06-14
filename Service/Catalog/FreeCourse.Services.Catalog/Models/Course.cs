using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FreeCourse.Services.Catalog.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public string Price { get; set; }

        // Identity tarafında bu bir GuId olarak tutulacağı için bu değeri verdik.
        public string UserId { get; set; }

        public string Picture { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        // Mondo DB collectiona ekleme demek. O tarafta bir karşılığı yok.
        [BsonIgnore]
        public Category Category { get; set; }

        public Course()
        {
        }
    }
}
