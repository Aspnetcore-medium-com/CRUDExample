using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    /// <summary>
    /// Represents an individual with personal and contact information.
    /// </summary>
    /// <remarks>The <see cref="Person"/> class encapsulates details such as name, email, date of birth,
    /// gender, address, and preferences for receiving newsletters. It can be used to store or transfer user profile
    /// data within applications.</remarks>
    public class Person
    {
        public Guid PersonId { get; set; }
        public string PersonName { get; set; } = string.Empty;

        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public String? Gender { get; set; }

        public Guid? CountryId { get; set; }

        public string? Address { get; set; }
        public bool ReceiveNewsLetters { get; set; }
    }
}
