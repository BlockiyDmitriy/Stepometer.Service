namespace Service.BLL.Models
{
    public class FriendsModel
    {
        //My account
        public int AccId1 { get; set; }

        public AccModel Acc1 { get; set; }

        //Friend account
        public int AccId2 { get; set; }
        public AccModel Acc2 { get; set; }
    }
}