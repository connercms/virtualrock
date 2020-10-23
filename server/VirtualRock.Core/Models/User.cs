using System.Collections.Generic;

namespace VirtualRock.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string SlackId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Nomination> Nominations { get; set; }
    }
}
