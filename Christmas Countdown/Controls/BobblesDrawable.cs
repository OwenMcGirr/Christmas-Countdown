using Color = Microsoft.Maui.Graphics.Color;
using Point = Microsoft.Maui.Graphics.Point;

namespace ChristmasCountdown.Controls
{
    public class BobbleDrawable : IDrawable
    {

        private Random _random;

        public BobbleDrawable()
        {
            _random = new Random();
        }

        // get random color 
        public Color GetRandomColor()
        {
            int r = _random.Next(0, 255);
            int g = _random.Next(0, 255);
            int b = _random.Next(0, 255);
            return new Color(r, g, b);
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            var width = dirtyRect.Width;
            var height = dirtyRect.Height;

            // Define 12 random points
            var points = new List<Point>();
            for (int i = 0; i < 12; i++)
            {
                points.Add(new Point(_random.Next(0, (int)width), _random.Next(0, (int)height)));
            }

            // Draw the bobbles
            foreach (var point in points)
            {
                var color = GetRandomColor();
                var size = _random.Next(10, 50);
                canvas.FillColor = color;
                canvas.FillEllipse((float)point.X, (float)point.Y, size, size);
            }
        }

    }

}
