using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class UserDetailes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Id_person { get; set; }
        public string Email { get; set; }
        public int Amount_stories { get; set; }
        [NotMapped]
        public virtual ICollection<DeceasdDetails> deceasdaddedBy { get; set; }
        [NotMapped]
        public virtual ICollection<DeceasdDetails> Receiving_messages { get; set; }
        

    }
}
