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
namespace Puzzle
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Square1 = new System.Windows.Forms.PictureBox();
            this.Square2 = new System.Windows.Forms.PictureBox();
            this.Square3 = new System.Windows.Forms.PictureBox();
            this.Square4 = new System.Windows.Forms.PictureBox();
            this.Square5 = new System.Windows.Forms.PictureBox();
            this.Square6 = new System.Windows.Forms.PictureBox();
            this.Square7 = new System.Windows.Forms.PictureBox();
            this.Square8 = new System.Windows.Forms.PictureBox();
            this.Square9 = new System.Windows.Forms.PictureBox();
            this.Puzzle_Options = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SliderPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.JigsawPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PreviousImage = new System.Windows.Forms.ToolStripMenuItem();
            this.NextImage = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NewPuzzle = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PuzzleHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PuzzleSolution = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator6 = new System.Windows.Forms.ToolStripSeparator();
            this.RandomBlankTileIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.Dialog_Load_Image = new System.Windows.Forms.OpenFileDialog();
            this.Index1 = new System.Windows.Forms.Button();
            this.Index2 = new System.Windows.Forms.Button();
            this.Index3 = new System.Windows.Forms.Button();
            this.Index4 = new System.Windows.Forms.Button();
            this.Index5 = new System.Windows.Forms.Button();
            this.Index6 = new System.Windows.Forms.Button();
            this.Index7 = new System.Windows.Forms.Button();
            this.Index8 = new System.Windows.Forms.Button();
            this.Index9 = new System.Windows.Forms.Button();
            this.EnglishLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.SerbianLatinLanguage = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Square1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square9)).BeginInit();
            this.Puzzle_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // Square1
            // 
            resources.ApplyResources(this.Square1, "Square1");
            this.Square1.BackColor = System.Drawing.SystemColors.Control;
            this.Square1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square1.Name = "Square1";
            this.Square1.TabStop = false;
            this.Square1.Click += new System.EventHandler(this.Square1Click);
            this.Square1.MouseEnter += new System.EventHandler(this.Square1MouseEnter);
            this.Square1.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square2
            // 
            resources.ApplyResources(this.Square2, "Square2");
            this.Square2.BackColor = System.Drawing.SystemColors.Control;
            this.Square2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square2.Name = "Square2";
            this.Square2.TabStop = false;
            this.Square2.Click += new System.EventHandler(this.Square2Click);
            this.Square2.MouseEnter += new System.EventHandler(this.Square2MouseEnter);
            this.Square2.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square3
            // 
            resources.ApplyResources(this.Square3, "Square3");
            this.Square3.BackColor = System.Drawing.SystemColors.Control;
            this.Square3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square3.Name = "Square3";
            this.Square3.TabStop = false;
            this.Square3.Click += new System.EventHandler(this.Square3Click);
            this.Square3.MouseEnter += new System.EventHandler(this.Square3MouseEnter);
            this.Square3.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square4
            // 
            resources.ApplyResources(this.Square4, "Square4");
            this.Square4.BackColor = System.Drawing.SystemColors.Control;
            this.Square4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square4.Name = "Square4";
            this.Square4.TabStop = false;
            this.Square4.Click += new System.EventHandler(this.Square4Click);
            this.Square4.MouseEnter += new System.EventHandler(this.Square4MouseEnter);
            this.Square4.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square5
            // 
            resources.ApplyResources(this.Square5, "Square5");
            this.Square5.BackColor = System.Drawing.SystemColors.Control;
            this.Square5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square5.Name = "Square5";
            this.Square5.TabStop = false;
            this.Square5.Click += new System.EventHandler(this.Square5Click);
            this.Square5.MouseEnter += new System.EventHandler(this.Square5MouseEnter);
            this.Square5.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square6
            // 
            resources.ApplyResources(this.Square6, "Square6");
            this.Square6.BackColor = System.Drawing.SystemColors.Control;
            this.Square6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square6.Name = "Square6";
            this.Square6.TabStop = false;
            this.Square6.Click += new System.EventHandler(this.Square6Click);
            this.Square6.MouseEnter += new System.EventHandler(this.Square6MouseEnter);
            this.Square6.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square7
            // 
            resources.ApplyResources(this.Square7, "Square7");
            this.Square7.BackColor = System.Drawing.SystemColors.Control;
            this.Square7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square7.Name = "Square7";
            this.Square7.TabStop = false;
            this.Square7.Click += new System.EventHandler(this.Square7Click);
            this.Square7.MouseEnter += new System.EventHandler(this.Square7MouseEnter);
            this.Square7.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square8
            // 
            resources.ApplyResources(this.Square8, "Square8");
            this.Square8.BackColor = System.Drawing.SystemColors.Control;
            this.Square8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square8.Name = "Square8";
            this.Square8.TabStop = false;
            this.Square8.Click += new System.EventHandler(this.Square8Click);
            this.Square8.MouseEnter += new System.EventHandler(this.Square8MouseEnter);
            this.Square8.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Square9
            // 
            resources.ApplyResources(this.Square9, "Square9");
            this.Square9.BackColor = System.Drawing.SystemColors.Control;
            this.Square9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Square9.Name = "Square9";
            this.Square9.TabStop = false;
            this.Square9.Click += new System.EventHandler(this.Square9Click);
            this.Square9.MouseEnter += new System.EventHandler(this.Square9MouseEnter);
            this.Square9.MouseLeave += new System.EventHandler(this.SquareMouseLeave);
            // 
            // Puzzle_Options
            // 
            this.Puzzle_Options.BackColor = System.Drawing.Color.White;
            this.Puzzle_Options.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTitle,
            this.Separator1,
            this.SliderPuzzle,
            this.JigsawPuzzle,
            this.Separator2,
            this.PreviousImage,
            this.NextImage,
            this.LoadImage,
            this.Separator3,
            this.NewPuzzle,
            this.Separator4,
            this.PuzzleHelp,
            this.Separator5,
            this.PuzzleSolution,
            this.Separator6,
            this.RandomBlankTileIndex});
            this.Puzzle_Options.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.Puzzle_Options.Name = "contextMenuStrip1";
            this.Puzzle_Options.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Puzzle_Options.ShowCheckMargin = true;
            this.Puzzle_Options.ShowImageMargin = false;
            resources.ApplyResources(this.Puzzle_Options, "Puzzle_Options");
            // 
            // MenuTitle
            // 
            this.MenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnglishLanguage,
            this.SerbianLatinLanguage});
            this.MenuTitle.Name = "MenuTitle";
            resources.ApplyResources(this.MenuTitle, "MenuTitle");
            // 
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            resources.ApplyResources(this.Separator1, "Separator1");
            // 
            // SliderPuzzle
            // 
            this.SliderPuzzle.Checked = true;
            this.SliderPuzzle.CheckOnClick = true;
            this.SliderPuzzle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SliderPuzzle.Name = "SliderPuzzle";
            resources.ApplyResources(this.SliderPuzzle, "SliderPuzzle");
            this.SliderPuzzle.Click += new System.EventHandler(this.Puzzle_Slider);
            // 
            // JigsawPuzzle
            // 
            this.JigsawPuzzle.CheckOnClick = true;
            this.JigsawPuzzle.Name = "JigsawPuzzle";
            resources.ApplyResources(this.JigsawPuzzle, "JigsawPuzzle");
            this.JigsawPuzzle.Click += new System.EventHandler(this.Puzzle_Jigsaw);
            // 
            // Separator2
            // 
            this.Separator2.Name = "Separator2";
            resources.ApplyResources(this.Separator2, "Separator2");
            // 
            // PreviousImage
            // 
            this.PreviousImage.Name = "PreviousImage";
            resources.ApplyResources(this.PreviousImage, "PreviousImage");
            this.PreviousImage.Click += new System.EventHandler(this.Previous_Image);
            // 
            // NextImage
            // 
            this.NextImage.Name = "NextImage";
            resources.ApplyResources(this.NextImage, "NextImage");
            this.NextImage.Click += new System.EventHandler(this.Next_Image);
            // 
            // LoadImage
            // 
            this.LoadImage.Name = "LoadImage";
            resources.ApplyResources(this.LoadImage, "LoadImage");
            this.LoadImage.Click += new System.EventHandler(this.Load_Image);
            // 
            // Separator3
            // 
            this.Separator3.Name = "Separator3";
            resources.ApplyResources(this.Separator3, "Separator3");
            // 
            // NewPuzzle
            // 
            this.NewPuzzle.Name = "NewPuzzle";
            resources.ApplyResources(this.NewPuzzle, "NewPuzzle");
            this.NewPuzzle.Click += new System.EventHandler(this.New_Puzzle);
            // 
            // Separator4
            // 
            this.Separator4.Name = "Separator4";
            resources.ApplyResources(this.Separator4, "Separator4");
            // 
            // PuzzleHelp
            // 
            this.PuzzleHelp.CheckOnClick = true;
            this.PuzzleHelp.Name = "PuzzleHelp";
            resources.ApplyResources(this.PuzzleHelp, "PuzzleHelp");
            this.PuzzleHelp.Click += new System.EventHandler(this.Puzzle_Help);
            // 
            // Separator5
            // 
            this.Separator5.Name = "Separator5";
            resources.ApplyResources(this.Separator5, "Separator5");
            // 
            // PuzzleSolution
            // 
            this.PuzzleSolution.Name = "PuzzleSolution";
            resources.ApplyResources(this.PuzzleSolution, "PuzzleSolution");
            this.PuzzleSolution.Click += new System.EventHandler(this.Puzzle_Solution);
            // 
            // Separator6
            // 
            this.Separator6.Name = "Separator6";
            resources.ApplyResources(this.Separator6, "Separator6");
            // 
            // RandomBlankTileIndex
            // 
            this.RandomBlankTileIndex.CheckOnClick = true;
            this.RandomBlankTileIndex.Name = "RandomBlankTileIndex";
            resources.ApplyResources(this.RandomBlankTileIndex, "RandomBlankTileIndex");
            // 
            // Dialog_Load_Image
            // 
            resources.ApplyResources(this.Dialog_Load_Image, "Dialog_Load_Image");
            // 
            // Index1
            // 
            resources.ApplyResources(this.Index1, "Index1");
            this.Index1.BackColor = System.Drawing.SystemColors.Control;
            this.Index1.FlatAppearance.BorderSize = 0;
            this.Index1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index1.Name = "Index1";
            this.Index1.UseVisualStyleBackColor = true;
            this.Index1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index1MouseDown);
            this.Index1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index1MouseUp);
            // 
            // Index2
            // 
            resources.ApplyResources(this.Index2, "Index2");
            this.Index2.BackColor = System.Drawing.SystemColors.Control;
            this.Index2.FlatAppearance.BorderSize = 0;
            this.Index2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index2.Name = "Index2";
            this.Index2.UseVisualStyleBackColor = false;
            this.Index2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index2MouseDown);
            this.Index2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index2MouseUp);
            // 
            // Index3
            // 
            resources.ApplyResources(this.Index3, "Index3");
            this.Index3.BackColor = System.Drawing.SystemColors.Control;
            this.Index3.FlatAppearance.BorderSize = 0;
            this.Index3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index3.Name = "Index3";
            this.Index3.UseVisualStyleBackColor = false;
            this.Index3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index3MouseDown);
            this.Index3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index3MouseUp);
            // 
            // Index4
            // 
            resources.ApplyResources(this.Index4, "Index4");
            this.Index4.BackColor = System.Drawing.SystemColors.Control;
            this.Index4.FlatAppearance.BorderSize = 0;
            this.Index4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index4.Name = "Index4";
            this.Index4.UseVisualStyleBackColor = false;
            this.Index4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index4MouseDown);
            this.Index4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index4MouseUp);
            // 
            // Index5
            // 
            resources.ApplyResources(this.Index5, "Index5");
            this.Index5.BackColor = System.Drawing.SystemColors.Control;
            this.Index5.FlatAppearance.BorderSize = 0;
            this.Index5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index5.Name = "Index5";
            this.Index5.UseVisualStyleBackColor = false;
            this.Index5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index5MouseDown);
            this.Index5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index5MouseUp);
            // 
            // Index6
            // 
            resources.ApplyResources(this.Index6, "Index6");
            this.Index6.BackColor = System.Drawing.SystemColors.Control;
            this.Index6.FlatAppearance.BorderSize = 0;
            this.Index6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index6.Name = "Index6";
            this.Index6.UseVisualStyleBackColor = false;
            this.Index6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index6MouseDown);
            this.Index6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index6MouseUp);
            // 
            // Index7
            // 
            resources.ApplyResources(this.Index7, "Index7");
            this.Index7.BackColor = System.Drawing.SystemColors.Control;
            this.Index7.FlatAppearance.BorderSize = 0;
            this.Index7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index7.Name = "Index7";
            this.Index7.UseVisualStyleBackColor = false;
            this.Index7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index7MouseDown);
            this.Index7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index7MouseUp);
            // 
            // Index8
            // 
            resources.ApplyResources(this.Index8, "Index8");
            this.Index8.BackColor = System.Drawing.SystemColors.Control;
            this.Index8.FlatAppearance.BorderSize = 0;
            this.Index8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index8.Name = "Index8";
            this.Index8.UseVisualStyleBackColor = false;
            this.Index8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index8MouseDown);
            this.Index8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Индекс8MouseUp);
            // 
            // Index9
            // 
            resources.ApplyResources(this.Index9, "Index9");
            this.Index9.BackColor = System.Drawing.SystemColors.Control;
            this.Index9.FlatAppearance.BorderSize = 0;
            this.Index9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Index9.Name = "Index9";
            this.Index9.UseVisualStyleBackColor = false;
            this.Index9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Index9MouseDown);
            this.Index9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Index9MouseUp);
            // 
            // EnglishLanguage
            // 
            this.EnglishLanguage.Checked = true;
            this.EnglishLanguage.CheckOnClick = true;
            this.EnglishLanguage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnglishLanguage.Name = "EnglishLanguage";
            resources.ApplyResources(this.EnglishLanguage, "EnglishLanguage");
            this.EnglishLanguage.Click += new System.EventHandler(this.EnglishLanguageClick);
            // 
            // SerbianLatinLanguage
            // 
            this.SerbianLatinLanguage.Name = "SerbianLatinLanguage";
            resources.ApplyResources(this.SerbianLatinLanguage, "SerbianLatinLanguage");
            this.SerbianLatinLanguage.Click += new System.EventHandler(this.SerbianLatinLanguageClick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this, "$this");
            this.ContextMenuStrip = this.Puzzle_Options;
            this.Controls.Add(this.Index9);
            this.Controls.Add(this.Square9);
            this.Controls.Add(this.Index3);
            this.Controls.Add(this.Index6);
            this.Controls.Add(this.Index8);
            this.Controls.Add(this.Index7);
            this.Controls.Add(this.Square8);
            this.Controls.Add(this.Index5);
            this.Controls.Add(this.Index4);
            this.Controls.Add(this.Square7);
            this.Controls.Add(this.Index2);
            this.Controls.Add(this.Index1);
            this.Controls.Add(this.Square6);
            this.Controls.Add(this.Square5);
            this.Controls.Add(this.Square4);
            this.Controls.Add(this.Square3);
            this.Controls.Add(this.Square2);
            this.Controls.Add(this.Square1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.Square1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Square9)).EndInit();
            this.Puzzle_Options.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripMenuItem PreviousImage;
		private System.Windows.Forms.ToolStripSeparator Separator2;
		private System.Windows.Forms.ToolStripMenuItem JigsawPuzzle;
		private System.Windows.Forms.ToolStripMenuItem SliderPuzzle;
		private System.Windows.Forms.ToolStripSeparator Separator1;
		private System.Windows.Forms.ToolStripMenuItem MenuTitle;
		private System.Windows.Forms.ToolStripSeparator Separator5;
		private System.Windows.Forms.ToolStripMenuItem PuzzleHelp;
		private System.Windows.Forms.Button Index9;
		private System.Windows.Forms.Button Index8;
		private System.Windows.Forms.Button Index7;
		private System.Windows.Forms.Button Index6;
		private System.Windows.Forms.Button Index5;
		private System.Windows.Forms.Button Index4;
		private System.Windows.Forms.Button Index3;
		private System.Windows.Forms.Button Index2;
		private System.Windows.Forms.Button Index1;
		private System.Windows.Forms.ToolStripMenuItem RandomBlankTileIndex;
		private System.Windows.Forms.ToolStripSeparator Separator6;
		private System.Windows.Forms.ToolStripMenuItem NextImage;
		private System.Windows.Forms.ToolStripSeparator Separator3;
		private System.Windows.Forms.ToolStripMenuItem PuzzleSolution;
		private System.Windows.Forms.ToolStripSeparator Separator4;
		private System.Windows.Forms.OpenFileDialog Dialog_Load_Image;
		private System.Windows.Forms.ToolStripMenuItem LoadImage;
		private System.Windows.Forms.ToolStripMenuItem NewPuzzle;
		private System.Windows.Forms.ContextMenuStrip Puzzle_Options;
		private System.Windows.Forms.PictureBox Square9;
		private System.Windows.Forms.PictureBox Square8;
		private System.Windows.Forms.PictureBox Square7;
		private System.Windows.Forms.PictureBox Square6;
		private System.Windows.Forms.PictureBox Square5;
		private System.Windows.Forms.PictureBox Square4;
		private System.Windows.Forms.PictureBox Square3;
		private System.Windows.Forms.PictureBox Square2;
		private System.Windows.Forms.PictureBox Square1;
        private System.Windows.Forms.ToolStripMenuItem EnglishLanguage;
        private System.Windows.Forms.ToolStripMenuItem SerbianLatinLanguage;
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
