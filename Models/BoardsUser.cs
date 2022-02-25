using todoonboard_api.infoModels;

namespace todoonboard_api.Models{
    public class BoardsUser
{
    public int BoardsId { get; set; }
    public Boards Boards { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public BoardsUser(){
        
    }
    public BoardsUser(UserBoardRequest req){
        this.BoardsId = req.bid;
        this.UserId = req.uid;
    }
}
}