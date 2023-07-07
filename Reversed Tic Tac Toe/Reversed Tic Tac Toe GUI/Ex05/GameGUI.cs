using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReverseTicTacToe
{
    public class GameGUI
    {
        private const string k_ComputerName = "Computer";
        private const int k_NumOfPlayers = 2;
        private const int k_FirstPlayerIndex = 0;
        private const int k_SecondPlayerIndex = 1;
        private const int k_ComputerPlayerIndex = 1;
        private const char k_SymbolX = 'X';
        private const char k_SymbolO = 'O';

        // Data Members:
        private Player[] m_Players = null;
        private GameBoard m_GameBoard = null;
        private bool m_IsSinglePlayer;
        private eGameStatus m_gameStatus = eGameStatus.Play;
        private GameSettingsForm m_GameSettingsForm;
        private GamePlayForm m_GamePlayForm;

        public void InitGame()
        {
            DialogResult settingsResult;

            m_GameSettingsForm = new GameSettingsForm();
            m_GameSettingsForm.ButtonStart.Click += buttonStart_Click;
            settingsResult = m_GameSettingsForm.ShowDialog();
            if(settingsResult == DialogResult.OK)
            {
                runGame();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            GameSettings gameSettings = m_GameSettingsForm.GetGameSettings();
            if (gameSettings == null)
            {
                MessageBox.Show("Please make sure to fill the form correctly.");
            }
            else
            {
                m_GameSettingsForm.DialogResult = DialogResult.OK;
                m_GameSettingsForm.Close();
                assignGameSettings(gameSettings);
            }
        }

        private void runGame()
        {
            m_GamePlayForm = new GamePlayForm(m_GameBoard.Size, m_Players[0].NickName, m_Players[1].NickName);
            assignCallToGameBoardButtons();
            assignFramesToButtons();
            m_GamePlayForm.ShowDialog();
        }

        private void buttonOnGameBoard_Click(object sender, EventArgs e)
        {
            FrameButton frameButton = sender as FrameButton;
            int currentPlayerIndex;

            if(frameButton != null)
            {
                m_GameBoard.MakeRegularTurn(frameButton.FrameHeightInBoard, frameButton.FrameWidthInBoard);
                moveToNextPlayerTurnInLabels();
                checkAndManageVictoryOrTie();
                currentPlayerIndex = m_GameBoard.CurrentPlayerIndex;
                // Execute Computer turn if needed
                if (m_IsSinglePlayer && currentPlayerIndex == k_ComputerPlayerIndex && m_gameStatus == eGameStatus.Play)
                {
                    m_GameBoard.MakeRandomTurn();
                    moveToNextPlayerTurnInLabels();
                    checkAndManageVictoryOrTie();
                }
            }
        }

        private void assignCallToGameBoardButtons()
        {
            foreach (FrameButton frame in m_GamePlayForm.BoardButtons)
            {
                frame.Click += buttonOnGameBoard_Click;
            }
        }

        private void assignGameSettings(GameSettings i_GameSettings)
        {
            m_GameBoard = new GameBoard(i_GameSettings.BoardSize);
            m_Players = new Player[k_NumOfPlayers];
            m_Players[k_FirstPlayerIndex] = new Player(i_GameSettings.PlayersName[k_FirstPlayerIndex], k_SymbolX);
            if (m_GameSettingsForm.CheckBoxPlayer2.Checked)
            {
                m_Players[k_SecondPlayerIndex] = new Player(i_GameSettings.PlayersName[k_SecondPlayerIndex], k_SymbolO);
                m_IsSinglePlayer = false;
            }
            else
            {
                m_Players[k_SecondPlayerIndex] = new Player(k_ComputerName, k_SymbolO);
                m_IsSinglePlayer = true;
            }
        }

        private void moveToNextPlayerTurnInLabels()
        {
            int currentPlayerIndex = m_GameBoard.CurrentPlayerIndex;

            m_GamePlayForm.SwitchPlayerLabelsFontByIndex(currentPlayerIndex);
        }

        private void checkAndManageVictoryOrTie()
        {
            char winningSymbol;

            m_gameStatus = m_GameBoard.UpdateGameStatus(out winningSymbol);

            switch(m_gameStatus)
            {
                case eGameStatus.Win:
                    displayWinMessageAndCheckForContinue(winningSymbol);
                    break;
                case eGameStatus.Tie:
                    displayTieMessageAndCheckForContinue();
                    break;
            }
        }

        private void displayWinMessageAndCheckForContinue(char i_WinningSymbol)
        {
            string messageBoxText;
            DialogResult result;
            int winnerPlayerIndex;

            if(i_WinningSymbol == k_SymbolX)
            {
                messageBoxText = createWinnerMessageBoxText(m_Players[k_FirstPlayerIndex].NickName);
                winnerPlayerIndex = k_FirstPlayerIndex;
            }
            else
            {
                messageBoxText = createWinnerMessageBoxText(m_Players[k_SecondPlayerIndex].NickName);
                winnerPlayerIndex = k_SecondPlayerIndex;
            }

            result = MessageBox.Show(messageBoxText, "A Win!", MessageBoxButtons.YesNo);
            handleWinResult(result, winnerPlayerIndex);
        }

        private void displayTieMessageAndCheckForContinue()
        {
            DialogResult result;
            string messageBoxText = createTieMessageBoxText();

            result = MessageBox.Show(messageBoxText, "A Tie!", MessageBoxButtons.YesNo);
            handleMessageBoxResult(result);
        }

        private string createWinnerMessageBoxText(string i_PlayerName)
        {
            return String.Format("The winner is {0}!{1}Would you like to play another round?", i_PlayerName, Environment.NewLine);
        }

        private string createTieMessageBoxText()
        {
            return String.Format("Tie! {0}Would you like to play another round?", Environment.NewLine);
        }

        private void handleWinResult(DialogResult i_Result, int i_WinnerPlayerIndex)
        {
            Player winnerPlayer = m_Players[i_WinnerPlayerIndex];

            winnerPlayer.NumOfVictories++;
            m_GamePlayForm.UpdatePlayerScore(winnerPlayer.NickName, winnerPlayer.NumOfVictories, i_WinnerPlayerIndex);
            handleMessageBoxResult(i_Result);
        }

        private void handleMessageBoxResult(DialogResult i_Result)
        {
            if (i_Result == DialogResult.Yes)
            {
                resetGame();
            }
            else
            {
                m_GamePlayForm.Close();
            }
        }

        private void resetGame()
        {
            m_GameBoard.ClearBoard();
            m_GamePlayForm.CleanForm();
            m_GameBoard.CurrentPlayerIndex = k_FirstPlayerIndex;
            m_gameStatus = eGameStatus.Play;
            m_GamePlayForm.SwitchPlayerLabelsFontByIndex(k_FirstPlayerIndex);
        }

        private void assignFramesToButtons()
        {
            int boardSize = m_GameBoard.Size;
            Frame[,] logicGameBoard = m_GameBoard.Board;
            FrameButton[,] guiButtons = m_GamePlayForm.BoardButtons;

            for(int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    logicGameBoard[i, j].FrameUpdated += guiButtons[i, j].UpdateFrameSymbol_OnClick;
                }
            }
        }
    }
}
