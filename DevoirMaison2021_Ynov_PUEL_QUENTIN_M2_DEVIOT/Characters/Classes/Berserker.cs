using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    public class Berserker : Character
    {
        #region Raw Attribut
        //Attack, Defense, AttackSpeed, Damages,MaximumLife, CurrentLife, PowerSpeed.
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Damages { get; set; }
        public int MaximumLife { get;}
        public int CurrentLife { get; set; }
        public float PowerSpeed { get; set; }
        public float AttackSpeed { get; set; }
        #endregion

        public HashSet<Character> enemies { get; set; }

        #region Death event

        public event DeathEventHandler IsDead;

        protected virtual void OnCharacterDead(DeathEventArgs e)
        {
            DeathEventHandler handler = IsDead;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public override void Power()
        {
            throw new NotImplementedException();
        }

        public override void Passive()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructor
        public Berserker(string name) {
            Name = name;
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1.1f;
            Damages = 20;
            MaximumLife = 400;
            CurrentLife = 400;
            PowerSpeed = 1f;
        }
        #endregion
    }
}
