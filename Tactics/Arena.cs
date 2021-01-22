using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Tactics
{
    public class ArenaMapper
    {
        public static readonly int size = 8;

        public static void DrawArena(Gladiator spartacus, Gladiator opponent)
        {
            ArenaCell[,] arenaCells = new ArenaCell[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    char cGladiatorA = ' '; char cGladiatorB = ' ';
                    char cGladiatorC = ' '; char cGladiatorD = ' ';

                    if (spartacus.Position.X == x && spartacus.Position.Y == y)
                    {
                        switch (spartacus.Position.Facing)
                        {
                            case Direction.North:
                                cGladiatorA = '|'; cGladiatorB = ' ';
                                cGladiatorC = 'Ø'; cGladiatorD = ' '; break;
                            case Direction.East:
                                cGladiatorA = ' '; cGladiatorB = ' ';
                                cGladiatorC = 'Ø'; cGladiatorD = '-'; break;
                            case Direction.South:
                                cGladiatorA = 'Ø'; cGladiatorB = ' ';
                                cGladiatorC = '|'; cGladiatorD = ' '; break;
                            case Direction.West:
                                cGladiatorA = '-'; cGladiatorB = 'Ø';
                                cGladiatorC = ' '; cGladiatorD = ' '; break;
                            case Direction.NorthEast:
                                cGladiatorA = ' '; cGladiatorB = '/';
                                cGladiatorC = 'Ø'; cGladiatorD = ' '; break;
                            case Direction.SouthEast:
                                cGladiatorA = 'Ø'; cGladiatorB = ' ';
                                cGladiatorC = ' '; cGladiatorD = '\\'; break;
                            case Direction.SouthWest:
                                cGladiatorA = ' '; cGladiatorB = 'Ø';
                                cGladiatorC = '/'; cGladiatorD = ' '; break;
                            case Direction.NorthWest:
                                cGladiatorA = '\\'; cGladiatorB = ' ';
                                cGladiatorC = ' '; cGladiatorD = 'Ø'; break;
                        }
                    }

                    if (opponent.Position.X == x && opponent.Position.Y == y)
                    {
                        switch (opponent.Position.Facing)
                        {
                            case Direction.North:
                                cGladiatorA = '|'; cGladiatorB = ' ';
                                cGladiatorC = 'O'; cGladiatorD = ' '; break;
                            case Direction.East:
                                cGladiatorA = ' '; cGladiatorB = ' ';
                                cGladiatorC = 'O'; cGladiatorD = '-'; break;
                            case Direction.South:
                                cGladiatorA = 'O'; cGladiatorB = ' ';
                                cGladiatorC = '|'; cGladiatorD = ' '; break;
                            case Direction.West:
                                cGladiatorA = '-'; cGladiatorB = 'O';
                                cGladiatorC = ' '; cGladiatorD = ' '; break;
                            case Direction.NorthEast:
                                cGladiatorA = '\\'; cGladiatorB = ' ';
                                cGladiatorC = ' '; cGladiatorD = 'O'; break;
                            case Direction.SouthEast:
                                cGladiatorA = ' '; cGladiatorB = 'O';
                                cGladiatorC = '/'; cGladiatorD = ' '; break;
                            case Direction.SouthWest:
                                cGladiatorA = 'O'; cGladiatorB = ' ';
                                cGladiatorC = ' '; cGladiatorD = '\\'; break;
                            case Direction.NorthWest:
                                cGladiatorA = ' '; cGladiatorB = '/';
                                cGladiatorC = 'O'; cGladiatorD = ' '; break;
                        }
                    }

                    arenaCells[x, y] = CreateArenaCell(cGladiatorA, cGladiatorB,
                        cGladiatorC, cGladiatorD);

                    if (y == size - 1)
                    { arenaCells[x, y].Bottom = "·····"; }

                    if (x == size - 1)
                    {
                        arenaCells[x, y].Top = "......";
                        arenaCells[x, y].Middle1 = $": {cGladiatorA}{cGladiatorB} :";
                        arenaCells[x, y].Middle2 = $": {cGladiatorC}{cGladiatorD} :";
                    }
                    if (y == size - 1 && x == size - 1)
                    { arenaCells[x, y].Bottom = "······"; }
                }
            }

            StringBuilder ASCIIArena = new();
            for (int y = 0; y < arenaCells.GetLength(1); y++)
            {
                ASCIIArena.Append("          ");

                for (int x = 0; x < arenaCells.GetLength(0); x++)
                { ASCIIArena.Append(arenaCells[x, y].Top); }

                ASCIIArena.Append("\n          ");

                for (int x = 0; x < arenaCells.GetLength(0); x++)
                { ASCIIArena.Append(arenaCells[x, y].Middle1); }

                ASCIIArena.Append("\n          ");

                for (int x = 0; x < arenaCells.GetLength(0); x++)
                { ASCIIArena.Append(arenaCells[x, y].Middle2); }

                ASCIIArena.Append("\n");

                if (y == size - 1)
                { ASCIIArena.Append("          "); }

                for (int x = 0; x < arenaCells.GetLength(0); x++)
                { ASCIIArena.Append(arenaCells[x, y].Bottom); }
            }

            Console.Clear();
            Console.WriteLine("KEY: W = North, A = West, S = South, D = East, F = Left, G = Right, Q = QUIT");
            Console.WriteLine("\n\n\n");
            Console.WriteLine(ASCIIArena);

        }

        public static ArenaCell CreateArenaCell(
            char cGladiatorA, char cGladiatorB, char cGladiatorC, char cGladiatorD)
        {
            return new()
            {
                Top = $".....",
                Middle1 = $": {cGladiatorA}{cGladiatorB} ",
                Middle2 = $": {cGladiatorC}{cGladiatorD} ",
                Bottom = $""
            };
        }

        public struct ArenaCell
        {
            public string Top, Middle1, Middle2, Bottom;
        }
    }


}
