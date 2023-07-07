using System;

namespace ReverseTicTacToe
{
    public class Player
    {
        // Data Members:
        private readonly string r_NickName;
        private readonly char r_Symbol;
        private int m_NumOfVictories;

        public Player(string i_NickName, char i_Symbol)
        {
            r_NickName = i_NickName;
            r_Symbol = i_Symbol;
            m_NumOfVictories = 0;
        }

        public string NickName
        {
            get
            {
                return r_NickName;
            }
        }

        public char Symbol
        {
            get
            {
                return r_Symbol;
            }
        }

        public int NumOfVictories
        {
            get
            {
                return m_NumOfVictories;
            }

            set
            {
                m_NumOfVictories = value;
            }
        }
    }
}
