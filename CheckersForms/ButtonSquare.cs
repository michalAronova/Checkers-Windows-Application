using System.ComponentModel;
using System.Windows.Forms;
using EnglishCheckers;

namespace CheckersForms
{
    public partial class ButtonSquare : Button
    {
        private readonly Coordinate r_Coordinate;

        public ButtonSquare(Coordinate i_Coordinate)
        {
            r_Coordinate = i_Coordinate;
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
