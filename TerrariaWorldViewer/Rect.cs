using System.Drawing;

namespace TerrariaWorldViewer
{
    public class Rect
    {
        private readonly Point _topLeft;
        private readonly Point _bottomRight;

        public Point TopLeft
        {
            get { return _topLeft; }
        }

        public Point BottomRight
        {
            get { return _bottomRight; }
        }

        public Rect(int left, int right, int top, int bottom)
        {
            _topLeft = new Point(left, top);
            _bottomRight = new Point(right, bottom);
        }


        public override string ToString()
        {
            return string.Format("{0},{1}", TopLeft, BottomRight);
        }

    }
}
