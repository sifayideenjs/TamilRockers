using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamilRockers.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display( Name = "Date of Birth")]
        [Min18IfAMember]
        public DateTime? Birthdate { get; set; }

        public virtual MembershipType MembershipType { get; set;  }
        public byte MembershipTypeId { get; set; }
    }
}
