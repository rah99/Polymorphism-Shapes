using PolymorphismWithShapes.Models;
using System.Drawing;

namespace PolymorphismWithShapes
{
    public abstract class DrawShapeBase
    {
        public Image GetShape(ShapeTypes shapeType)
        {
            return GetShapeCore(shapeType);
        }

        protected Image GenerateShape(string shapeType, Color backgroundColor, Color forgroundColor, string text, Square? square = null, Circle? circle = null, Models.Rectangle? rectangle = null, Triangle? triangle = null)
        {
            Bitmap? bitmap = null;

            switch (shapeType.ToLower())
            {
                case Common.Constants.ShapeConstants.Square:
                    bitmap = new Bitmap(square.WidthHeight, square.WidthHeight);
                    break;
                case Common.Constants.ShapeConstants.Circle:
                    bitmap = new Bitmap(circle.Radius, circle.Radius);
                    break;
                case Common.Constants.ShapeConstants.Rectangle:
                    bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                    break;
                case Common.Constants.ShapeConstants.Triangle:
                    bitmap = new Bitmap(1000, 800);
                    break;
                default:
                    break;
            }

            try
            {
                if (null != bitmap)
                {
                    using Graphics? graphics = Graphics.FromImage(bitmap);
                    using SolidBrush? backgroundBrush = new SolidBrush(backgroundColor);
                    using SolidBrush? foregroundBrush = new SolidBrush(forgroundColor);
                    using Font? font = new Font("Arial", 20f);

                    switch (shapeType.ToLower())
                    {
                        case Common.Constants.ShapeConstants.Square:
                            graphics.FillRectangle(backgroundBrush, 0, 0, square.WidthHeight, square.WidthHeight);
                            graphics.DrawString(text, font, foregroundBrush, 10, 10);
                            break;
                        case Common.Constants.ShapeConstants.Circle:
                            graphics.FillEllipse(backgroundBrush, 0, 0, circle.Radius, circle.Radius);
                            graphics.DrawString(text, font, foregroundBrush, 90, 150);
                            break;
                        case Common.Constants.ShapeConstants.Rectangle:
                            graphics.FillRectangle(backgroundBrush, 0, 0, rectangle.Width, rectangle.Height);
                            graphics.DrawString(text, font, foregroundBrush, 10, 10);
                            break;
                        case Common.Constants.ShapeConstants.Triangle:
                            graphics.FillPolygon(backgroundBrush, new Point[] { new(triangle.VectorOneX, triangle.VectorOneY), new(triangle.VectorTwoX, triangle.VectorTwoY), new(triangle.VectorThreeX, triangle.VectorThreeY) });
                            graphics.DrawString(text, font, foregroundBrush, 145, 400);
                            break;
                        default:
                            break;
                    }
                }


                return bitmap;
            }
            catch (Exception)
            {
                bitmap.Dispose();
                throw;
            }
        }

        protected abstract Image GetShapeCore(ShapeTypes shapeType);
    }

    internal class ShapeSquare : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var square = new Square(450);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, Common.Constants.DisplayTextConstants.Square, square);
        }
    }

    internal class ShapeRectangle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var rectangle = new Models.Rectangle(450, 250);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, Common.Constants.DisplayTextConstants.Rectangle, null, null, rectangle);
        }
    }

    internal class ShapeCircle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var circle = new Circle(350);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, Common.Constants.DisplayTextConstants.Circle, null, circle);
        }
    }

    internal class ShapeTriangle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var triangle = new Triangle(10, 450, 225, 20, 460, 450);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, Common.Constants.DisplayTextConstants.Triangle, null, null, null, triangle);
        }
    }
}
