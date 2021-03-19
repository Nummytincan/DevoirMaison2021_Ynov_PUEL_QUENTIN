using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    /**
    * 
    * @author Puel Quentin
    */
    public class Berserker : Character
    {
        #region Raw Attribut
        //Attack, Defense, AttackSpeed, Damages,MaximumLife, CurrentLife, PowerSpeed.
        public override string Name { get; set; }
        public override int Attack { get; set; }
        public override int Defense { get; set; }
        public override int Damages { get; set; }
        public override int MaximumLife { get;}
        public override int CurrentLife { get; set; }
        public override float PowerSpeed { get; set; }
        public override float AttackSpeed { get; set; }
        public override int Init { get; set; }
        public override Random Rand { get; set; }
        public override FightManager fightManager { get; set; }
        #endregion

        public override List<Character> enemies { get; set; }

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
            //si endessous de 200 pdv 
            if (CurrentLife <= 200)
            {
                // get différence entre maxlife et current life /2 et modif attack et dammage 
                Attack += GetDiffMaxCurrent();
                Damages += GetDiffMaxCurrent();
            }
        }

        public override void Passive()
        {
            //TODO ne subit pas de délai d'attaque
        }
        #endregion
        private int GetDiffMaxCurrent()
        {
            return (int)(MaximumLife - CurrentLife / 2);
        }
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
            Rand = new Random();
        }
        #endregion
    }
}
