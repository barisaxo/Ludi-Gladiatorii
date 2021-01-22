using System;
namespace Tactics
{
    public enum MoveDirection { N, E, S, W, NE, NW, SE, SW }
    public enum RotateDirection { Right, Left }
    public enum Actions { Avoid, Check, Hurt, Maim, Kill, Wait, Move }

    //TODO public TimeLine Exchange
    //if you spend too much stamina you become fatigued
    //next exchange you will have less stamina to work with

    //
    /*
     * FLOW =>
     *     when: player 1 moves and performs action, player 2 reacts. Then:
     *      player 2 moves and performs an action, player 1 reacts. Continue.
     *      player 1 moves and performs an action, player 2 reacts. Continue.
     *      
     *      Continue alternating. all the while, fatigue, wounds, are being accrued
     *      (Moving is considered an action. If player 1 attacks, player 2 may react by moving,
     *          the result of which might be good or bad.
     *          
     *      Available actions are determined by the gladiators position in comparison to his opponent,
     *      What equipment he has donned, and his current health stats(levels of fatigue, wounds, etc)
     *      
     *      Actions are challenged by comparing position, equipment, and current health stats.
     *      
     *      ie. A gladiator who performs an action while fatigued 
     *          will be less effective against one who is not fatigued.
     *          
     *      
    */

    public static class ActionSystem
    {
        public static Position Move(Gladiator gladiator, MoveDirection moveDir)
        {//each move costs a 1 stamina per encumberance
            Position oldPos = gladiator.Position;
            Position newPos = gladiator.Position;
            switch (moveDir)
            {
                case MoveDirection.N: newPos.Y--; break;
                case MoveDirection.E: newPos.X++; break;
                case MoveDirection.S: newPos.Y++; break;
                case MoveDirection.W: newPos.X--; break;
                case MoveDirection.NE: newPos.Y--; newPos.X++; break;
                case MoveDirection.SE: newPos.Y++; newPos.X++; break;
                case MoveDirection.NW: newPos.Y--; newPos.X--; break;
                case MoveDirection.SW: newPos.Y++; newPos.X--; break;
            }

            if (newPos.X > 7 || newPos.X < 0 || newPos.Y > 7 || newPos.Y < 0)
            { return oldPos; }
            else { return newPos; }
        }

        public static Position Rotate(Gladiator gladiator, RotateDirection rotateDirection)
        {
            //switch (rotDir)
            //{
            //    case RotateDirection.Left:
            //        gladiator.Position.Facing = gladiator.Position.Facing - 1;
            //        break;
            //}

            //TODO each rotate costs 1/64 per encumberance

            switch (gladiator.Position.Facing)
            {
                case Direction.North:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.NorthWest; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.NorthEast; break;
                    }
                    break;
                case Direction.East:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.NorthEast; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.SouthEast; break;
                    }
                    break;
                case Direction.South:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.SouthEast; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.SouthWest; break;
                    }
                    break;
                case Direction.West:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.SouthWest; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.NorthWest; break;
                    }
                    break;
                case Direction.NorthEast:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.North; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.East; break;
                    }
                    break;
                case Direction.NorthWest:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.West; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.North; break;
                    }
                    break;
                case Direction.SouthEast:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.East; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.South; break;
                    }
                    break;
                case Direction.SouthWest:
                    switch (rotateDirection)
                    {
                        case RotateDirection.Left: gladiator.Position.Facing = Direction.South; break;
                        case RotateDirection.Right: gladiator.Position.Facing = Direction.West; break;
                    }
                    break;
            }

            return gladiator.Position;
        }

        /// <summary>
        /// Compare and execute actions performed by combating gladiators.
        /// </summary>
        /// <param name="combating gladiators">Gladiators</param>
        /// <param name="performed action">Actions</param>
        /// <returns>Resolved status and afflictions of combating gladiators.</returns>
        public static Gladiator[] PerformActions(Gladiator[] gladiators, Actions action,
            MoveDirection direction, RotateDirection rotateDirection)
        {
            switch (action)
            {

                //TODO Compare player and opponent position and equipment 

                case Actions.Avoid:
                    //costs 3/64 per encumberance
                    //causes fatigue = encumberance
                    //inflicts 0 fatigue,
                    //move a spot away according to attack avoided
                    //crit can lead opponent and/or cause a stumble
                    //chance for a successfull avoid diminishes with fatigue
                    break;

                case Actions.Check:
                    //costs 5/64 per encumberance
                    //causes fatigue = 2 * encumberance + (1/8th inflicted fatigue)
                    //inflicts 1/4 fatigue of opponents attack
                    //crit inflicts extra fatigue and possibly pushes the opponent - depending on equipment
                    //difficult for opponent to avoid
                    //chance for a successfull check diminishes with fatigue
                    break;

                case Actions.Hurt:
                    //costs 6/64 per encumberance
                    //causes fatigue = 3 * encumberance
                    //low return on check or avoid
                    //inflicts pain & fatigue - opponents armor
                    //quicker than maim & kill
                    //crit deals extra
                    break;

                case Actions.Maim:

                    //costs 8/64 per encumberance
                    //causes fatigue = 4 * encumberance
                    //inflicts pain & fatigue & injury - opponents armor
                    //quicker than kill
                    //crit deals extra
                    break;

                case Actions.Kill:

                    //costs 10/64 per encumberance
                    //causes fatigue = 5 * encumberance
                    //high return from avoid or check
                    //easily avoided and checked
                    //inflicts fatigue, pain, injury
                    //crit kills instantly
                    break;
                case Actions.Move:

                    break;
                case Actions.Wait:

                    //Restores 10% fatigue taken (minus any active pain & wound damages)
                    break;
            }

            return gladiators;
        }


        public static void CompareGladiators(Gladiator[] gladiators)
        {
            int distance;

        }
    }



}
