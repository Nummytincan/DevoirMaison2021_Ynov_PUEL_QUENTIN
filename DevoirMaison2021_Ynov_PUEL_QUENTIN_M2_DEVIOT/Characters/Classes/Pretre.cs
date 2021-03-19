using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes
{
    public class Pretre : Character
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
            Console.WriteLine("AvHeal " + CurrentLife);
            var regen = MaximumLife * 0.1;
            if (MaximumLife - CurrentLife <= regen)
            {
                CurrentLife += (int)regen;
                Console.WriteLine("Le pretre se heal de " + regen);
            }
            else {
                CurrentLife = MaximumLife;
                
            }
           
            Console.WriteLine("ApHeal " + CurrentLife);

        }
        public Pretre(string name)
        {
            Name = name;
            Attack = 100;
            Defense = 125;
            AttackSpeed = 1.5f;
            Damages = 90;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 1.0f;
            Rand = new Random();
        }
        public override void DealDamage(Character target, int ma)
        {
            if (target is IUndead)
            {
                target.CurrentLife -= ma * Damages * 2 / 100;
                //target.CurrentLife = MargeAttack(target) * Damages * 2 / 100;
            }
            else
            {
                base.DealDamage(target, ma);
            }
        }

        /**
         * TODO Ciblage des morts vivant en premiers
         */
        public override void SelectTargetAndAttack()
        {
            List<Character> validTarget = new List<Character>();

            for (int i = 0; i < fightManager.aliveCharactersList.Count; i++)
            {
                Character currentCharacter = fightManager.aliveCharactersList[i];
                //si le personnage testé n'est pas celui qui attaque et qu'il est vivant
                if (currentCharacter != this && currentCharacter.CurrentLife > 0)
                {
                    //on l'ajoute à la liste des cible valide
                    validTarget.Add(currentCharacter);
                }
            }
            //count undead

            //TODO Trie de la liste en mettant les undead en premiers

            if (validTarget.Count > 0)
            {

                //on prend un personngae au hasard dans la liste des cibles valides et on le designe comme la cible de l'attaque 

                Character target = validTarget[Rand.Next(0, validTarget.Count)]; // A remplacer Rand(0,nbUndead)
                AttackTarget(target);
            }
        }
    }
}
