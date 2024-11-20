using PolymorphismWithShapes;
using PolymorphismWithShapes.Models;
using System.Globalization;

namespace DisplayShapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            InitializeComponent();
            comboBox1.Items.Add(new ShapeTypeDisplay(textInfo.ToTitleCase(Common.Constants.ShapeConstants.Square)));
            comboBox1.Items.Add(new ShapeTypeDisplay(textInfo.ToTitleCase(Common.Constants.ShapeConstants.Rectangle)));
            comboBox1.Items.Add(new ShapeTypeDisplay(textInfo.ToTitleCase(Common.Constants.ShapeConstants.Circle)));
            comboBox1.Items.Add(new ShapeTypeDisplay(textInfo.ToTitleCase(Common.Constants.ShapeConstants.Triangle)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                var selectedShape = ((ShapeTypeDisplay)comboBox1.SelectedItem).ShapeName;
                var shapeType = new ShapeTypes(selectedShape);

                DrawShapeBase drawShape = ShapeFactory.CreateShape(shapeType.Type);
                pictureBox1.Image = drawShape.GetShape(shapeType);
            }
        }

        public class ShapeTypeDisplay(string shapeName)
        {
            public string ShapeName { get; private set; } = shapeName;
        }
    }
}
