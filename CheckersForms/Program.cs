using System.Windows.Forms;

namespace CheckersForms
{
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            EnglishCheckersUI englishCheckersUI = new EnglishCheckersUI();
            englishCheckersUI.SetGame();
        }
    }
}
