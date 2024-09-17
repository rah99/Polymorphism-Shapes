using PolymorphismWithShapes;
using PolymorphismWithShapes.Models;

var shapeType = new ShapeTypes("Some shape type");

DrawShapeBase drawShape = ShapeFactory.CreateShape(shapeType.Type);

using var shape = drawShape.GetShape(shapeType);
