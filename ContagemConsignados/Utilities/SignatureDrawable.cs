using Microsoft.Maui.Graphics;

namespace ContagemConsignados.Utilities
{
    public class SignatureDrawable : IDrawable
    {
        private readonly List<List<PointF>> _stokes = new();
        private List<PointF> _current;

        public void Start(PointF p)
        {
            _current = new() { p };
            _stokes.Add(_current);
        }

        public void Move(PointF p)
        {
            _current?.Add(p);
        }

        public void End() => _current = null;
        public void Clear() => _stokes.Clear();

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Black;
            canvas.StrokeSize = 2;

            foreach(var stroke in _stokes) 
                for(int i = 1; i < stroke.Count; i++)
                    canvas.DrawLine(stroke[i - 1], stroke[i]);
        }
        private static async Task<byte[]> ImageToBytes(Microsoft.Maui.Graphics.IImage image)
        {
            using var ms = new MemoryStream();
            await image.SaveAsync(ms, ImageFormat.Png);
            return ms.ToArray();
        }

    }
}
