using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class ResponseDetailsDto
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Response { get; set; }
        public int Identified_number { get; set; }
        public int Reported_number { get; set; }
       public int StoryId { get; set; }
    }
}
