using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Tactics
{
    class Program
    {
        static void Main()
        {
            Gladiator spartacus = CharacterCreator.CreateGladiator(FightingStyle.Thraex,
                new Position { X = 1, Y = 1, Facing = Direction.SouthWest });

            Gladiator opponent = CharacterCreator.CreateGladiator(FightingStyle.Cestus,
                new Position { X = 6, Y = 6, Facing = Direction.NorthEast });

            ArenaMapper.DrawArena(spartacus, opponent);

            InputSystem.WaitForUserInput(spartacus, opponent);
        }



    }
}


