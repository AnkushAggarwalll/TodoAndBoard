using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using todoonboard_api.infoModels;

namespace todoonboard_api.Models{
    public class Todo{
        public int id {get; set;}
        public string title {get; set;}
        public bool done {get; set;}
        public DateTime createdAt {get; set;}
        public DateTime updatedAt {get; set;}
        public int bid {get; set;}

        [ForeignKey("bid")]
        [JsonIgnore]
        public virtual Boards Boards {get; set;}
        public Todo(){
            
        }
        public Todo (TodoRequest newTodo){
            this.title = newTodo.title;
            this.done = newTodo.done;
            this.createdAt = (DateTime)(newTodo.createdAt==null? DateTime.Now:newTodo.createdAt);
            this.updatedAt = (DateTime)(newTodo.updatedAt==null? DateTime.Now:newTodo.updatedAt);
            this.bid = newTodo.bid;
        }
    }
}