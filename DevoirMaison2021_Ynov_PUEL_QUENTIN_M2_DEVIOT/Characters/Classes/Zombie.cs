using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters;
using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    public class Zombie : Character, IUndead
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
        public override Random Rand { get; set; }
        #endregion

        public override List<Character> enemies { get; set; }

        public override void Passive()
        {
            throw new NotImplementedException();
        }

        public override void Power()
        {
            if (CurrentLife < MaximumLife) {
                EatCorpse(fightManager.deadCharactersList[0]);
            }
            
        }

        public Zombie(string name)
        {
            Name = name;
            Attack = 150;
            Defense = 0;
            AttackSpeed = 1.0f;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            PowerSpeed = 0.1f;
            Rand = new Random();
        }

        public void EatCorpse(Character c) {
            if (CurrentLife + c.MaximumLife / 100 > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
            else { 
                this.CurrentLife += c.MaximumLife / 100;       
            }
             
        }
    }
}
