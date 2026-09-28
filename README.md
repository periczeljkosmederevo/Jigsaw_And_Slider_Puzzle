# Jigsaw_And_Slider_Puzzle

**Jigsaw_And_Slider_Puzzle** is a Windows Forms implementation of traditional logic puzzle games that allows users to play both **Jigsaw** and **Slider** puzzle modes using custom images divided into rectangular tiles.

---

### 🧩 Introduction

Puzzles are very popular logic games with various types and varieties. Here is presented one kind of puzzle that is the most famous: the integration of two or more two-dimensional elements that have a small part of the original picture drawn on them, in order to obtain the whole original image.

The elements are formed by taking an original image on an orthogonal panel and cutting it into many smaller, same-sized rectangular parts known as **tiles**.

* **Jigsaw Puzzle Mode:** Tiles are randomly lined up on the board, and the player solves the puzzle by swapping/replacing pairs of selected tiles to reconstruct the original image.
* **Slider Puzzle Mode:** The order of randomly placed tiles can be changed by hiding one tile to create a free space on the board. The player solves the puzzle by sliding adjacent tiles into the empty space to bring each tile to its original position.

---

### 🚀 Key Features

* **Dual Game Modes:** Play both classic **Jigsaw** (tile swap) and **Slider** (tile slide) puzzle modes.
* **Image Processing & Tile Generation:** Automatically slices any input image into equal-sized grid tiles based on chosen dimensions.
* **Randomized Board State:** Shuffles tiles randomly at the start of each game session.
* **Puzzle Store / Library (`PuzzleStore`):** Integrated library for managing and selecting puzzle images or configurations.
* **Modular Solution Structure:** Solution is split into `Puzzle` (core application) and `PuzzleStore` (data/resource handling) projects.

---

### 🛠 Solution Structure

The Visual Studio solution (`Puzzle.sln`) consists of two main projects:

* **`Puzzle`**: Contains the main user interface, Windows Forms controls, game board rendering, and gameplay logic for both Jigsaw and Slider modes.
* **`PuzzleStore`**: Handles image storage, game presets, loading, and managing puzzle configurations.

---

### 💻 Getting Started

#### Prerequisites

* Visual Studio 2026 (or compatible modern version).
* .NET Framework / .NET SDK with Windows Forms support.

#### Installation & Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/periczeljkosmederevo/Jigsaw_And_Slider_Puzzle.git
   ```
2. Open `Puzzle.sln` in Visual Studio.
3. Build the solution (**Ctrl + Shift + B**).
4. Run the application (**F5** or click **Start**).

---

### 🎮 Usage

1. **Launch the Application:** Run the `Puzzle` executable from Visual Studio or the build output directory.
2. **Select Game Mode:** Choose between **Jigsaw Puzzle** mode (click to swap tiles) or **Slider Puzzle** mode (click tiles adjacent to the empty slot to slide them).
3. **Select an Image:** Choose a default image from `PuzzleStore` or load a custom picture.
4. **Solve the Puzzle:** Rearrange the tiles until the full image is completely restored!

---

### 📄 License

* This project is licensed under the [CC0-1.0 license (Public Domain)](https://creativecommons.org/publicdomain/zero/1.0/).
* To the extent possible under law, the author(s) have dedicated all copyright and related rights to this software to the public domain worldwide.
* Feel free to use, modify, and distribute the code without any restrictions.

---

### ✉️ Support & Contact

For technical inquiries or administrative follow-ups, please contact:

* **Name:** Željko Perić
* **Email:** periczeljkosmederevo@yahoo.com