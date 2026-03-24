/*****************************************************************************************************
 * Program name  : Puzzle                                                                            *
 * Program ver.  : 3.0                                                                               *
 * Created by    : SharpDevelop                                                                      *
 * Code author   : Perić Željko                                                                      *
 * Code language : C#                                                                                *
 * Date created  : 25.04.2012                                                                        *
 * Time created  : 13:32                                                                             *
 *                                                                                                   *
 *                                                                                                   *
 * Program Description :  This program is based on a two simple logical games,                       *
 *                        Slider Puzzle and Jigsaw Puzzle.                                           *
 *                                                                                                   *
 *                        Basic image is divided to nine equal peaces,                               *
 *                        that are randomly placed at 3 x 3 square table.                            *
 *                                                                                                   *
 *                        Goal of the game is to put image together by                               *
 *                        placing image peaces to the right place.                                   *
 *                                                                                                   *
 *                        This can be done by switching places of pair of image peaces,              *
 *                        that would be Jigsaw Puzzle.                                               *
 *                                                                                                   *
 *                        The other way is to push (slide) image peaces on the table                 *
 *                        by using one free square on the table until all image peaces               *
 *                        come to the right place. This would be Slider Puzzle.                      *
 *                                                                                                   *
 *                                                                                                   *
 *                                                                                                   *
 *                                                                              All the best,        *
 *                                                                              Author               *
 *                                                                                                   *
 *****************************************************************************************************/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class MainForm : Form
    {
        #region-   Global Variables   -
        //
        // Image resource manager
        //
        ComponentResourceManager Images =
            new ComponentResourceManager(typeof(GameAssets));

        //
        // Translations resource manager
        //
        ComponentResourceManager Translations =
            new ComponentResourceManager(typeof(MainForm));

        //
        // Image resource counter
        //
        int Next_Image_Counter = 53;

        // Table 'Puzzle_Tiles'  contains nine
        // pictures cropped from original image.
        PictureBox [] Puzzle_Tiles;

        // Table 'Puzzle_Table' contains
        // current tile index set on fixed table position
        //
        // Fixed table positions with tile indexes
        // 
        //      1 2 3
        //
        //   1  2 3 4
        //   2  8 7 6
        //   3  5 1 9
        //
        //
        int [,] Puzzle_Table;

        // Table 'Tile_Index_Permutations' contains
        // all possible permutations of indexes of tiles
        string [] Tile_Index_Permutations;

        //
        // One of possible index permutation
        //
        const string Initial_Permutation = "123456789";

        //
        // One of possible index permutation
        //
        const string Final_Permutation = "123456789";

        //
        // Index of hidden tile inside puzzle
        // that would be the blank square on the table
        //
        // This is relative only in case of Slider Puzzle
        //
        int Blank_Tile_Index = 9;

        //
        // Variables for storing values for swapping tiles
        //
        int Swap_Source = 0;
        int Swap_Source_X = 0;
        int Swap_Source_Y = 0;

        bool Swap = false;

        bool Game_Is_Running = false;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            Initialize_Tables();

            Initialize_Tiles();

            Initialize_Menu();

            Find_All_Tile_Index_Permutations();
        }

        #region-   Initialization   -
        void Set_Table_Squares_Visibility(bool Visible, int Milliseconds)
        {
            Square1.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square2.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square3.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square4.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square5.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square6.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square7.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square8.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
            Square9.Visible = Visible;
            Refresh();
            Pause(Milliseconds);
        }

        void Set_Tile_Index_Visibility(bool Visible, int Milliseconds)
        {
            Index1.Visible = Visible;
            Index1.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index2.Visible = Visible;
            Index2.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index3.Visible = Visible;
            Index3.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index4.Visible = Visible;
            Index4.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index5.Visible = Visible;
            Index5.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index6.Visible = Visible;
            Index6.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index7.Visible = Visible;
            Index7.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index8.Visible = Visible;
            Index8.BringToFront();
            Refresh();
            Pause(Milliseconds);
            Index9.Visible = Visible;
            Index9.BringToFront();
            Refresh();
            Pause(Milliseconds);

            Refresh();
        }

        void Initialize_Tables()
        {
            int i;
            int j;

            int position;

            // Table 'Puzzle_Tiles'  contains nine
            // pictures cropped from original image.
            Puzzle_Tiles = new PictureBox[10];
            Puzzle_Tiles.Initialize();

            // Set initial values for table elements
            position = 0;
            for (position = 0; position < 10; position++)
            {
                Puzzle_Tiles[position] = new PictureBox();
                Puzzle_Tiles[position].Image = null;
            }

            // Table 'Puzzle_Table' contains
            // current tile index set on fixed table position
            Puzzle_Table = new int[5, 5];
            Puzzle_Table.Initialize();

            // Set initial values for table elements
            i = 0;
            j = 0;
            for (i = 0; i < 5; i++)
            {
                for (j = 0; j < 5; j++)
                {
                    Puzzle_Table[i, j] = -1;
                }
            }

            // Table 'Tile_Index_Permutations' contains
            // all possible permutations of indexes of tiles
            Tile_Index_Permutations = new string[362880];
            Tile_Index_Permutations.Initialize();

            // Set initial values for table elements
            i = 0;
            for (i = 0; i < 362880; i++)
            {
                Tile_Index_Permutations[i] = null;
            }
        }

        void Initialize_Tiles()
        {
            //
            // Cut original image to nine rectangular peaces
            // that have identical dimensions and set them to
            // the elements of table 'Puzzle_Tiles'.
            //
            // Placed by it's indexes on fixed positions
            // inside Puzzle_Table, in the below shown order,
            // they constitute original image.
            //
            //       1 2 3
            //       4 5 6
            //       7 8 9
            //

            // Original image
            Bitmap Original_Image;

            // Original image pixel format
            PixelFormat Pixel_Format;

            // Tile rectangle
            RectangleF Tile;

            int Tile_Height;// Tile height
            int Tile_Width; // Tile width

            // Set new original image and it's pixel format
            Original_Image = new Bitmap(BackgroundImage);
            Pixel_Format = Original_Image.PixelFormat;

            // Set new Tile
            Tile_Height = Original_Image.Height / 3;
            Tile_Width = Original_Image.Width / 3;

            Tile = new RectangleF();

            Tile.Width = Tile_Width;
            Tile.Height = Tile_Height;

            //
            // Set values to elements of table Puzzle_Tiles
            //

            // 0. Tile, empty tile
            Puzzle_Tiles[0].Image = null;

            // 1. Tile
            Tile.X = 0;
            Tile.Y = 0;
            Puzzle_Tiles[1].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 2. Tile
            Tile.X = Tile_Width;
            Tile.Y = 0;
            Puzzle_Tiles[2].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 3. Tile
            Tile.X = 2 * Tile_Width;
            Tile.Y = 0;
            Puzzle_Tiles[3].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 4. Tile
            Tile.X = 0;
            Tile.Y = Tile_Height;
            Puzzle_Tiles[4].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 5. Tile
            Tile.X = Tile_Width;
            Tile.Y = Tile_Height;
            Puzzle_Tiles[5].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 6. Tile
            Tile.X = 2 * Tile_Width;
            Tile.Y = Tile_Height;
            Puzzle_Tiles[6].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 7. Tile
            Tile.X = 0;
            Tile.Y = 2 * Tile_Height;
            Puzzle_Tiles[7].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 8. Tile
            Tile.X = Tile_Width;
            Tile.Y = 2 * Tile_Height;
            Puzzle_Tiles[8].Image = Original_Image.Clone(Tile, Pixel_Format);

            // 9. Tile
            Tile.X = 2 * Tile_Width;
            Tile.Y = 2 * Tile_Height;
            Puzzle_Tiles[9].Image = Original_Image.Clone(Tile, Pixel_Format);
        }

        void Initialize_Menu(bool IsGameRunning = false)
        {
            Puzzle_Options.AutoClose = IsGameRunning;

            NewPuzzle.Text = IsGameRunning 
                ? Translations.GetString("NewMixText") 
                : Translations.GetString("NewPuzzle.Text");

            Separator1.Visible = !IsGameRunning;
            SliderPuzzle.Visible = !IsGameRunning;
            JigsawPuzzle.Visible = !IsGameRunning;

            Separator2.Visible = !IsGameRunning;
            PreviousImage.Visible = !IsGameRunning;
            NextImage.Visible = !IsGameRunning;
            LoadImage.Visible = !IsGameRunning;

            Separator3.Visible = !IsGameRunning;
            NewPuzzle.Visible = true;

            Separator4.Visible = IsGameRunning;
            PuzzleSolution.Visible = IsGameRunning;

            Separator5.Visible = IsGameRunning;
            PuzzleHelp.Visible = IsGameRunning;

            if (SliderPuzzle.Checked)
            {
                RandomBlankTileIndex.Visible = !IsGameRunning;
                Separator6.Visible = !IsGameRunning;
                this.Text = Translations.GetString("MainWindowTitleSlider");
            }
            else
            {
                RandomBlankTileIndex.Visible = false;
                Separator6.Visible = false;
                this.Text = Translations.GetString("MainWindowTitleJigsaw");
            }

            Puzzle_Options.Refresh();
        }        
        #endregion

        #region-   Find all possible permutations of indexes of tiles   -
        #region-   Rules for determining puzzle solvability   -
        //
        // !!! Important !!!
        //
        // Because of the way of solving, Slider puzzle,
        // is not solvable for each possible tile order
        // Number of inversions of tile indexes enables us to determine
        // puzzle solvability for selected tile order
        //
        // Explanation :
        // Suppose that this should be the final tile order
        //
        //				1 2 3
        //				4 5 6
        //				7 8 0
        //
        // where 0 represents empty field for sliding tiles
        //
        // Now, observe next initial tile order
        //
        //				1 2 3
        //				4 5 7
        //				6 8 0
        //
        // Order of tiles in the first row is as it should be,
        // Second row is good up to number 7 that should be after number 6
        // This state is called 'INVERSION' inside tile order
        //
        // If number of inversions inside
        // selected initial tile order is EVEN, puzzle can be solved
        //
        // If number of inversions inside
        // selected initial tile order is ODD, puzzle can't be solved
        //
        // Next example:
        // Observe this initial tile order
        //
        //				2 4 3
        //				1 0 6
        //				7 5 8
        //
        // There are next inversions
        //
        // 			 2 should be after 1
        // 			 4 should be after 3 and 1
        // 			 3 should be after 1
        // 			 6 should be after 5
        // 			 7 should be after 5
        //
        // Six inversions in total, that is even number of inversions
        // so the puzzle is solvable for this initial tile order
        //
        // Notice !
        // While inversion counting, empty field with number 0 is not considered
        //
        //
        #endregion

        void Find_All_Tile_Index_Permutations()
        {
            //
            // Set cursor image to 'Wait'
            //
            Cursor = Cursors.WaitCursor;

            //
            // Find all possible permutations of indexes of tiles
            // For nine tiles it would be 362880 permutations

            // Elements of first permutation
            const string first_permutation = "123456789";

            // Elements of last permutation
            const string last_permutation = "987654321";

            char [] elements;// table for storing elements of new permutation
            int number_of_elements;// elements counter

            string permutation = string.Empty;// new permutation

            int n = 0;// permutation counter
            int k = 0;// counter

            elements = first_permutation.ToCharArray();
            number_of_elements = first_permutation.Length;

            Tile_Index_Permutations[n] = first_permutation; // first permutation

            do
            {
                //
                // Find next permutation
                //
                n++;
                k = 0;
                while (k == 0)
                {
                    k = Next_Permutation(ref elements, number_of_elements);
                }
                permutation = new string(elements);

                Tile_Index_Permutations[n] = permutation;
            }
            while (permutation != last_permutation);

            //
            // Set cursor image to 'Hand'
            //
            Cursor = Cursors.Hand;
        }

        int Next_Permutation(ref char[] elements, int number_of_elements)
        {
            //
            // Original algorithm for finding permutations
            // Jeffrey A. Johnson, Brigham Young University-Hawaii Campus
            // http://www.freewebs.com/permute/soda_submit.html
            //
            int n = number_of_elements - 1;
            int m = number_of_elements - 1;
            char c = ' ';

            while ((n > 0) & (elements[n] <= elements[n - 1]))
            {
                n--;
            }

            n--;
            if (n < 0)
            {
                return 0;
            }

            m = number_of_elements - 1;
            while ((m > n) & (elements[m] <= elements[n]))
            {
                m--;
            }

            c = elements[n];
            elements[n] = elements[m];
            elements[m] = c;

            number_of_elements--;
            n++;
            while (number_of_elements > n)
            {

                c = elements[number_of_elements];
                elements[number_of_elements] = elements[n];
                elements[n] = c;

                n++;
                number_of_elements--;
            }
            return 1;
        }

        string Next_Solvable_Tile_Order(int blank_tile_index)
        {
            //
            // Find next permutation of tile indexes
            // or initial tile order
            // 
            // Initial tile order:
            //
            //     Order of indexes         Permutation
            //  of tiles at puzzle table
            //
            //          1 2 3
            //          4 5 6                123456789
            //          7 8 9
            //

            int i = 0;// loop counter
            int j = 0;// loop counter
            int n = 0;// loop counter

            int number_of_inversions = 0;// inversion counter !!!

            string next_tile_order = string.Empty;

            bool puzlle_not_solvable = true;

            n = Select_Initial_Tile_Order_Index();
            while (puzlle_not_solvable)
            {
                n++;
                if (n == 362880)
                { n = 1; }

                next_tile_order = Tile_Index_Permutations[n];
                //
                // Check puzzle solvability for the next tile order
                // 
                // Count inversions inside tile order
                //
                number_of_inversions = 0;
                for (i = 0; i < 8; i++)
                {
                    if (next_tile_order[i].ToString() != blank_tile_index.ToString())
                    {
                        for (j = i + 1; j < 9; j++)
                        {
                            if (next_tile_order[j].ToString() != blank_tile_index.ToString())
                            {
                                if (next_tile_order[i] > next_tile_order[j])
                                {
                                    number_of_inversions++;
                                }
                            }
                        }
                    }
                }
                // If number of inversions is even, puzzle is solvable
                if (number_of_inversions % 2 == 0)
                {
                    puzlle_not_solvable = false;
                }
            }
            //
            //
            //
            return next_tile_order;
        }
        #endregion

        #region- Main Methods   -
        void Mix_Tiles()
        {
            //
            // Mix tiles 33 times
            //
            int Counter = 0;
            int Milliseconds = 0;
            int Initial_Tile_Order_Index = 0;

            string Selected_Tile_Order = string.Empty;

            for (Counter = 0; Counter < 33; Counter++)
            {
                Initial_Tile_Order_Index = Select_Initial_Tile_Order_Index();
                Selected_Tile_Order = Tile_Index_Permutations[Initial_Tile_Order_Index];
                Set_Tile_Index_To_Current_Table_Position(Selected_Tile_Order);
                Set_Tiles_To_Table();
                Set_Tile_Index_To_Help_Fields();
                Milliseconds = 100;
                Pause(Milliseconds);
            }
        }

        int Select_Blank_Tile_Index()
        {
            //
            // Randomly select blank tile index
            // It will be blank field on puzzle table
            //
            Random Random_Number_Generator = new Random();

            int Blank_Tile_Index = 0;

            int Random_Number = 0;

            Random_Number = Random_Number_Generator.Next(1, 10);

            Blank_Tile_Index = Random_Number;

            return Blank_Tile_Index;
        }

        int Select_Initial_Tile_Order_Index()
        {
            //
            // Randomly select initial tile order index
            //
            Random Random_Number_Generator = new Random();

            int Initial_Tile_Order_Index = 0;

            int Random_Number = 0;

            Random_Number = Random_Number_Generator.Next(1, 362880);

            Initial_Tile_Order_Index = Random_Number;

            return Initial_Tile_Order_Index;
        }

        void Set_Tile_Index_To_Current_Table_Position(string Permutation)
        {
            Puzzle_Table[1, 1] = int.Parse(Permutation.Substring(0, 1));
            Puzzle_Table[1, 2] = int.Parse(Permutation.Substring(1, 1));
            Puzzle_Table[1, 3] = int.Parse(Permutation.Substring(2, 1));
            Puzzle_Table[2, 1] = int.Parse(Permutation.Substring(3, 1));
            Puzzle_Table[2, 2] = int.Parse(Permutation.Substring(4, 1));
            Puzzle_Table[2, 3] = int.Parse(Permutation.Substring(5, 1));
            Puzzle_Table[3, 1] = int.Parse(Permutation.Substring(6, 1));
            Puzzle_Table[3, 2] = int.Parse(Permutation.Substring(7, 1));
            Puzzle_Table[3, 3] = int.Parse(Permutation.Substring(8, 1));
        }

        void Set_Tile_Index_To_Help_Fields()
        {
            // 
            // Set current tile index order
            //
            string Current_Tile_Index_Order = string.Empty;

            Current_Tile_Index_Order =
                Puzzle_Table[1, 1].ToString() +
                Puzzle_Table[1, 2].ToString() +
                Puzzle_Table[1, 3].ToString() +
                Puzzle_Table[2, 1].ToString() +
                Puzzle_Table[2, 2].ToString() +
                Puzzle_Table[2, 3].ToString() +
                Puzzle_Table[3, 1].ToString() +
                Puzzle_Table[3, 2].ToString() +
                Puzzle_Table[3, 3].ToString();

            //
            // Replace blank tile index with selected index of empty field
            // 
            if (SliderPuzzle.Checked)
            {
                Current_Tile_Index_Order =
                    Current_Tile_Index_Order.Replace("0", Blank_Tile_Index.ToString());
            }

            //
            // Set current tile index to help field
            //
            Index1.Text = Current_Tile_Index_Order.Substring(0, 1);
            Index2.Text = Current_Tile_Index_Order.Substring(1, 1);
            Index3.Text = Current_Tile_Index_Order.Substring(2, 1);
            Index4.Text = Current_Tile_Index_Order.Substring(3, 1);
            Index5.Text = Current_Tile_Index_Order.Substring(4, 1);
            Index6.Text = Current_Tile_Index_Order.Substring(5, 1);
            Index7.Text = Current_Tile_Index_Order.Substring(6, 1);
            Index8.Text = Current_Tile_Index_Order.Substring(7, 1);
            Index9.Text = Current_Tile_Index_Order.Substring(8, 1);

            Refresh();
        }

        void Set_Tiles_To_Table()
        {
            //
            // According to tile index,
            // set tile image to table squares
            //
            Square1.Image = Puzzle_Tiles[Puzzle_Table[1, 1]].Image;
            Square2.Image = Puzzle_Tiles[Puzzle_Table[1, 2]].Image;
            Square3.Image = Puzzle_Tiles[Puzzle_Table[1, 3]].Image;
            Square4.Image = Puzzle_Tiles[Puzzle_Table[2, 1]].Image;
            Square5.Image = Puzzle_Tiles[Puzzle_Table[2, 2]].Image;
            Square6.Image = Puzzle_Tiles[Puzzle_Table[2, 3]].Image;
            Square7.Image = Puzzle_Tiles[Puzzle_Table[3, 1]].Image;
            Square8.Image = Puzzle_Tiles[Puzzle_Table[3, 2]].Image;
            Square9.Image = Puzzle_Tiles[Puzzle_Table[3, 3]].Image;

            Refresh();
        }

        void Check_Solution()
        {
            //
            // Check is puzzle solved
            //
            string Current_Tile_Order = string.Empty;

            Current_Tile_Order =
                Puzzle_Table[1, 1].ToString() +
                Puzzle_Table[1, 2].ToString() +
                Puzzle_Table[1, 3].ToString() +
                Puzzle_Table[2, 1].ToString() +
                Puzzle_Table[2, 2].ToString() +
                Puzzle_Table[2, 3].ToString() +
                Puzzle_Table[3, 1].ToString() +
                Puzzle_Table[3, 2].ToString() +
                Puzzle_Table[3, 3].ToString();

            //
            // Replace blank tile index with selected index of empty field
            // 
            if (SliderPuzzle.Checked)
            {
                Current_Tile_Order =
                    Current_Tile_Order.Replace("0", Blank_Tile_Index.ToString());
            }

            if (Current_Tile_Order == Final_Permutation)
            {
                Set_Tile_Index_To_Current_Table_Position(Current_Tile_Order);
                Set_Tiles_To_Table();
                Refresh();
                MessageBox.Show(
                    Translations.GetString("PuzzleIsSolved"),
                    Translations.GetString("Excellent"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Refresh();
                Puzzle_Is_Solved();
            }
        }

        void Puzzle_Is_Solved()
        {
            Cursor = Cursors.WaitCursor;
            Refresh();

            int Milliseconds = 0;

            Milliseconds = 10;
            Set_Tile_Index_Visibility(false, Milliseconds);

            Milliseconds = 150;
            Set_Table_Squares_Visibility(false, Milliseconds);

            Game_Is_Running = false;
            Initialize_Menu(IsGameRunning: Game_Is_Running);

            Cursor = Cursors.Hand;
            Refresh();
        }

        void Pause(int Milliseconds)
        {
            // Pause
            Stopwatch Clock = new Stopwatch();
            Clock.Start();
            while (Clock.ElapsedMilliseconds < Milliseconds)
            {
                // Empty loop
            }
            Clock.Stop();
            Clock.Reset();
        }
        #endregion

        #region-   Show possible slide direction   -
        void SquareMouseLeave(object sender, EventArgs e)
        {
            if (SliderPuzzle.Checked)
            {
                Cursor = Cursors.Hand;
            }
        }

        void Square1MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(1, 1);
        }

        void Square2MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(1, 2);
        }

        void Square3MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(1, 3);
        }

        void Square4MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(2, 1);
        }

        void Square5MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(2, 2);
        }

        void Square6MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(2, 3);
        }

        void Square7MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(3, 1);
        }

        void Square8MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(3, 2);
        }

        void Square9MouseEnter(object sender, EventArgs e)
        {
            Show_Direction(3, 3);
        }

        void Show_Direction(int Table_X, int Table_Y)
        {
            if (Puzzle_Table[Table_X, Table_Y] != 0 && SliderPuzzle.Checked)
            {
                if (Puzzle_Table[Table_X, Table_Y - 1] == 0)
                {
                    Cursor = Cursors.PanWest;
                    Refresh();
                }
                else if (Puzzle_Table[Table_X - 1, Table_Y] == 0)
                {
                    Cursor = Cursors.PanNorth;
                    Refresh();
                }
                else if (Puzzle_Table[Table_X + 1, Table_Y] == 0)
                {
                    Cursor = Cursors.PanSouth;
                    Refresh();
                }
                else if (Puzzle_Table[Table_X, Table_Y + 1] == 0)
                {
                    Cursor = Cursors.PanEast;
                    Refresh();
                }
            }
            else if (Puzzle_Table[Table_X, Table_Y] == 0 && SliderPuzzle.Checked)
            {
                Cursor = Cursors.Hand;
                Refresh();
            }
        }
        #endregion

        #region-   Replace tile table positions   -
        void Square1Click(object sender, EventArgs e)
        {
            Replace_Tile(1, 1);
        }

        void Square2Click(object sender, EventArgs e)
        {
            Replace_Tile(1, 2);
        }

        void Square3Click(object sender, EventArgs e)
        {
            Replace_Tile(1, 3);
        }

        void Square4Click(object sender, EventArgs e)
        {
            Replace_Tile(2, 1);
        }

        void Square5Click(object sender, EventArgs e)
        {
            Replace_Tile(2, 2);
        }

        void Square6Click(object sender, EventArgs e)
        {
            Replace_Tile(2, 3);
        }

        void Square7Click(object sender, EventArgs e)
        {
            Replace_Tile(3, 1);
        }

        void Square8Click(object sender, EventArgs e)
        {
            Replace_Tile(3, 2);
        }

        void Square9Click(object sender, EventArgs e)
        {
            Replace_Tile(3, 3);
        }

        void Replace_Tile(int Table_X, int Table_Y)
        {
            if (Puzzle_Table[Table_X, Table_Y] != 0 && SliderPuzzle.Checked)
            {
                if (Puzzle_Table[Table_X, Table_Y - 1] == 0)
                {
                    Puzzle_Table[Table_X, Table_Y - 1] = Puzzle_Table[Table_X, Table_Y];
                    Puzzle_Table[Table_X, Table_Y] = 0;
                    Set_Tiles_To_Table();
                    Set_Tile_Index_To_Help_Fields();
                    Show_Direction(Table_X, Table_Y);
                }
                else if (Puzzle_Table[Table_X - 1, Table_Y] == 0)
                {
                    Puzzle_Table[Table_X - 1, Table_Y] = Puzzle_Table[Table_X, Table_Y];
                    Puzzle_Table[Table_X, Table_Y] = 0;
                    Set_Tiles_To_Table();
                    Set_Tile_Index_To_Help_Fields();
                    Show_Direction(Table_X, Table_Y);
                }
                else if (Puzzle_Table[Table_X + 1, Table_Y] == 0)
                {
                    Puzzle_Table[Table_X + 1, Table_Y] = Puzzle_Table[Table_X, Table_Y];
                    Puzzle_Table[Table_X, Table_Y] = 0;
                    Set_Tiles_To_Table();
                    Set_Tile_Index_To_Help_Fields();
                    Show_Direction(Table_X, Table_Y);
                }
                else if (Puzzle_Table[Table_X, Table_Y + 1] == 0)
                {
                    Puzzle_Table[Table_X, Table_Y + 1] = Puzzle_Table[Table_X, Table_Y];
                    Puzzle_Table[Table_X, Table_Y] = 0;
                    Set_Tiles_To_Table();
                    Set_Tile_Index_To_Help_Fields();
                    Show_Direction(Table_X, Table_Y);
                }

                Check_Solution();
            }
            else if (JigsawPuzzle.Checked)
            {
                if (Swap)
                {
                    Cursor = Cursors.Hand;
                    Refresh();

                    Puzzle_Table[Swap_Source_X, Swap_Source_Y] = Puzzle_Table[Table_X, Table_Y];

                    Puzzle_Table[Table_X, Table_Y] = Swap_Source;

                    Swap = false;

                    Set_Tiles_To_Table();
                    Set_Tile_Index_To_Help_Fields();

                    Check_Solution();
                }
                else
                {
                    Cursor = Cursors.NoMoveHoriz;
                    Refresh();

                    Swap = true;
                    Swap_Source_X = Table_X;
                    Swap_Source_Y = Table_Y;
                    Swap_Source = Puzzle_Table[Table_X, Table_Y];
                }
            }
        }
        #endregion

        #region-   Menu options   -
        void New_Puzzle(object sender, EventArgs e)
        {
            Puzzle_Options.Close();

            int Milliseconds = 0;
            int Initial_Tile_Order_Index = 0;
            string Selected_Tile_Order = string.Empty;

            Cursor = Cursors.WaitCursor;
            Refresh();

            bool IsFirstRun = (NewPuzzle.Text == Translations.GetString("NewPuzzle.Text"));

            Game_Is_Running = true;
            Initialize_Menu(IsGameRunning: Game_Is_Running);

            if (IsFirstRun)
            {
                Selected_Tile_Order = Initial_Permutation;
                Set_Tile_Index_To_Current_Table_Position(Selected_Tile_Order);
                Set_Tiles_To_Table();
                Milliseconds = 300;
                Set_Table_Squares_Visibility(true, Milliseconds);
                Refresh();
            }

            Mix_Tiles();

            Blank_Tile_Index = (RandomBlankTileIndex.Checked && SliderPuzzle.Checked) 
                ? Select_Blank_Tile_Index() 
                : 9;

            if (SliderPuzzle.Checked)
            {
                Selected_Tile_Order = Next_Solvable_Tile_Order(Blank_Tile_Index);
                Selected_Tile_Order = Selected_Tile_Order.Replace(Blank_Tile_Index.ToString(), "0");
            }
            else
            {
                Initial_Tile_Order_Index = Select_Initial_Tile_Order_Index();
                Selected_Tile_Order = Tile_Index_Permutations[Initial_Tile_Order_Index];
            }

            Set_Tile_Index_To_Current_Table_Position(Selected_Tile_Order);
            Set_Tiles_To_Table();
            Set_Tile_Index_To_Help_Fields();

            Cursor = Cursors.Hand;
            Refresh();
        }

        void Load_Image(object sender, EventArgs e)
        {
            DialogResult Choice;

            Choice = Dialog_Load_Image.ShowDialog();

            if (Choice == DialogResult.OK)
            {
                BackgroundImage = new Bitmap(Dialog_Load_Image.FileName);

                Initialize_Tiles();
            }

            Cursor = Cursors.Hand;
            Refresh();
        }

        void Puzzle_Solution(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();
            Puzzle_Is_Solved();
        }

        void Puzzle_Help(object sender, EventArgs e)
        {
            int Miliseconds = 0;

            Cursor = Cursors.Hand;
            Refresh();

            //
            // If this option is selected
            // tile indexes are shown to player as help
            //
            if (PuzzleHelp.Checked)
            {
                Miliseconds = 150;
                Set_Tile_Index_Visibility(true, Miliseconds);
            }
            else
            {
                Miliseconds = 10;
                Set_Tile_Index_Visibility(false, Miliseconds);
            }
        }

        void Previous_Image(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();

            Next_Image_Counter--;
            if (Next_Image_Counter < 1)
            {
                Next_Image_Counter = 72;
            }
            BackgroundImage = (System.Drawing.Image)
                (Images.GetObject(Next_Image_Counter.ToString()));

            Initialize_Tiles();

            Refresh();
        }

        void Next_Image(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();

            Next_Image_Counter++;
            if (Next_Image_Counter > 72)
            {
                Next_Image_Counter = 1;
            }
            BackgroundImage = (System.Drawing.Image)
                (Images.GetObject(Next_Image_Counter.ToString()));

            Initialize_Tiles();

            Refresh();
        }

        void Puzzle_Slider(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();
            if (SliderPuzzle.Checked)
            {
                JigsawPuzzle.Checked = false;
                this.Text = Translations.GetString("MainWindowTitleSlider");
                Separator6.Visible = true;
                RandomBlankTileIndex.Visible = true;
            }
            else
            {
                JigsawPuzzle.Checked = true;
                this.Text = Translations.GetString("MainWindowTitleJigsaw");
                Separator6.Visible = false;
                RandomBlankTileIndex.Visible = false;
            }
        }

        void Puzzle_Jigsaw(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();
            if (JigsawPuzzle.Checked)
            {
                SliderPuzzle.Checked = false;
                this.Text = Translations.GetString("MainWindowTitleJigsaw");
                Separator6.Visible = false;
                RandomBlankTileIndex.Visible = false;
            }
            else
            {
                SliderPuzzle.Checked = true;
                this.Text = Translations.GetString("MainWindowTitleSlider");
                Separator6.Visible = true;
                RandomBlankTileIndex.Visible = true;
            }
        }
        #endregion

        #region-   Show original tile image by click on tile   -
        void Index1MouseDown(object sender, MouseEventArgs e)
        {
            Square1.Hide();
        }

        void Index1MouseUp(object sender, MouseEventArgs e)
        {
            Square1.Show();
        }

        void Index2MouseDown(object sender, MouseEventArgs e)
        {
            Square2.Hide();
        }

        void Index2MouseUp(object sender, MouseEventArgs e)
        {
            Square2.Show();
        }

        void Index3MouseDown(object sender, MouseEventArgs e)
        {
            Square3.Hide();
        }

        void Index3MouseUp(object sender, MouseEventArgs e)
        {
            Square3.Show();
        }

        void Index4MouseDown(object sender, MouseEventArgs e)
        {
            Square4.Hide();
        }

        void Index4MouseUp(object sender, MouseEventArgs e)
        {
            Square4.Show();
        }

        void Index5MouseDown(object sender, MouseEventArgs e)
        {
            Square5.Hide();
        }

        void Index5MouseUp(object sender, MouseEventArgs e)
        {
            Square5.Show();
        }

        void Index6MouseDown(object sender, MouseEventArgs e)
        {
            Square6.Hide();
        }

        void Index6MouseUp(object sender, MouseEventArgs e)
        {
            Square6.Show();
        }

        void Index7MouseDown(object sender, MouseEventArgs e)
        {
            Square7.Hide();
        }

        void Index7MouseUp(object sender, MouseEventArgs e)
        {
            Square7.Show();
        }

        void Index8MouseDown(object sender, MouseEventArgs e)
        {
            Square8.Hide();
        }

        void Индекс8MouseUp(object sender, MouseEventArgs e)
        {
            Square8.Show();
        }

        void Index9MouseDown(object sender, MouseEventArgs e)
        {
            Square9.Hide();
        }

        void Index9MouseUp(object sender, MouseEventArgs e)
        {
            Square9.Show();
        }
        #endregion

        #region -   Language Selection   -

        void ChangeLanguage(string cultureCode)
        {
            // Set the new culture for the current thread
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);

            ComponentResourceManager res = new ComponentResourceManager(typeof(MainForm));

            // Update main menu items and their sub-items
            foreach (ToolStripItem mainItem in Puzzle_Options.Items)
            {
                res.ApplyResources(mainItem, mainItem.Name);

                // Check if this item has a sub-menu (like your "Menu options")
                if (mainItem is ToolStripMenuItem menuItem && menuItem.HasDropDownItems)
                {
                    foreach (ToolStripItem subItem in menuItem.DropDownItems)
                    {
                        res.ApplyResources(subItem, subItem.Name);
                    }
                }
            }

            // Update form title and other specific UI elements
            res.ApplyResources(this, "$this");

            // Refresh static strings in code
            Initialize_Menu(IsGameRunning: Game_Is_Running);
        }

        //
        // Change language to English
        //
        void EnglishLanguageClick(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            EnglishLanguage.Checked = true;
            SerbianLatinLanguage.Checked = false;
            ChangeLanguage(""); // Default/Neutral is English
            Refresh();
        }

        //
        // Change language to Serbian (Latin)
        //
        void SerbianLatinLanguageClick(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            Refresh();
            SerbianLatinLanguage.Checked = true;
            EnglishLanguage.Checked = false;
            ChangeLanguage("sr-Latn");
            Refresh();
        }
        #endregion

        private void Close_Menu(object sender, EventArgs e)
        {
            Puzzle_Options.Close();
            Refresh();
        }
    }
}
/************************************************************************
 * Program Licence :                                                    *
 *                                                                      *
 * Copyright 2012 , Perić Željko                                        *
 * (periczeljkosmederevo@yahoo.com)                                     *
 *                                                                      *
 * According to it's main purpose , this program is licensed            *
 * under the therms of 'Free Software' licence agreement.               *
 *                                                                      *
 * If You do not know what those therms applies to                      *
 * please read explanation at the following link :                      *
 * (http://www.gnu.org/philosophy/free-sw.html.en)                      *
 *                                                                      *
 * Since it is Free Software this program has no warranty of any kind.  *
 ************************************************************************
 * Ethical Notice :                                                     *
 *                                                                      *
 * It is not ethical to change program code signed by it's author       *
 * and then to redistribute it under the same author name ,             *
 * especially if it is incorrect.                                       *
 *                                                                      *
 * It is recommended that if You make improvement in program code ,     *
 * to make remarks of it and then to sign it with Your own name ,       *
 * for further redistribution as new major version of program.          *
 *                                                                      *
 * Author name and references of old program code version should be     *
 * kept , for tracking history of program development.                  *
 *                                                                      *
 * For any further information please contact code author at his email. *
 ************************************************************************/

/************************************
 * List Of Revisions                *
 ************************************
 * Mајоr revision of version 1.0    *
 * Author 21.03.2014                *
 * New algorithm for finding        *
 * selecting and memorizing,        *
 * all solvable solutions of puzzle *
 * Visibility of Menu options are   *
 * changed, depending on selection  *
 * Help on index click developed    *
 * new comments added               *
 * New version number 2.0           *
 ************************************
 * Minоr revision of version 2.0    *
 * Author 11.06.2016                *
 * New menu option added            *
 * Previous image selection         *
 * New version number 2.0           *
 ************************************
 * Mајоr revision of version 2.0    *
 * Refactoring & UI Optimization    *
 * Author 24.03.2026                *
 * Introduced language switching    *
 * Unified Initialize_Menu method   *
 * Added Game_Is_Running state      *
 * Code cleanup and typo fixes      *
 * New version number 3.0           *
 ************************************/
