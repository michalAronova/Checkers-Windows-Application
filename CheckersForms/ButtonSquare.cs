using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EnglishCheckers;

namespace CheckersForms
{
    public partial class ButtonSquare : CheckBox
    {
        private readonly Coordinate r_Coordinate;
        private const int k_ButtonSquareSize = 30;

        public ButtonSquare(Coordinate i_Coordinate)
        {
            r_Coordinate = i_Coordinate;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Size = new Size(k_ButtonSquareSize, k_ButtonSquareSize);
            this.Appearance = Appearance.Button;
            this.FlatStyle = FlatStyle.Flat;
        }

        public Coordinate Coordinate
        {
            get
            {
                return r_Coordinate;
            }
        }
        
        public ButtonSquare()
        {
            InitializeComponent();
        }

        public ButtonSquare(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
