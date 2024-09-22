using PolymorphismWithShapes;
using PolymorphismWithShapes.Models;

namespace DisplayShapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add(new ShapeTypeDisplay("Square"));
            comboBox1.Items.Add(new ShapeTypeDisplay("Rectangle"));
            comboBox1.Items.Add(new ShapeTypeDisplay("Circle"));
            comboBox1.Items.Add(new ShapeTypeDisplay("Triangle"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedShape = ((ShapeTypeDisplay)comboBox1.SelectedItem).ShapeName;
            var shapeType = new ShapeTypes(selectedShape);

            DrawShapeBase drawShape = ShapeFactory.CreateShape(shapeType.Type);
            pictureBox1.Image = drawShape.GetShape(shapeType);
        }

        public class ShapeTypeDisplay(string shapeName)
        {
            public string ShapeName { get; private set; } = shapeName;
        }
    }
}
