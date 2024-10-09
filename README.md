Maze Generation and Solving Console Application
This project is a C# console application that generates, saves, loads, and solves mazes. The application allows users to interact with the maze through a simple text-based interface. It uses a backtracking algorithm to generate the maze and offers various options for the user to save, load, or navigate the maze.

Features
Maze Generation: Generates a random maze of a user-defined size using a recursive backtracking algorithm.
Save/Load Maze: Users can save the generated maze to a file and load previously saved mazes.
Solve Maze: Provides the option to solve the maze using arrow keys or an automated algorithm.
Menu Navigation: Includes a menu system for easy navigation between different options.

Menu Options
Generate Maze: This option generates a new maze of user-defined size. The size must be at least 2x2.
Save Maze: Allows the user to save the generated maze to a text file. If the file already exists, the user will be prompted to overwrite or cancel.
Load Maze: Loads a previously saved maze from a text file and displays it.
Solve Maze: The user can navigate the maze using the arrow keys or solve it automatically with the algorithm.
Exit: Exits the application.
Saving and Loading
When saving a maze, the program asks for a filename. If a file with the same name already exists, you can choose to overwrite it or cancel.
When loading, the program reads from the specified file and displays the maze. It will prompt you if the file cannot be found.
Key Classes
Program.cs
saveMaze: Saves the generated maze as a text file.
loadMaze: Loads a saved maze from a file.
generateMaze: Generates a maze using the recursive backtracking algorithm.
move: Allows the user to navigate the maze using arrow keys.
recurse: Core function for generating the maze by backtracking.
draw: Converts the maze into a string representation for saving and display.
Cell.cs
Cell: Represents a single cell in the maze grid. It has properties for walls and visited status.
breakwall: Static method to remove walls between two neighboring cells during maze generation.

Error Handling
The program includes basic error handling:

Invalid maze size inputs prompt the user to try again.
Invalid file names for saving/loading are caught and handled with an appropriate message.
