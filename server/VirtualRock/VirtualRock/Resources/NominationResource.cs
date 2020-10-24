using System;
namespace VirtualRock.Resources
{
    public class NominationResource
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime NominationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public UserResource User { get; set; }
    }
}
