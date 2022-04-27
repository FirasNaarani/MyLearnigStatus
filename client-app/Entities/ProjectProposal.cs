using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LearnSchoolApp.Entities
{
    public class ProjectProposal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string projectId { get; set; }
        
        [BindProperty]
        public IFormFile proposalPdf { get; set; }

        public byte[] File { get; set; }

        public string proposalPdfUrl { get; set; }

        public bool isPass { get; set; }
    }
}
