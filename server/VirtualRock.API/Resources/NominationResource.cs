using System;
namespace VirtualRock.API.Resources
{
    public class NominationResource
    {
        public int Id { get; set; }
        public DateTime NominationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public UserResource User { get; set; }
    }
}
