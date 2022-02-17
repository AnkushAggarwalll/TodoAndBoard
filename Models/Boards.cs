using System.Collections.Generic;
using todoonboard_api.Models;
using System.ComponentModel.DataAnnotations;

namespace todoonboard_api.Models{
    public class Boards{
        [Key]
        public int id {get; set;}
        public string BoardName {get; set;}
    }
}