namespace PolymorphismWithShapes.Models
{
    public class Square(int widthHeight)
    {
        public int WidthHeight { get; private set; } = widthHeight;
    }
}
