using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Code
{
    class Program
    {
        public static bool overwrite()
        {
            bool ow = false;
            Console.WriteLine("This file already exists");
            Console.WriteLine("Do you want to overwrite?");
            Console.WriteLine("Enter 'Y' for yes");
            Console.WriteLine("Enter 'N' for no");
            ConsoleKeyInfo choice = Console.ReadKey(true);
            if (choice.Key == ConsoleKey.N)
            {
                ow = false;
            }
            else if (choice.Key == ConsoleKey.Y)
            {
                ow = true;
            }
            return ow;
        }
        public static void saveMaze(int size, Cell[,] maze)
        {
            try
            {
                Console.Clear();
                string text = draw(maze, size);
                Console.WriteLine("Enter a file name");
                string filename = Console.ReadLine();
                if (File.Exists(filename))
                {
                    Console.WriteLine("This file already exists");
                    Console.WriteLine("Do you want to overwrite?");
                    Console.WriteLine("Enter 'Y' for yes");
                    Console.WriteLine("Enter 'N' for no");
                    ConsoleKeyInfo choice = Console.ReadKey(true);
                    if (choice.Key == ConsoleKey.N)
                    {
                        menu1();
                    }
                    else if(choice.Key == ConsoleKey.Y)
                    {
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            sw.Write(text);
                        }
                        Console.Clear();
                        Console.WriteLine("File have been overwritten");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        saveMaze(size, maze);
                    }
                }
                else
                {
                    Console.Clear();
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        sw.Write(text);
                    }
                    Console.WriteLine("File saved successfully");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                
                Console.WriteLine("Maze has been saved");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid file name input");
                Console.Write(".");
                System.Threading.Thread.Sleep(100);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("Press any key to continuee");
                Console.ReadKey();
                saveMaze(size, maze);
            }
            menu1();
        }
        static Stack<Cell> cellstack = new Stack<Cell>();
        public static void menu(int inSize, Cell[,] maze)
        {
            bool exit = false;
            int option = inSize + 6;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("MENU");
            Console.WriteLine("    Save this maze");
            Console.WriteLine("    Generate new maze");
            Console.WriteLine("    Load a saved maze");
            Console.WriteLine("    Solve maze using arrows");
            Console.WriteLine("    Solve maze using algorithm");
            Console.WriteLine("    Terminate program");
            Console.SetCursorPosition(0, (inSize + 6));
            Console.Write(">");
            do
            {

                ConsoleKeyInfo choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.DownArrow)
                {
                    if (option > inSize + 10)
                    {

                    }
                    else
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop = option;
                        Console.Write(" ");
                        Console.CursorTop += 1;
                        Console.CursorLeft = 0;
                        Console.Write(">");
                        option += 1;
                    }
                }
                else if (choice.Key == ConsoleKey.UpArrow)
                {
                    if (option < inSize + 7)
                    {

                    }
                    else
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop = option;
                        Console.Write(" ");
                        Console.CursorTop -= 1;
                        Console.CursorLeft = 0;
                        Console.Write(">");
                        option -= 1;
                    }
                }
                else if (choice.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 22);
                    if (option == inSize + 6)
                    {
                        saveMaze(inSize, maze);
                    }
                    if (option == inSize + 7)
                    {
                        Console.Clear();
                        generateMaze();
                    }
                    if (option == inSize + 8)
                    {
                        loadMaze();
                    }
                    if(option == inSize + 9)
                    {
                        move();
                    }
                    if (option == inSize + 11)
                    {
                        Environment.Exit(1);
                    }
                }
            }
            while (exit == false);
        }
        public static string draw(Cell[,] maze, int size)
        {
            
            string output = "";
            for (int i = 0; i < size; i++)
            {
                output += "__";
            }
            output += "\n";
            for (int i = 0; i < size; i++)
            {
                output += "|";
                for (int j = 0; j < size; j++)
                {
                    if (maze[i, j].walldown)
                    {
                        output += "_";
                    }
                    else if (maze[i, j].walldown == false)
                    {
                        output += " ";
                    }
                    if (maze[i, j].wallright)
                    {
                        output += "|";
                    }
                    else if (maze[i, j].wallright == false)
                    {
                        output += " ";
                    }

                }
                output += "\n";
            }
            
            return output;
        }
        static void loadMaze()
        {
            Console.Clear();
            Console.WriteLine("enter file name");
            string filename = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (sr.EndOfStream == false)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("file could not be found try again");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                menu1();
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            menu1();
        }
        static void menu1()
        {

            Console.Clear();
            bool exit = false;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("MENU");
            Console.WriteLine("    Generate maze");
            Console.WriteLine("    Load saved maze");
            Console.WriteLine("    Exit");
            int option = 1;
            Console.CursorTop = option;
            Console.Write(">");
            do
            {

                ConsoleKeyInfo choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.DownArrow)
                {
                    if (option > 2)
                    {

                    }
                    else
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop = option;
                        Console.Write(" ");
                        Console.CursorTop += 1;
                        Console.CursorLeft = 0;
                        Console.Write(">");
                        option += 1;
                    }
                }
                else if (choice.Key == ConsoleKey.UpArrow)
                {
                    if (option < 2)
                    {

                    }
                    else
                    {
                        Console.CursorLeft = 0;
                        Console.CursorTop = option;
                        Console.Write(" ");
                        Console.CursorTop -= 1;
                        Console.CursorLeft = 0;
                        Console.Write(">");
                        option -= 1;
                    }
                }
                else if (choice.Key == ConsoleKey.Enter)
                {
                    Console.SetCursorPosition(0, 22);
                    if (option == 2)
                    {
                        loadMaze();
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        menu1();
                    }
                    if (option == 3)
                    {
                        Environment.Exit(1);
                    }
                    if (option == 1)
                    {

                        exit = true;
                        generateMaze();
                    }
                }
            }
            while (exit == false);
        }
        public static int size;
        static int getMazesize()
        {

            try
            {
                Console.WriteLine("enter maze size");
                
                size = int.Parse(Console.ReadLine());
                if(size < 2)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid entry TRY AGAIN");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
                getMazesize();
            }
            return size;
        }
        public static Cell[,] maze = new Cell[size,size];
        static void generateMaze()
        {
            int size = getMazesize();
            Cell[,] maze = new Cell[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    maze[i, j] = new Cell(i, j);
                }
            }
            Console.Clear();

            Cell currentcell = maze[0, 0];
            Cell neighbour = maze[0, 0];
            currentcell.visited = true;
            cellstack.Push(currentcell);
            cellstack.Push(currentcell);
            recurse(currentcell, neighbour, maze, size);
            Console.Clear();
            Console.WriteLine(draw(maze, size));
            
            menu(size, maze);
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            menu1();
        }
        public static void move()
        {
            Console.SetCursorPosition(1, 0);
            Console.Write("O");
            do
            {
                ConsoleKeyInfo choice = Console.ReadKey(true);
                if (choice.Key == ConsoleKey.RightArrow)
                {
                    if (maze[1,1].wallright == false)
                    {
                        Console.Write("_");
                        Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                    }
                    else
                    {

                    }
                }
            }
            while (true);
        }
        public static void recurse(Cell currentcell, Cell neighbour, Cell[,] maze, int size)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(draw(maze, size));
            while (cellstack.Count >= 2)
            {
                List<Cell> neighbours = getneighbours(currentcell, maze);
                Cell randomNeighbour = new Cell(0, 0);
                randomNeighbour = getUnvisitedneighbour(getneighbours(currentcell, maze));
                if (randomNeighbour.visited == true)
                {
                    randomNeighbour = getUnvisitedneighbour(getneighbours(currentcell, maze));
                }
                if (checkVisited(neighbours) == false)
                {
                    Cell.breakwall(currentcell.row, currentcell.col, randomNeighbour.row, randomNeighbour.col, ref maze);
                    currentcell = randomNeighbour;
                    currentcell.visited = true;
                    cellstack.Push(currentcell);
                    recurse(currentcell, neighbour, maze, size);
                }
                else
                {
                    cellstack.Pop();
                    recurse(cellstack.Peek(), neighbour, maze, size);
                }
            }

        }
        public static Random rand = new Random();
        public static bool checkVisited(List<Cell> neighbours)
        {
            bool visited = true;
            for (int i = 0; i < neighbours.Count; i++)
            {
                if (neighbours[i].visited == false)
                {
                    visited = false;
                }
            }
            return visited;
        }
        public static List<Cell> getneighbours(Cell currentcell, Cell[,] maze)
        {
            List<Cell> theneighbours = new List<Cell>();
            if (currentcell.col > 0)
            {
                theneighbours.Add(maze[currentcell.row, currentcell.col - 1]);
            }
            if (currentcell.col < Math.Sqrt(maze.Length) - 1)
            {
                theneighbours.Add(maze[currentcell.row, currentcell.col + 1]);
            }
            if (currentcell.row > 0)
            {
                theneighbours.Add(maze[currentcell.row - 1, currentcell.col]);
            }
            if (currentcell.row < Math.Sqrt(maze.Length) - 1)
            {
                theneighbours.Add(maze[currentcell.row + 1, currentcell.col]);
            }
            return theneighbours;
        }
        static Random random = new Random();

        public static Cell getUnvisitedneighbour(List<Cell> neighbours)
        {
            int num = random.Next(0, neighbours.Count);
            Cell unvisitedNeighbour = neighbours[1];
            if (num == 0 && neighbours[0].visited == false)
            {
                unvisitedNeighbour = neighbours[0];
            }
            else if (num == 1 && neighbours[1].visited == false)
            {
                unvisitedNeighbour = neighbours[1];
            }
            else if (num == 2 && neighbours[2].visited == false)
            {
                unvisitedNeighbour = neighbours[2];
            }
            else if (num == 3 && neighbours[3].visited == false)
            {
                unvisitedNeighbour = neighbours[3];
            }

            return unvisitedNeighbour;
        }
        public static List<Cell> getAllneighbours(Cell currentCell, Cell[,] maze)
        {
            List<Cell> neighbours = new List<Cell>();
            neighbours.Add(maze[currentCell.row, currentCell.col + 1]);
            neighbours.Add(maze[currentCell.row, currentCell.col - 1]);
            neighbours.Add(maze[currentCell.row + 1, currentCell.col]);
            neighbours.Add(maze[currentCell.row + 1, currentCell.col]);
            return neighbours;
        }
        public static void pathFind(Cell[,] maze, Cell currentCell)
        {
            int path = 0;
            foreach (Cell cell in maze)
            {
                List<Cell> neighbours = getneighbours(currentCell, maze);
                if(currentCell.walldown == true)
                {
                }
            }
        }
    }
}
