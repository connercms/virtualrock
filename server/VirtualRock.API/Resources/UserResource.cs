using System;
namespace VirtualRock.API.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string SlackId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
