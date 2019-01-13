using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfProject
{
    public class ChessTableViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public ChessTableViewModel()
        {
            BoardItems = ChessLogic.InitialBoard();
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
        public string ChessText
        {
            get { return "a"; }
        }
    }
}
