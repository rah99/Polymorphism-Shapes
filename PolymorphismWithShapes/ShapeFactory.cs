namespace PolymorphismWithShapes
{
    public static class ShapeFactory
    {
        public static DrawShapeBase CreateShape(string shapeName)
        {
            return shapeName.ToLower() switch
            {
                Common.Constants.ShapeConstants.Square => new ShapeSquare(),
                Common.Constants.ShapeConstants.Circle => new ShapeCircle(),
                Common.Constants.ShapeConstants.Rectangle => new ShapeRectangle(),
                Common.Constants.ShapeConstants.Triangle => new ShapeTriangle(),
                 _ => throw new Exception(Common.Constants.ErrorConstants.ShapeNotSupported)
            };
        }
    }
}
