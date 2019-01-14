using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfProject
{
    public class MovesHistoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ChessGame game;
        public MovesHistoryViewModel(ChessGame chess)
        {
            game = chess;
        }
        public ObservableCollection<MoveRecord> MovesHistory
        {
            get { return game.MovesHistory;  }
        }
    }
}
