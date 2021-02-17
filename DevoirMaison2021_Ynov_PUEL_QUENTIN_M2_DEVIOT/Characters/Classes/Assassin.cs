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
        public Assassin(string name) {
            Name = name;
            Attack = 150;
            Defense = 100;
            AttackSpeed = 1.0f;
            Damages = 100;
            MaximumLife = 185;
            CurrentLife = 185;
            PowerSpeed = 0.5f;
        }
    }
}
