using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace todoonboard_api.Models{
    public class Boards{
        [Key]
        public int id {get; set;}
        public string BoardName {get; set;}
    }
}