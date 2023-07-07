using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReverseTicTacToe
{
    public class GameSettingsForm : Form
    {
        private Label labelPlayers;
        private Label labelPlayer1;
        private TextBox textBoxPlayer2;
        private CheckBox checkBoxPlayer2;
        private Label labelBoardSize;
        private NumericUpDown numericUpDownRows;
        private Label labelRows;
        private Label labelCols;
        private NumericUpDown numericUpDownCols;
        private Button buttonStart;
        private TextBox textBoxPlayer1;

        public Button ButtonStart
        {
            get
            {
                return buttonStart;
            }
        }

        public CheckBox CheckBoxPlayer2
        {
            get
            {
                return checkBoxPlayer2;
            }
        }

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameSettingsForm));
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.labelRows = new System.Windows.Forms.Label();
            this.labelCols = new System.Windows.Forms.Label();
            this.numericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBoxPlayer1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(64, 20);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPlayer1.Location = new System.Drawing.Point(23, 49);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(60, 17);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player 1";
            // 
            // textBoxPlayer2
            // 
            this.textBoxPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer2.Enabled = false;
            this.textBoxPlayer2.Location = new System.Drawing.Point(126, 84);
            this.textBoxPlayer2.Name = "textBoxPlayer2";
            this.textBoxPlayer2.Size = new System.Drawing.Size(99, 23);
            this.textBoxPlayer2.TabIndex = 4;
            this.textBoxPlayer2.Text = "[Computer]";
            // 
            // checkBoxPlayer2
            // 
            this.checkBoxPlayer2.AutoSize = true;
            this.checkBoxPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxPlayer2.Location = new System.Drawing.Point(27, 83);
            this.checkBoxPlayer2.Name = "checkBoxPlayer2";
            this.checkBoxPlayer2.Size = new System.Drawing.Size(79, 21);
            this.checkBoxPlayer2.TabIndex = 6;
            this.checkBoxPlayer2.Text = "Player 2";
            this.checkBoxPlayer2.UseVisualStyleBackColor = true;
            this.checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.checkBoxPlayer2_CheckedChanged);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelBoardSize.Location = new System.Drawing.Point(12, 146);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(91, 20);
            this.labelBoardSize.TabIndex = 7;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDownRows.Location = new System.Drawing.Point(85, 183);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(44, 23);
            this.numericUpDownRows.TabIndex = 8;
            this.numericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // labelRows
            // 
            this.labelRows.AutoSize = true;
            this.labelRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelRows.Location = new System.Drawing.Point(23, 185);
            this.labelRows.Name = "labelRows";
            this.labelRows.Size = new System.Drawing.Size(46, 17);
            this.labelRows.TabIndex = 9;
            this.labelRows.Text = "Rows:";
            // 
            // labelCols
            // 
            this.labelCols.AutoSize = true;
            this.labelCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCols.Location = new System.Drawing.Point(138, 185);
            this.labelCols.Name = "labelCols";
            this.labelCols.Size = new System.Drawing.Size(35, 17);
            this.labelCols.TabIndex = 10;
            this.labelCols.Text = "Cols";
            // 
            // numericUpDownCols
            // 
            this.numericUpDownCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDownCols.Location = new System.Drawing.Point(187, 183);
            this.numericUpDownCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCols.Name = "numericUpDownCols";
            this.numericUpDownCols.Size = new System.Drawing.Size(43, 23);
            this.numericUpDownCols.TabIndex = 11;
            this.numericUpDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCols.ValueChanged += new System.EventHandler(this.numericUpDownCols_ValueChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStart.Location = new System.Drawing.Point(27, 228);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(195, 42);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // textBoxPlayer1
            // 
            this.textBoxPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayer1.Location = new System.Drawing.Point(126, 43);
            this.textBoxPlayer1.Name = "textBoxPlayer1";
            this.textBoxPlayer1.Size = new System.Drawing.Size(99, 23);
            this.textBoxPlayer1.TabIndex = 13;
            // 
            // GameSettingsForm
            // 
            this.AcceptButton = this.buttonStart;
            this.ClientSize = new System.Drawing.Size(248, 281);
            this.Controls.Add(this.textBoxPlayer1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownCols);
            this.Controls.Add(this.labelCols);
            this.Controls.Add(this.labelRows);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.checkBoxPlayer2);
            this.Controls.Add(this.textBoxPlayer2);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.Checked)
            {
                textBoxPlayer2.Enabled = true;
            }
            else
            {
                textBoxPlayer2.Enabled = false;
                textBoxPlayer2.Text = "[Computer]";
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownRows = sender as NumericUpDown;
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownCols = sender as NumericUpDown;
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        public GameSettings GetGameSettings()
        {
            GameSettings gameSettings = null;
            string player1Name = textBoxPlayer1.Text;
            string player2Name = textBoxPlayer2.Text;
            int boardSize = (int)numericUpDownRows.Value;

            if (player1Name.Length > 0 && player2Name.Length > 0)
            {
                gameSettings = new GameSettings(player1Name, player2Name, boardSize);
            }

            return gameSettings;
        }

        
    }
}
