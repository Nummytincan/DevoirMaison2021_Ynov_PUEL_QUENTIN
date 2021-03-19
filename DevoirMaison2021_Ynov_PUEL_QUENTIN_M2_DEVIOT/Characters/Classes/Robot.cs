using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    public class Robot : Character
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

        public override FightManager fightManager { get; set; }
        public override Random Rand { get; set; }
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
        public Robot(string name) {
            Name = name;
            Attack = 25;
            Defense = 100;
            AttackSpeed = 1.2f;
            Damages = 50;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 0.5f;
            Rand = new Random();
        }
        public override int RollDice()
        {
            return 50;
        }
        
    }
}
