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
using System.Windows.Forms;

namespace Puzzle
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
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
