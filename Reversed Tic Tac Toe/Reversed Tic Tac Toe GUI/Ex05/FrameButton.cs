using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    public class FrameButton : Button
    {
        private int m_FrameHeightInBoard;
        private int m_FrameWidthInBoard;

        public FrameButton(int i_FrameHeightInBoard, int i_FrameWidthInBoard)
        {
            m_FrameHeightInBoard = i_FrameHeightInBoard;
            m_FrameWidthInBoard = i_FrameWidthInBoard;
        }

        public int FrameHeightInBoard
        {
            get
            {
                return m_FrameHeightInBoard;
            }
        }

        public int FrameWidthInBoard
        {
            get
            {
                return m_FrameWidthInBoard;
            }
        }

        public void UpdateFrameSymbol_OnClick(string i_Text)
        {
            this.Text = i_Text;
            this.Enabled = false;
        }
    }
}
