using System.ComponentModel;

namespace WpfProject
{
    public class MoveRecord : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private char fromFile;
        public char FromFile
        {
            get { return fromFile; }
            set
            {
                fromFile = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FromFile)));
            }
        }

        private int fromRank;
        public int FromRank
        {
            get { return fromRank; }
            set
            {
                fromRank = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(FromRank)));
            }
        }

        private char toFile;
        public char ToFile
        {
            get { return toFile; }
            set
            {
                toFile = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ToFile)));
            }
        }

        private int toRank;
        public int ToRank
        {
            get { return toRank; }
            set
            {
                toRank = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ToRank)));
            }
        }

        public MoveRecord(char f_file, int f_rank, char to_file, int to_rank)
        {
            fromFile = f_file;
            fromRank = f_rank;
            toFile = to_file;
            toRank = to_rank;
        }

    }
}
