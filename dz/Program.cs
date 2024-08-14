using System;

class Program
{
    static void Main(string[] args)
    {
        char[,] board = new char[3, 3]; // Игровое пооле 3x3
        InitializeBoard(board); // Инициализация пустого поля

        char currentPlayer = 'X'; // Первый игрок - X

        while (true)
        {
            Console.Clear();
            PrintBoard(board); // Вывод текущегюо состояния поля

            // Ввод хода игрока
            Console.WriteLine($"Игрок {currentPlayer}, введите координаты вашего хода (строка и столбец): ");
            int row = int.Parse(Console.ReadLine()) - 1;
            int col = int.Parse(Console.ReadLine()) - 1;

            // Проверка корректности ввода
            if (row < 0 || row > 2 || col < 0 || col > 2 || board[row, col] != ' ')
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                continue;
            }

            // Обновление игрового поля
            board[row, col] = currentPlayer;

            // Проверка на победу
            if (CheckWin(board, currentPlayer))
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine($"Игрок {currentPlayer} победил!");
                break;
            }

            // Проверка на ничью
            if (IsBoardFull(board))
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine("Ничья!");
                break;
            }

            // Смена. игрока
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }

    static void InitializeBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' ';
            }
        }
    }

    static void PrintBoard(char[,] board)
    {
        Console.WriteLine("  1 2 3");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + 1 + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine("  -----");
        }
    }

    static bool CheckWin(char[,] board, char player)
    {
        // Проверка строокк и столббцов
        for (int i = 0; i < 3; i++)
        {
            if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                (board[0, i] == player && board[1, i] == player && board[2, i] == player))
            {
                return true;
            }
        }

        // Проверка диагоналей
        if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
            (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
        {
            return true;
        }

        return false;
    }

    static bool IsBoardFull(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
}
