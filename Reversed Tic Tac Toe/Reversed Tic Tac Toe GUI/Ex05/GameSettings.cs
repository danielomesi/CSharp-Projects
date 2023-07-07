using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseTicTacToe
{
    public class GameSettings
    {
        private readonly string[] r_PlayersNames;
        private readonly int m_BoardSize;

        public string[] PlayersName
        {
            get
            {
                return r_PlayersNames;
            }
        }

        public int BoardSize
        {
            get
            {
                return m_BoardSize;
            }
        }

        public GameSettings(string i_Player1Name, string i_Player2Name, int i_BoardSize)
        {
            r_PlayersNames = new string[2];
            r_PlayersNames[0] = i_Player1Name;
            r_PlayersNames[1] = i_Player2Name;
            m_BoardSize = i_BoardSize;
        }
    }
}
