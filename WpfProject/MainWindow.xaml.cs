using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ChessGame chess;
        private ChessTableViewModel chessTableViewModel;
        public MainWindow()
        {
            InitializeComponent();
            chess = new ChessGame();
            chessTableViewModel = new ChessTableViewModel(chess);
            DataContext = chessTableViewModel;
            movesHistoryListView.DataContext = new MovesHistoryViewModel(chess);
        }
    }
}
