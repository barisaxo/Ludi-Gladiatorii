using System;
namespace Tactics
{
    public static class InputSystem
    {
        public static void WaitForUserInput(Gladiator spartacus, Gladiator opponent)
        {
            //Check for available legal actions by comparing gladiators
            //(grey out unavailable actions?)(maybe with paranthesis)
            //

            var key = Console.ReadKey();
            Gladiator[] gladiators = new Gladiator[2] { spartacus, opponent };

            switch (key.KeyChar)
            {
                case 'w': gladiators[0].Position = ActionSystem.Move(spartacus, MoveDirection.N); break;
                case 'a': gladiators[0].Position = ActionSystem.Move(spartacus, MoveDirection.W); break;
                case 's': gladiators[0].Position = ActionSystem.Move(spartacus, MoveDirection.S); break;
                case 'd': gladiators[0].Position = ActionSystem.Move(spartacus, MoveDirection.E); break;
                case 'f': gladiators[0].Position.Facing = ActionSystem.Rotate(spartacus, RotateDirection.Left).Facing; break;
                case 'g': gladiators[0].Position.Facing = ActionSystem.Rotate(spartacus, RotateDirection.Right).Facing; break;
                //case 'u': gladiators = ActionSystem.PerformActions(gladiators, Actions.Avoid); break;
                //case 'i': gladiators = ActionSystem.PerformActions(gladiators, Actions.Check); break;
                //case 'j': gladiators = ActionSystem.PerformActions(gladiators, Actions.Hurt); break;
                //case 'l': gladiators = ActionSystem.PerformActions(gladiators, Actions.Maim); break;
                //case 'k': gladiators = ActionSystem.PerformActions(gladiators, Actions.Kill); break;
                case 'q': return;//fine(end)
            }

            spartacus = gladiators[0];
            opponent = gladiators[1];

            Console.Clear();
            ArenaMapper.DrawArena(spartacus, opponent);
            WaitForUserInput(spartacus, opponent);
        }
    }
}
