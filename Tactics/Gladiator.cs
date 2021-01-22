using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text;

namespace Tactics
{

    public struct Gladiator
    {
        public FightingStyle FightingStyle;
        public PrimaryWeapon PrimaryWeapon;
        public OffHand OffHand;
        public Armor[] Armor;
        public Helmet Helmet;
        public int Stamina;
        public float Fatigue, Pain, Bleading;
        public Encumberance Encumberance;
        public List<Wounds> Wounds { get; set; }
        public Position Position;
    }

    public struct Position
    {
        public int X, Y;
        public Direction Facing;
    }

    public enum Direction
    {
        North, East, South, West,
        NorthEast, NorthWest, SouthEast, SouthWest
    }

    public enum FightingStyle
    {
        Secutor, Murmillo, Hoplomachus,
        Veles, Cestus, Thraex,
        Ratiarus, Dimachaerus, Laqueraius
    }

    public enum Encumberance
    {
        Light = 3, Medium = 4, Heavy = 5
    }

    public enum PrimaryWeapon
    {
        Gladius, Cestus, Veles, Ratius, Lasso, Spatha, Pugio
    }

    public enum OffHand
    {
        SmallShield, MediumShield, LargeShield, Gladius, Pugio, Cestus, Veles
    }

    public enum Armor
    {
        LeftArm, RightArm, Legs, Body, None,
    }

    public enum Helmet
    {
        Helmet, None
    }

    public enum Wounds
    {
        Head, Toros, Back, LeftArm, LeftLeg, RightArm, RightLeg, Bleeding, Disarmed, Snared
    }

    public static class CharacterCreator
    {
        public static Gladiator CreateGladiator(FightingStyle fightingStyle, Position position)
        {
            Gladiator gladiator = new Gladiator { };
            switch (fightingStyle)
            {//TODO assign proper equipment
                case FightingStyle.Cestus:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = position;
                    break;
                case FightingStyle.Dimachaerus:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Hoplomachus:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Laqueraius:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Murmillo:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Secutor:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Veles:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Veles;
                    gladiator.OffHand = OffHand.SmallShield;
                    gladiator.Armor = new Armor[1] { Armor.LeftArm };
                    gladiator.Helmet = Helmet.Helmet;
                    gladiator.Encumberance = Encumberance.Medium;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = new();
                    break;
                case FightingStyle.Thraex:
                    gladiator.PrimaryWeapon = PrimaryWeapon.Cestus;
                    gladiator.OffHand = OffHand.Cestus;
                    gladiator.Armor = new Armor[2] { Armor.LeftArm, Armor.RightArm };
                    gladiator.Helmet = Helmet.None;
                    gladiator.Encumberance = Encumberance.Light;
                    gladiator.Fatigue = 0;
                    gladiator.Pain = 0;
                    gladiator.Wounds = new();
                    gladiator.Position = position;
                    break;

            }

            return gladiator;
        }


    }
}
