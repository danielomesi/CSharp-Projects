using System;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    public class Frame
    {
        // Data Members:
        private eFrameState m_State;
        private int m_Height;
        private int m_Width;
        public Action<string> FrameUpdated;

        public Frame(int i_Height, int i_Width)
        {
            m_State = eFrameState.Available;
            m_Height = i_Height;
            m_Width = i_Width;
        }

        public eFrameState State
        {
            get
            {
                return m_State;
            }

            set
            {
                m_State = value;
            }
        }

        public int Height
        {
            get
            {
                return m_Height;
            }

            set
            {
                m_Height = value;
            }
        }

        public int Width
        {
            get
            {
                return m_Width;
            }

            set
            {
                m_Width = value;
            }
        }
    }
}
