﻿using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes
{
    /**
     * 
     * @author Puel Quentin
     */
    public class Assassin : Character
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
        public override FightManager fightManager { get; set; }
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
        public Assassin(string name) {
            Name = name;
            Attack = 150;
            Defense = 100;
            AttackSpeed = 1.0f;
            Damages = 100;
            MaximumLife = 185;
            CurrentLife = 185;
            PowerSpeed = 0.5f;
            Rand = new Random();
            
        }
        public override void DealDamage(Character target, int ma)
        {
            if (target is IImune)
            {
                var damage = ma * Damages * 2 / 100;
                target.CurrentLife -= damage / 2; // Ne prends pas de dégats de poison
                
            }
            else
            {
                var damage = ma * Damages * 2 / 100;
                target.CurrentLife -= damage / 2;
                target.Poison += damage / 2;
            }
        }
    }
}
