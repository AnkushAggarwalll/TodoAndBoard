using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace todoonboard_api.infoModels{
    public class TodoRequest{
        public int id {get; set;}
        public string title {get; set;}
        public bool done {get; set;}
        public DateTime? createdAt {get; set;}
        public DateTime? updatedAt {get; set;}
        public int bid {get; set;}

        // [ForeignKey("bid")]
        // [JsonIgnore]
        // public virtual Boards Boards {get; set;}

    }
}