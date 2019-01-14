using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfProject
{
    public class ChessTableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ChessLogic Chess;
        public ChessTableViewModel(ChessLogic chess)
        {
            BoardItems = chess.BoardItems;
            Chess = chess;
        }
        private ObservableCollection<IBoardItem> boardItems;

        public ObservableCollection<IBoardItem> BoardItems
        {
            get { return boardItems; }
            set
            {
                boardItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(BoardItems)));
            }
        }

        public ChessColor CurrentColor
        {
            get { return Chess.CurrentPlayerColor; }
        }

        private Piece selectedPiece;
        private Piece targetPiece;
        private BoardCell moveCell;

        public IBoardItem SeletedBoardItem
        {
            set
            {
                Console.WriteLine("curr color:" + CurrentColor);
                if (value is Piece)
                {
                    Piece piece = (Piece)value;
                    if(piece.Color == CurrentColor)
                    {
                        selectedPiece = piece;
                        Console.WriteLine("selected piece" + CurrentColor);
                    }
                    else
                    {
                        targetPiece = piece;
                        Console.WriteLine("selected piece target");
                    }
                }
                else if (value is BoardCell)
                {
                    moveCell = (BoardCell)value;
                    Console.WriteLine("selected cell");
                    Chess.move(selectedPiece, moveCell);
                    
                }
            }
        }
    }
}
