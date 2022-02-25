using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using todoonboard_api.infoModels;

namespace todoonboard_api.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public virtual ICollection<BoardsUser> BoardsUser {get;set;}
        public User() {
        }

        public User(UserRequest userRequest) {
            this.FirstName = userRequest.FirstName;
            this.LastName = userRequest.LastName;
            this.Username = userRequest.Username;
            this.Password = userRequest.Password;
        }
    }
}