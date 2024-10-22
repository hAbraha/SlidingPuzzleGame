namespace SlidingPuzzleGame
{
    public partial class Form1 : Form
    {
        // This array will represent the tile positions, including the empty space
        int[] tile = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
        int moves = 0; // Keep track of the number of moves made by the player.
        public Form1()
        {
            InitializeComponent();
        }
        private void ShuffleTiles()
        {
            Random rand = new Random();
            for (int i = 0; i < tile.Length; i++)
            {
                int randomIndex = rand.Next(tile.Length);
                // Swap the current tile with a random one.
                int temp = tile[i];
                tile[i] = tile[randomIndex];
                tile[randomIndex] = temp;
            }
            // After shuffling, update the buttons to reflect the new arrangement.
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            // Assuning the buttons are named button1, button2,.....button15.
            button1.Text = tile[0] == 0 ? "" : tile[0].ToString();
            button2.Text = tile[1] == 0 ? "" : tile[1].ToString();
            button3.Text = tile[2] == 0 ? "" : tile[2].ToString();
            button4.Text = tile[3] == 0 ? "" : tile[3].ToString();
            button5.Text = tile[4] == 0 ? "" : tile[4].ToString();
            button6.Text = tile[5] == 0 ? "" : tile[5].ToString();
            button7.Text = tile[6] == 0 ? "" : tile[6].ToString();
            button8.Text = tile[7] == 0 ? "" : tile[7].ToString();
            button9.Text = tile[8] == 0 ? "" : tile[8].ToString();
            button10.Text = tile[9] == 0 ? "" : tile[9].ToString();
            button11.Text = tile[10] == 0 ? "" : tile[10].ToString();
            button12.Text = tile[11] == 0 ? "" : tile[11].ToString();
            button13.Text = tile[12] == 0 ? "" : tile[12].ToString();
            button14.Text = tile[13] == 0 ? "" : tile[13].ToString();
            button15.Text = tile[14] == 0 ? "" : tile[14].ToString();
            button16.Text = tile[15] == 0 ? "" : tile[15].ToString(); // Empty space

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShuffleTiles();

            // Assign the same click event handler to all buttons
            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
            button4.Click += Button_Click;
            button5.Click += Button_Click;
            button6.Click += Button_Click;
            button7.Click += Button_Click;
            button8.Click += Button_Click;
            button9.Click += Button_Click;
            button10.Click += Button_Click;
            button11.Click += Button_Click;
            button12.Click += Button_Click;
            button13.Click += Button_Click;
            button14.Click += Button_Click;
            button15.Click += Button_Click;
            button16.Click += Button_Click; // the empty space button

        }
        private void Button_Click(object sender, EventArgs e)
        {
            // Identify which button was clicked 
            Button clickedButton = sender as Button;
            int clickedIndex = GetButtonIndex(clickedButton); // Get the index of the clicked button

            int emptyIndex = Array.IndexOf(tile, 0); // Find the index of the empty space

            if (IsAdjacent(clickedIndex, emptyIndex))
            {
                // Swap the clicked tile with the empty space
                tile[emptyIndex] = tile[clickedIndex];
                tile[clickedIndex] = 0;

                // Update the buttons to reflect the new arrangement
                UpdateButtons();

                // Increment move counter
                moves++;
                lblMoves.Text = $"Moves: {moves}";

                // check if the player has won
                CheckForWin();

            }


        }
        private bool IsAdjacent(int index1, int index2)
        {
            int row1 = index1 / 4; // Get the row of the first index
            int col1 = index1 % 4; // Get the column of the first index
            int row2 = index2 / 4; // Get the row of the second index
            int col2 = index2 % 4; // Get the column of the second index

            // The tile is adjacent if it's either in the same row or column and next to the empty space
            return (Math.Abs(row1 - row2) + Math.Abs(col1 - col2)) == 1;
        }
        private int GetButtonIndex(Button clickedButton)
        {
            if (clickedButton == button1) return 0;
            if (clickedButton == button2) return 1;
            if (clickedButton == button3) return 2;
            if (clickedButton == button4) return 3;
            if (clickedButton == button5) return 4;
            if (clickedButton == button6) return 5;
            if (clickedButton == button7) return 6;
            if (clickedButton == button8) return 7;
            if (clickedButton == button9) return 8;
            if (clickedButton == button10) return 9;
            if (clickedButton == button11) return 10;
            if (clickedButton == button12) return 11;
            if (clickedButton == button13) return 12;
            if (clickedButton == button14) return 13;
            if (clickedButton == button15) return 14;
            if (clickedButton == button16) return 15;
            return -1; // Return -1 if no button is found (shouldn't happen)
        }
        private void CheckForWin()
        {
            for (int i = 0; i < 15; i++)
            {
                if (tile[i] != i + 1)
                    return; // If any tile is out of place, return without doing anything
            }

            // If the loop completes, the player has won
            MessageBox.Show($"You win! Total moves: {moves}");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Shuffle the tiles again
            ShuffleTiles();

            // Reset the move counter
            moves = 0;
            lblMoves.Text = "Moves: 0"; // Reset the moves label
        }
        private void ResetGame()
        {
            ShuffleTiles(); // Shuffle the tiles for a new round 
            moves = 0;   // Reset the move counter
            lblMoves.Text = "Time: 00:00";
        }
       
    }
}
