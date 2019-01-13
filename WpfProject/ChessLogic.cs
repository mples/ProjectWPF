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
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 1, File = 'a' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 1, File = 'h' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 8, File = 'a' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 8, File = 'h' });

            //Add knights
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 1, File = 'b' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 1, File = 'g' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 8, File = 'b' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 8, File = 'g' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 1, File = 'c' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 1, File = 'f' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 8, File = 'c' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 8, File = 'f' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.King, Rank = 1, File = 'e' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Queen, Rank = 1, File = 'd' });

            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.King, Rank = 8, File = 'e' });
            items.Add(new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Queen, Rank = 8, File = 'd' });

            return items;
        }
    }
}
