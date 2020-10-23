using System;

namespace VirtualRock.Core.Models
{
    public class Nomination
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime NominationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
