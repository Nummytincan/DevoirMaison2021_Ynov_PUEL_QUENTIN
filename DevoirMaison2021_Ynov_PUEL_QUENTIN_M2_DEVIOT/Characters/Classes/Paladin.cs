using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters;
using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    public class Paladin : Character,ISacred
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

        public Paladin(string name) {
            Name = name;
            Attack = 60;
            Defense = 145;
            AttackSpeed = 1.6f;
            Damages = 40;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.5f;
        }

        public override void DealDamage(Character target)
        {
            if (target is IUndead)
            {
                Console.WriteLine("{0}", MargeAttack(target) * Damages * 2 / 100);
                //target.CurrentLife = MargeAttack(target) * Damages * 2 / 100;
            }
            else
            {
                Console.WriteLine("{0}", MargeAttack(target) * Damages / 100);
            }
        }
    }
}
