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
            Bitmap bitmap = null;

            switch (shapeType.ToLower())
            {
                case "square":
                    bitmap = new Bitmap(square.WidthHeight, square.WidthHeight);
                    break;
                case "circle":
                    bitmap = new Bitmap(circle.Radius, circle.Radius);
                    break;
                case "rectangle":
                    bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                    break;
                case "triangle":
                    bitmap = new Bitmap(1000, 800);
                    break;
                default:
                    break;
            }

            try
            {
                if (null != bitmap)
                {
                    using var graphics = Graphics.FromImage(bitmap);
                    using var backgroundBrush = new SolidBrush(backgroundColor);
                    using var foregroundBrush = new SolidBrush(forgroundColor);
                    using var font = new Font("Arial", 20f);

                    switch (shapeType.ToLower())
                    {
                        case "square":
                            graphics.FillRectangle(backgroundBrush, 0, 0, square.WidthHeight, square.WidthHeight);
                            graphics.DrawString(text, font, foregroundBrush, 10, 10);
                            break;
                        case "circle":
                            graphics.FillEllipse(backgroundBrush, 0, 0, circle.Radius, circle.Radius);
                            graphics.DrawString(text, font, foregroundBrush, 90, 150);
                            break;
                        case "rectangle":
                            graphics.FillRectangle(backgroundBrush, 0, 0, rectangle.Width, rectangle.Height);
                            graphics.DrawString(text, font, foregroundBrush, 10, 10);
                            break;
                        case "triangle":
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

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, "I am a square!", square);
        }
    }

    internal class ShapeRectangle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var rectangle = new Models.Rectangle(450, 250);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, "I am a rectangle!", null, null, rectangle);
        }
    }

    internal class ShapeCircle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var circle = new Circle(350);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, "I am a circle!", null, circle);
        }
    }

    internal class ShapeTriangle : DrawShapeBase
    {
        protected override Image GetShapeCore(ShapeTypes shapeType)
        {
            var triangle = new Triangle(10, 450, 225, 20, 460, 450);

            return GenerateShape(shapeType.Type, Color.Orange, Color.White, "I am a triangle", null, null, null, triangle);
        }
    }
}
