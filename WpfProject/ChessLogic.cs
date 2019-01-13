using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace WpfProject
{
    public static class ChessLogic
    {
        public static ObservableCollection<IBoardItem> InitialBoard()
        {
            ObservableCollection<IBoardItem> items = new ObservableCollection<IBoardItem>();
            List<char> columns = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h'};
            //Add board cells
            foreach(var c in columns)
            {
                for(int r = 1; r <= 8; ++r)
                {
                    items.Add(new BoardCell { Rank = r, File = c, ItemType = BoardItemType.Cell });
                }
            }
            //Add pawns
            foreach(var c in columns)
            {
                items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Pawn, Rank = 2, File = c });
                items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Pawn, Rank = 7, File = c });
            }
            //Add rooks
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 2, File = 'a' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 2, File = 'h' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 7, File = 'a' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 7, File = 'h' });

            //Add knights
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 2, File = 'b' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 2, File = 'g' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 7, File = 'b' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 7, File = 'g' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 2, File = 'c' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 2, File = 'f' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 7, File = 'c' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 7, File = 'f' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.King, Rank = 2, File = 'e' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Queen, Rank = 2, File = 'd' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.King, Rank = 7, File = 'e' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Queen, Rank = 7, File = 'd' });

            return items;
        }
    }
}
