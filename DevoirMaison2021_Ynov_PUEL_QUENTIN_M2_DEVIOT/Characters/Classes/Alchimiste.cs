﻿using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes
{
    public class Alchimiste : Character
    {
        #region Raw Attribut
        //Attack, Defense, AttackSpeed, Damages,MaximumLife, CurrentLife, PowerSpeed.
        public override string Name { get; set; }
        public override int Attack { get; set; }
        public override int Defense { get; set; }
        public override int Damages { get; set; }
        public override int MaximumLife { get; }
        public override int CurrentLife { get; set; }
        public override float PowerSpeed { get; set; }
        public override float AttackSpeed { get; set; }
        public override int Init { get; set; }
        public override Random Rand { get; set; }
        public override FightManager fightManager { get;  set; }

        #endregion

        public override List<Character> enemies { get; set; }

        public override void Passive()
        {
            throw new NotImplementedException();
        }

        public override void Power()
        {
            throw new NotImplementedException();
        }
        public Alchimiste(string name) {
            Name = name;
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1.0f;
            Damages = 30;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.1f;
            Rand = new Random();
        }
    }
}
