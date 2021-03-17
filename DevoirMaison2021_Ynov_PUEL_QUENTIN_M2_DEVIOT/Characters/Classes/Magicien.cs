using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes
{
    public class Magicien : Character
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
        public override FightManager fightManager { get; set; }
        public override int Init { get; set; }
        #endregion

        public override HashSet<Character> enemies { get; set; }

        public override void Passive()
        {
            throw new NotImplementedException();
        }

        public override void Power()
        {
            throw new NotImplementedException();
        }

        public Magicien(string name) {
            Name = name;
            Attack = 75;
            Defense = 125;
            AttackSpeed = 1.5f;
            Damages = 100;
            MaximumLife = 125;
            CurrentLife = 125;
            PowerSpeed = 0.1f;
        }
    }
}
