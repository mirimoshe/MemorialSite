using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class StoryDetailesDto
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
        public int? DeceasdId { get; set; }

    }
}
