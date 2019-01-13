using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject
{
    public class BoardCell : IBoardItem
    {
        public int Rank { get; set; }
        public char File { get; set; }
        public BoardItemType ItemType { get; set; }
    }
}
