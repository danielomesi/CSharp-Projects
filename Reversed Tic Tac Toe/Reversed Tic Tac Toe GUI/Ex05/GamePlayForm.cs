using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    public class GamePlayForm : Form
    {
        private const int k_ButtonWidthAndHeight = 60;
        private const int k_FirstAndLastButtonsWidthMargins = 24;
        private const int k_FirstAndLastButtonsHeightMargins = 54;
        private const int k_SpaceBetweenTwoButtons = 6;
        private const int k_TopLeftButtonXAndY = 12;
        private const int k_LabelsLetterPixelSize = 8;
        private const int k_LabelHeight = 30;
        private const int k_ExtraSizeForLabel = 4;
        private const int k_FirstRow = 0;
        private const int k_FirstColumn = 0;

        private static int buttonsCounter = 0;
        private FrameButton[,] m_BoardButtons; // FrameButton inherit from Button.
        private Label labelScorePlayer1;
        private Label labelScorePlayer2;

        public FrameButton[,] BoardButtons
        {
            get
            {
                return m_BoardButtons;
            }
        }

        public Label Player1
        {
            get
            {
                return labelScorePlayer1;
            }
        }

        public Label Player2
        {
            get
            {
                return labelScorePlayer2;
            }
        }

        public GamePlayForm(int i_boardSize, string i_firstPlayerName, string i_secondPlayerName)
        {
            InitializeGamePlayComponent(i_boardSize, i_firstPlayerName, i_secondPlayerName);
        }

        private void InitializeGamePlayComponent(int i_boardSize, string i_firstPlayerName, string i_secondPlayerName)
        {
            m_BoardButtons = new FrameButton[i_boardSize, i_boardSize];
            InitiateFormProperties();
            addIcon();
            resizeWindow(i_boardSize);
            addButtons(i_boardSize);
            addScoresLabels(i_firstPlayerName, i_secondPlayerName);
        }

        private void InitiateFormProperties()
        {
            this.Text = "TicTacToeMisere";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void resizeWindow(int i_boardSize)
        {
            int width = k_FirstAndLastButtonsWidthMargins + (k_ButtonWidthAndHeight * i_boardSize) + (k_SpaceBetweenTwoButtons * (i_boardSize - 1));
            int height = k_FirstAndLastButtonsHeightMargins + (k_ButtonWidthAndHeight * i_boardSize) + (k_SpaceBetweenTwoButtons * (i_boardSize - 1));

            this.ClientSize = new Size(width, height);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void addButtons(int i_boardSize)
        {
            for (int i = 0; i < i_boardSize; i++)
            {
                for (int j = 0; j < i_boardSize; j++)
                {
                    if (j == 0)
                    {
                        initialFirstInRowButtons(i);
                    }
                    else
                    {
                        initialNonFirstInRowButtons(i, j);
                    }
                }
            }
        }

        private void initialFirstInRowButtons(int i_row)
        {
            FrameButton button = new FrameButton(i_row, k_FirstColumn);
            int yPos;

            if (i_row == k_FirstRow)
            {
                button.Location = new Point(k_TopLeftButtonXAndY, k_TopLeftButtonXAndY);
            }
            else
            {
                yPos = m_BoardButtons[i_row - 1, k_FirstColumn].Location.Y + k_ButtonWidthAndHeight + k_SpaceBetweenTwoButtons;
                button.Location = new Point(k_TopLeftButtonXAndY, yPos);
            }

            button.Name = getButtonName();
            button.Size = new Size(k_ButtonWidthAndHeight, k_ButtonWidthAndHeight);
            button.TabStop = false;
            button.UseVisualStyleBackColor = true;
            button.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)(177));
            this.Controls.Add(button);
            m_BoardButtons[i_row, k_FirstColumn] = button;
        }

        private void initialNonFirstInRowButtons(int i_row, int i_column)
        {
            FrameButton button = new FrameButton(i_row, i_column);
            int xPos = m_BoardButtons[i_row, i_column - 1].Location.X + k_ButtonWidthAndHeight + k_SpaceBetweenTwoButtons;
            int yPos = m_BoardButtons[i_row, i_column - 1].Location.Y;

            button.Location = new Point(xPos, yPos);
            button.Name = getButtonName();
            button.Size = new Size(k_ButtonWidthAndHeight, k_ButtonWidthAndHeight);
            button.TabStop = false;
            button.UseVisualStyleBackColor = true;
            button.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)(177));
            this.Controls.Add(button);
            m_BoardButtons[i_row, i_column] = button;
        }

        private string getButtonName()
        {
            buttonsCounter++;
            return String.Format("button{0}", buttonsCounter);
        }

        private void addScoresLabels(string i_firstPlayerName, string i_secondPlayerName)
        {
            int labelX, labelY = this.Bottom - k_ButtonWidthAndHeight;

            // labelScorePlayer1
            labelScorePlayer1 = new Label();
            labelScorePlayer1.Text = getlabelScorePlayerText(i_firstPlayerName, 0);
            labelScorePlayer1.Name = "labelScorePlayer1";
            labelScorePlayer1.Size = new Size(k_LabelsLetterPixelSize * labelScorePlayer1.Text.Length + k_ExtraSizeForLabel, k_LabelHeight);
            labelScorePlayer1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, (byte)(177));
           

            // labelScorePlayer2
            labelScorePlayer2 = new Label();
            labelScorePlayer2.Text = getlabelScorePlayerText(i_secondPlayerName, 0);
            labelScorePlayer2.Name = "labelScorePlayer2";
            labelScorePlayer2.Size = new Size(k_LabelsLetterPixelSize * labelScorePlayer2.Text.Length + k_ExtraSizeForLabel, k_LabelHeight);
            labelScorePlayer2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (byte)(177));

            // Location for the labels
            labelX = (this.Width - (labelScorePlayer1.Width + labelScorePlayer2.Width)) / 2;
            labelScorePlayer1.Location = new Point(labelX, labelY);
            labelScorePlayer2.Location = new Point(labelScorePlayer1.Right, labelY);
            this.Controls.Add(this.labelScorePlayer2);
            this.Controls.Add(this.labelScorePlayer1);
        }

        private string getlabelScorePlayerText(string i_Name, int i_PlayerScore)
        {
            return String.Format("{0}: {1}", i_Name, i_PlayerScore);
        }

        public void UpdatePlayerScore(string i_Name, int i_PlayerScore, int i_PlayerIndex)
        {
            if (i_PlayerIndex == 0)
            {
                labelScorePlayer1.Text = getlabelScorePlayerText(i_Name, i_PlayerScore);
            }
            else
            {
                labelScorePlayer2.Text = getlabelScorePlayerText(i_Name, i_PlayerScore);
            }
        }

        public void SwitchPlayerLabelsFontByIndex(int i_index)
        {
            if (i_index == 0)
            {
                labelScorePlayer1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, (byte)(177));
                labelScorePlayer2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (byte)(177));
            }
            else
            {
                labelScorePlayer2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, (byte)(177));
                labelScorePlayer1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, (byte)(177));
            }
        }

        private void addIcon()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettingsForm));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        }

        public void CleanForm()
        {
            foreach (FrameButton button in m_BoardButtons)
            {
                button.Text = string.Empty;
                button.Enabled = true;
            }
        }
    }
}
