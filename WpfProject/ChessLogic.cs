using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace WpfProject
{
    public class ChessLogic
    {
        public ChessLogic()
        {
            chessBoard = new Piece[8,8];
            InitBoard();
            currentPlayerColor = ChessColor.White;
        }
        private Piece[,] chessBoard;

        private ObservableCollection<IBoardItem> boardItems;

        public ObservableCollection<IBoardItem> BoardItems
        {
            get { return boardItems; }
        }

        private ChessColor currentPlayerColor;

        public ChessColor CurrentPlayerColor
        {
            get { return currentPlayerColor; }
        }
        public void InitBoard()
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
                Piece newPiece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Pawn, Rank = 2, File = c };
                items.Add(newPiece);
                addToChessBoard(newPiece);
                newPiece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Pawn, Rank = 7, File = c };
                items.Add(newPiece);
                addToChessBoard(newPiece);
            }
            //Add rooks
            Piece piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 1, File = 'a' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Rook, Rank = 1, File = 'h' };
            items.Add(piece);
            addToChessBoard(piece);

            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 8, File = 'a' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Rook, Rank = 8, File = 'h' };
            items.Add(piece);
            addToChessBoard(piece);

            //Add knights
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 8, File = 'b' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Knight, Rank = 8, File = 'g' };
            items.Add(piece);
            addToChessBoard(piece);

            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 1, File = 'b' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Knight, Rank = 1, File = 'g' };
            items.Add(piece);
            addToChessBoard(piece);

            //Add bishops
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 8, File = 'c' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Bishop, Rank = 8, File = 'f' };
            items.Add(piece);
            addToChessBoard(piece);

            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 1, File = 'c' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Bishop, Rank = 1, File = 'f' };
            items.Add(piece);
            addToChessBoard(piece);
            //Add royal
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.Queen, Rank = 8, File = 'd' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.Black, Figure = ChessFigure.King, Rank = 8, File = 'e' };
            items.Add(piece);
            addToChessBoard(piece);

            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.Queen, Rank = 1, File = 'd' };
            addToChessBoard(piece);
            items.Add(piece);
            piece = new Piece { ItemType = BoardItemType.Piece, Color = ChessColor.White, Figure = ChessFigure.King, Rank = 1, File = 'e' };
            items.Add(piece);
            addToChessBoard(piece);

            boardItems = items;
        }

        public void move(Piece piece, BoardCell cell)
        {
            List<Pair> possibleMoves = getMoves(piece);

            Pair cell_coord = new Pair(fileToColumn(cell.File), rankToRow(cell.Rank));

            if (possibleMoves.Contains(cell_coord))
            {
                chessBoard[fileToColumn(piece.File), rankToRow(piece.Rank)] = null;
                chessBoard[fileToColumn(cell.File), rankToRow(cell.Rank)] = piece;
                piece.Rank = cell.Rank;
                piece.File = cell.File;
                swapPlayerColor();

            }
        }

        private Pair getCoord(IBoardItem item)
        {
            return new Pair(fileToColumn(item.File), rankToRow(item.Rank));
        }
        private void swapPlayerColor()
        {
            if (currentPlayerColor == ChessColor.White)
                currentPlayerColor = ChessColor.Black;
            else
                currentPlayerColor = ChessColor.White;
        }

        private int rankToRow(int rank)
        {
            return 8 - rank;
        }
        private int rowToRank(int row)
        {
            return 8 - row;
        }
        private int fileToColumn(char file)
        {
            List<char> columns = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            return columns.IndexOf(file);
        }
        private char columnToFile(int column)
        {
            List<char> columns = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
            return columns[column];
        }

        private void addToChessBoard(Piece piece)
        {
            chessBoard[fileToColumn(piece.File),rankToRow(piece.Rank)] = piece;
        }

        #region Calculatin Possible Moves
        private bool isValidBoardCoord(Pair point)
        {
            return (point.X >= 0 && point.X < 8 && point.Y >= 0 && point.Y < 8);
        }

        private List<Pair> getMovesE(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) );
            
            while(isValidBoardCoord(coord))
            {
                if(chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if(piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X += 1;
            }

            return moves;
        }

  
        private List<Pair> getMovesW(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank));

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X -= 1;
            }

            return moves;
        }

        private List<Pair> getMovesN(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File), rankToRow(piece.Rank) + 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.Y += 1;
            }

            return moves;
        }

        private List<Pair> getMovesS(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File), rankToRow(piece.Rank) - 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.Y -= 1;
            }

            return moves;
        }

        private List<Pair> getMovesSE(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) + 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X += 1;
                coord.Y += 1;
            }

            return moves;
        }

        private List<Pair> getMovesNW(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) - 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X -= 1;
                coord.Y -= 1;
            }

            return moves;
        }

        private List<Pair> getMovesSW(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) + 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X -= 1;
                coord.Y += 1;
            }

            return moves;
        }

        private List<Pair> getMovesNE(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) - 1);

            while (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                    break;
                }
                moves.Add(new Pair(coord.X, coord.Y));
                coord.X += 1;
                coord.Y -= 1;
            }

            return moves;
        }

        private List<Pair> getKnightMoves(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) + 2, rankToRow(piece.Rank) - 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) + 2, rankToRow(piece.Rank) + 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 2, rankToRow(piece.Rank) - 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 2, rankToRow(piece.Rank) + 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) + 2);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) - 2);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) - 2);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) + 2);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            return moves;
        }

        private List<Pair> getKingMoves(Piece piece)
        {
            List<Pair> moves = new List<Pair>();

            Pair coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) - 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) + 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) - 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) + 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) + 1, rankToRow(piece.Rank) );

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File) - 1, rankToRow(piece.Rank) );

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File), rankToRow(piece.Rank) - 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            coord = new Pair(fileToColumn(piece.File), rankToRow(piece.Rank) + 1);

            if (isValidBoardCoord(coord))
            {
                if (chessBoard[coord.X, coord.Y] != null)
                {
                    Piece p = chessBoard[coord.X, coord.Y];
                    if (piece.Color != p.Color)
                    {
                        moves.Add(new Pair(coord.X, coord.Y));
                    }
                }
                else
                {
                    moves.Add(new Pair(coord.X, coord.Y));
                }
            }

            return moves;
        }

        private List<Pair> getPawnMoves(Piece piece)
        {
            List<Pair> moves = new List<Pair>();
            return moves;
        }

        private List<Pair> getMoves(Piece piece)
        {
            List<Pair> moves = new List<Pair>();
            switch (piece.Figure)
            {
                case ChessFigure.Bishop:
                    moves.AddRange(getMovesNE(piece));
                    moves.AddRange(getMovesSE(piece));
                    moves.AddRange(getMovesNW(piece));
                    moves.AddRange(getMovesSW(piece));
                    break;
                case ChessFigure.Rook:
                    moves.AddRange(getMovesN(piece));
                    moves.AddRange(getMovesS(piece));
                    moves.AddRange(getMovesW(piece));
                    moves.AddRange(getMovesE(piece));
                    break;
                case ChessFigure.Queen:
                    moves.AddRange(getMovesNE(piece));
                    moves.AddRange(getMovesSE(piece));
                    moves.AddRange(getMovesNW(piece));
                    moves.AddRange(getMovesSW(piece));
                    moves.AddRange(getMovesN(piece));
                    moves.AddRange(getMovesS(piece));
                    moves.AddRange(getMovesW(piece));
                    moves.AddRange(getMovesE(piece));
                    break;
                case ChessFigure.King:
                    moves.AddRange(getKingMoves(piece));
                    break;
                case ChessFigure.Knight:
                    moves.AddRange(getKnightMoves(piece));
                    break;
                case ChessFigure.Pawn:
                    moves.AddRange(getKingMoves(piece));
                    break;

            }
            return moves;
        }
        #endregion
    }
}
