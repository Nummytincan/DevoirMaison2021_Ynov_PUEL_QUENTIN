using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{

    public abstract class Character
    {
        #region Raw Attribut
        //Attack, Defense, AttackSpeed, Damages,MaximumLife, CurrentLife, PowerSpeed.
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Damages { get; set; }
        public int MaximumLife { get; }
        public int CurrentLife { get; set; }
        public float PowerSpeed { get; set; }
        public float AttackSpeed { get; set; }
        #endregion

        public HashSet<Character> enemies { get; set; }

        #region Specs relative to type
        public abstract void Power();

        public abstract void Passive();
        #endregion

        #region Specs relative to combat
        public int Initiative()
        {
            var rand = new Random().Next(1, 100);
            var init = (1000 / AttackSpeed) - rand;
            return (int)init;
            
        }

        public void AttackTarget(Character target) {
            if (AttackSuccess(target))
            {
                DealDamage(target);
            }
        }

        /**
         * Vérification de la marge d'attaque suppérieur à zero.
         * en faisant la soustraction de la défense de la cible
         * à l'attaque du précurseur
         * @author Puel Quentin
         */
        public bool AttackSuccess(Character target)
        {
            if ( MargeAttack(target) > 0) // la marge d'attaque est > 0 donc attaque réussie
            {
                Console.WriteLine("{0} réussie son attaque ! ", Name);
                return true;
            }
            else 
            {
                Console.WriteLine("{0} a échoué son attaque ! ", Name);
                return false;
            }
        }

        public int MargeAttack(Character target)
        {
            return target.Defense - this.Attack;
        }

        public void DealDamage(Character target) {
            target.CurrentLife = MargeAttack(target) * Damages / 100;
        }
        #endregion
    }
}
