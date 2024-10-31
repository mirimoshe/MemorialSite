using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class StoryDetailes
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Relation_type { get; set; }
        public string Story { get; set; }
        public string Email_for_messages { get; set; }
        public int Likes_number { get; set; }
        public int Reported_number { get; set; }

        public int Favorite_number { get; set; }
        public int Empowering_number { get; set; }
        public int Exciting_number { get; set; }
        public int Heroism_number { get; set; }
        public int Thanksgiving_number { get; set; }

        
        public int DeceasdId { get; set; }
        [ForeignKey("DeceasdId")]
        [NotMapped]
        public virtual DeceasdDetails DeceasdDetails { get; set; }
        [NotMapped]
        public virtual ICollection<ResponseDetails> responses { get; set; }
        
    } 
}
