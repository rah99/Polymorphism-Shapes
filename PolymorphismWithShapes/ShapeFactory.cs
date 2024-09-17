namespace PolymorphismWithShapes
{
    public static class ShapeFactory
    {
        public static DrawShapeBase CreateShape(string shapeName)
        {
            return shapeName.ToLower() switch
            {
                "square" => new ShapeSquare(),
                "circle" => new ShapeCircle(),
                 _ => throw new Exception("Shape not supported")
            };
        }
    }
}
