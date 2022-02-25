using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace todoonboard_api.Models{
    public class Boards{
        [Key]
        public int id {get; set;}
        public string BoardName {get; set;}
        [JsonIgnore]
        public virtual ICollection<BoardsUser> BoardsUser {get;set;}

        public Boards(){

        }
        public Boards(Boards item){
            this.BoardName = item.BoardName;
            this.id = item.id;
        }

    }
}