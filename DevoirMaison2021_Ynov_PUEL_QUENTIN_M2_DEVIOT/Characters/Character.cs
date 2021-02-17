using System;
using System.Collections.Generic;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT
{
    /**
     * 
     * @author Quentin Puel
     */
    public abstract class Character
    {
        #region Raw Attribut
        //Attack, Defense, AttackSpeed, Damages,MaximumLife, CurrentLife, PowerSpeed.
        public abstract string Name { get; set; }
        public abstract  int Attack { get; set; }
        public abstract int Defense { get; set; }
        public abstract int Damages { get; set; }
        public abstract int MaximumLife { get; }
        public abstract int CurrentLife { get; set; }
        public abstract float PowerSpeed { get; set; }
        public abstract float AttackSpeed { get; set; }
        #endregion

        public abstract HashSet<Character> enemies { get; set; }

        
        
        #region Specs relative to type
        /**
         * Chaque personnages ont un pouvoir spécifique à leur class 
         * @author Quentin Puel
         */
        public abstract void Power();
        /**
         * Chaque personnages ont un passif spécifique à leur class 
         * @author Quentin Puel
         */
        public abstract void Passive();
        #endregion

        #region Specs relative to combat
        /**
         * Calcul de l'initiative d'un personnage
         * @author Quentin Puel
         */
        public int Initiative()
        {
            var rand = new Random().Next(1, 100);
            var init = (1000 / AttackSpeed) - rand;
            Console.WriteLine("{0} a fait {1} au jet d'initiative", Name, init);
            return (int)init;
            
        }

        /**
         * 
         * @author Quentin Puel
         */
        public void AttackTarget(Character target) {
            if (AttackSuccess(target))
            {
                DealDamage(target);
            }
        }

        /**
         * Vérification de la marge d'attaque suppérieur à zero.
         * si > 0, ça touche 
         * sinon, ça rate
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

        /**
         * Calcul la marge d'attaque néccessaire,en faisant la soustraction de la défense de la cible
         * à l'attaque du précurseur
         * @author Quentin Puel
         */
        public int MargeAttack(Character target)
        {
            return  this.Attack - target.Defense ;
        }
        /**
         * 
         * @author Quentin Puel
         */
        public virtual void DealDamage(Character target) {
            target.CurrentLife = MargeAttack(target) * Damages / 100;
        }
        #endregion
    }
}
