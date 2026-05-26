namespace console_mini_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerRow = 1;
            int playerCol = 3;
            int sum = 3;
            bool flag = true;
            Console.CursorVisible = false;
            char[,] map =
            {
                {'█' , '█' , '█' , '█' , '█' , '█' , '█' , '█' , '█' , '█'},
                {'█' , '█' , ' ' , ' ' , ' ' , '█' , '$' , '█' , '█' , '█'},
                {'█' , ' ' , ' ' , '█' , ' ' , ' ' , ' ' , ' ' , '█' , '█'},
                {'█' , ' ' , '█' , ' ' , '█' , '$' , '█' , ' ' , '$' , '█'},
                {'█' , '█' , '█' , '█' , '█' , '█' , '█' , '█' , '█' , '█'},
            };
            ConsoleColor defaultColor = Console.ForegroundColor;
            while (flag)
            {
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        switch (map[i, j])
                        {
                            case '█':
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.Write(map[i, j]);
                                    Console.ForegroundColor = defaultColor;
                                }
                                break;
                            case '$':
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(map[i, j]);
                                    Console.ForegroundColor = defaultColor;
                                }
                                break;
                            default:
                                Console.Write(map[i, j]);
                                break;
                        }
                    }
                    Console.WriteLine();
                }
                if (sum < 1)
                {
                    flag = false;
                    Console.Clear();
                    Console.WriteLine("Победа");
                    WinMelody();
                    break;
                }
                Console.SetCursorPosition(0, 5);
                Console.Write($"Сталось: {sum}");

                Console.SetCursorPosition(playerRow, playerCol);
                Console.Write("#");
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        Go(map, ref playerRow, ref playerCol, ref sum, Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Go(map, ref playerRow, ref playerCol, ref sum, Direction.Down);
                        break;
                    case ConsoleKey.RightArrow:
                        Go(map, ref playerRow, ref playerCol, ref sum, Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        Go(map, ref playerRow, ref playerCol, ref sum, Direction.Left);
                        break;
                }
                Console.Clear();

            }
            static void CatchMelody()
            {
                Console.Beep(880, 100);
                Console.Beep(1109, 100);
                Console.Beep(1320, 320);
            }
            static void WinMelody()
            {
                Console.Beep(523, 200);
                Console.Beep(659, 200);
                Console.Beep(784, 400);
                Console.Beep(1047, 150);
                Console.Beep(784, 800);
            }
            static void Go(char[,] map, ref int y, ref int x, ref int sum, Direction dir)
            {
                int beepGoodHz = 3000;
                int beepBadHz = 500;
                int beepTime = 150;
                char stepTo = ' ';
                switch (dir)
                {
                    case Direction.Up:
                        {
                            stepTo = map[x - 1, y];
                            if (stepTo == '█')
                                Console.Beep(beepBadHz, beepTime);
                            else if (stepTo == '$')
                            {
                                CatchMelody();
                                map[x - 1, y] = ' ';
                                x--;
                                sum--;
                            }
                            else
                            {
                                x--;
                                Console.Beep(beepGoodHz, beepTime);
                            }
                            break;
                        }
                    case Direction.Down:
                        {
                            stepTo = map[x + 1, y];
                            if (stepTo == '█')
                                Console.Beep(beepBadHz, beepTime);
                            else if (stepTo == '$')
                            {
                                CatchMelody();
                                map[x + 1, y] = ' ';
                                x++;
                                sum--;
                            }
                            else
                            {
                                Console.Beep(beepGoodHz, beepTime);
                                x++;
                            }
                            break;
                        }
                    case Direction.Right:
                        {
                            stepTo = map[x, y + 1];
                            if (stepTo == '█')
                                Console.Beep(beepBadHz, beepTime);
                            else if (stepTo == '$')
                            {
                                CatchMelody();
                                map[x, y + 1] = ' ';
                                y++;
                                sum--;
                            }
                            else
                            {
                                Console.Beep(beepGoodHz, beepTime);
                                y++;
                            }
                            break;
                        }
                    case Direction.Left:
                        {
                            stepTo = map[x, y - 1];
                            if (stepTo == '█')
                                Console.Beep(beepBadHz, beepTime);
                            else if (stepTo == '$')
                            {
                                CatchMelody();
                                map[x, y - 1] = ' ';
                                y--;
                                sum--;
                            }
                            else
                            {
                                Console.Beep(beepGoodHz, beepTime);
                                y--;
                            }
                            break;
                        }
                }

            }
        }
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
    }
}
