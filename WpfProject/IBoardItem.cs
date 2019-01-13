namespace WpfProject
{
    public interface IBoardItem
    {
        int Rank { get; set; }
        char File { get; set; }

        BoardItemType ItemType { get; set; }
    }
}
