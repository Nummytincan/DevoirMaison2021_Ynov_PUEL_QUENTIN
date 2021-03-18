using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes
{
    /**
     * 
     * @author Puel Quentin
     */
    public class Illusioniste : Character
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

        public Illusioniste(string name) {
            Name = name;
            Attack = 75;
            Defense = 75;
            AttackSpeed = 1.0f;
            Damages = 50;
            MaximumLife = 100;
            CurrentLife = 100;
            PowerSpeed = 0.5f;
            Rand = new Random();
        }
    }
}
