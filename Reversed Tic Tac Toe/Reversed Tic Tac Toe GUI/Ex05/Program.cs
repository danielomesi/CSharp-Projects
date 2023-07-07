using System;
using System.Net.Mime;
using System.Linq;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameGUI game = new GameGUI();
            game.InitGame();
        }
    }
}
