namespace PolymorphismWithShapes.Models
{
    public class Rectangle(int width, int height)
    {
        public int Width { get; private set; } = width;
        public int Height { get; private set; } = height;
    }
}
