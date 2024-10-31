using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Repository.Entity
{
    public class DeceasdDetails
    {
        
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime? Birth_date { get; set; }
        public DateTime? Death_date { get; set; }
        public string? Hometown { get; set; }
        public string? Burial_location { get; set; }
        public int Age { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<UserDetailes> users { get; set; }
        
        public List<string>? Images { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<string>? ImagesUrl { get; set; }
        public string Death_detailes { get; set; }
        public string? Rank { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<StoryDetailes> Stories { get; set; }
        
        public string? Unit { get; set; }

        
        public int UserId {  get; set; }
        [ForeignKey("UserId")]
        [NotMapped]
        [JsonIgnore]
        public virtual UserDetailes User { get; set; }
        
    }
}
