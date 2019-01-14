using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfProject
{
    public class ChessTableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ChessGame Chess;
        public ChessTableViewModel(ChessGame chess)
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
                if (value is Piece)
                {
                    Piece piece = (Piece)value;
                    if(piece.Color == CurrentColor)
                    {
                        selectedPiece = piece;
                    }
                    else if (piece.Color != CurrentColor && selectedPiece != null)
                    {
                        targetPiece = piece;
                        Chess.move(selectedPiece, targetPiece);
                    }
                }
                else if (value is BoardCell && selectedPiece != null && selectedPiece.Color == CurrentColor)
                {
                    moveCell = (BoardCell)value;
                    Chess.move(selectedPiece, moveCell);
                    
                }
            }
        }
    }
}
