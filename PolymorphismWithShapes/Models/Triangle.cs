namespace PolymorphismWithShapes.Models
{
    public class Triangle(int vectorOneX, int vectorOneY, int vectorTwoX, int  vectorTwoY, int vectorThreeX, int vectorThreeY)
    {
        public int VectorOneX { get; private set; } = vectorOneX;
        public int VectorOneY { get; private set; } = vectorOneY;
        public int VectorTwoX { get; private set; } = vectorTwoX;
        public int VectorTwoY { get; private set; } = vectorTwoY;
        public int VectorThreeX { get; private set; } = vectorThreeX;
        public int VectorThreeY { get; private set; } = vectorThreeY;
    }
}
