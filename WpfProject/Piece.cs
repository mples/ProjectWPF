using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject
{
    public class Piece : IBoardItem, INotifyPropertyChanged
    {
        private int rank;
        public int Rank {
            get { return rank; }
            set
            {
                rank = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Rank)));
            }
        }
        private char file;
        public char File
        {
            get { return file; }
            set
            {
                file = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(File)));
            }
        }
        public BoardItemType ItemType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ChessColor color;

        public ChessColor Color
        {
            get { return color; }
            set
            {
                if (color == value)
                    return;
                color = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Color)));
            }
        }

        private ChessFigure figure;

        public ChessFigure Figure
        {
            get { return figure; }
            set
            {
                if (figure == value)
                    return;
                figure = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Figure)));
            }
        }

        private bool moved = false;

        public bool Moved
        {
            get { return moved; }
            set
            {
                moved = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Moved)));
            }
        }
    }
}
