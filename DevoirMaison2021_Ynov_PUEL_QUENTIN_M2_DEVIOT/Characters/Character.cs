using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

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
        public abstract int Init { get; set; }
        public abstract Random Rand { get; set; }


        public abstract FightManager fightManager { get; set; }
        #endregion
        //Potential target of the character
        public abstract List<Character> enemies { get; set; }
        public int Poison { get;  set; }



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
        public void Initiative()
        {
            
            var init = (1000 / AttackSpeed) + RollDice();           
            this.Init = (int)init;
            
        }
        public virtual int RollDice() {
            var rand = new Random().Next(0, 100);
            return rand;
        }
        

        /**
         * Attack the target character
         * @param Character target
         * @author Quentin Puel
         */
        public void AttackTarget(Character target) {
            var i = MargeAttack(target);
            if (AttackSuccess(i))
            {
                Console.WriteLine("Avant Vie : {0}", target.CurrentLife);
                DealDamage(target,i);
                Console.WriteLine("Cible : {0}", target.Name);
                Console.WriteLine("Vie : {0}", target.CurrentLife);
            }
            
        }

        
        /**
         * Vérification de la marge d'attaque suppérieur à zero.
         * si > 0, ça touche 
         * sinon, ça rate
         * @param Character target
         * @author Puel Quentin
         */
        public bool AttackSuccess(int ma)
        {
            if ( ma > 0) // la marge d'attaque est > 0 donc attaque réussie
            {
                Console.WriteLine("{0} réussie son attaque ! MA : {1} ", Name,ma);
                
                return true;
            }
            else 
            {
                Console.WriteLine("{0} a échoué son attaque ! MA : {1} ", Name, ma);
                return false;
            }
        }

        /**
         * Calcul la marge d'attaque néccessaire,en faisant la soustraction de la défense de la cible
         * à l'attaque du précurseur
         * @param Character target
         * @author Quentin Puel
         */
        public int MargeAttack(Character target)
        { 
            var i = Attack - target.Defense + RollDice();
            Console.WriteLine(i + "MA");
           
            return i ;
        }
        /**
         * Apply Damage on target current life
         * @param Character target
         * @author Quentin Puel
         */
        public virtual void DealDamage(Character target, int ma) {
            Console.WriteLine(ma * Damages / 100 + "D");
            target.CurrentLife -= ma * Damages / 100;
        }

        public virtual void SelectTargetAndAttack()
        {
            //on cree une liste dans laquelle on stockera les cibles valides
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

            if (validTarget.Count > 0)
            {

                //on prend un personngae au hasard dans la liste des cibles valides et on le designe comme la cible de l'attaque 
                Character target = validTarget[Rand.Next(0, validTarget.Count)];
                AttackTarget(target);
            }
            else
            {
                //MyLog(Name + " n'a pas trouvé de cible valide");
                
            }
        }

        public void Reset() {
            CurrentLife = MaximumLife;
            
        }

        public void SetFightManager(FightManager fightManager)
        {
            this.fightManager = fightManager;
        }
        #endregion
    }
}
