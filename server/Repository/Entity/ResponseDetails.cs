using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entity
{
    public class ResponseDetails
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Response { get; set; }
        public int Identified_number { get; set; }
        public int Reported_number { get; set; }
        public int StoryId { get; set; }
        [ForeignKey ("StoryId")]
        [NotMapped]
        public virtual ResponseDetails responseDetailes {  get; set; }
        
    }
}
