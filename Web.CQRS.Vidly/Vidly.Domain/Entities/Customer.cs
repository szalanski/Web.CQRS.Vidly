using System;

namespace Vidly.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public Membership Membership { get; set; }
        public byte MembershipId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
    