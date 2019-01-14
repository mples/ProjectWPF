namespace WpfProject
{
    class Pair
    {
        public int X;
        public int Y;

        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            return pair != null &&
                   X == pair.X &&
                   Y == pair.Y;
        }
    }
}
