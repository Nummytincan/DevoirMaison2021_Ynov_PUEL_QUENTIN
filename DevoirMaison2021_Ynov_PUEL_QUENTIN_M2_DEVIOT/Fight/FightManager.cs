using DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Characters.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight
{
    public class FightManager
    {
        public List<Character> aliveCharactersList = new List<Character>();
        public List<Character> deadCharactersList = new List<Character>();
        public int round = 0;
        public DateTime startTime;
        public int StartNumberFighter = 0;
        public bool continueFight = false;
        public int PlayingPlayerIndex = 0;
        bool fightEnded = false;

        public FightManager(List<Character> charactersList, int round = 0)
        {
            this.aliveCharactersList = charactersList;
            this.round = round;
            foreach (Character character in charactersList)
            {
                character.SetFightManager(this);
            }
        }

        public void StartCombat()
        {
            startTime = DateTime.Now;
            round = 1;
            StartNumberFighter = aliveCharactersList.Count;
            //faire en sorte que les personnages ne soient pas blessé avant le début du combat
            //Reset des personnages
            ResetAll();
            MyLog(" RESET Fait ");
            MyLog("----- Debut du combat -----");
            //a commenter pour enchainer les rounds à la main
            //faire des rounds tant qu'il y a plus d'un combattant vivant
            while (aliveCharactersList.Count > 1)
            {
                //commence le combat entre personnages
                Fight();
                if (fightEnded)
                {
                    Console.WriteLine("salut");
                    
                    return;
                }
            }

            ManageVictory();
        }

        private void Fight(int playingPlayerIndex = -2)
        {
            PlayingPlayerIndex = playingPlayerIndex; // permets de savoir si le fight vient de commencer

            if (PlayingPlayerIndex == -2) {
                PlayingPlayerIndex++;
                MyLog("------------------Attack-------------------- ");
                    
            }

            if (PlayingPlayerIndex == -1) {
                PlayingPlayerIndex++;
                MyLog(" INIT ");
                //boucle de calcule pour l'initiative
                ComputeInit();
                
                //trie du tableau en fonction de l'initiative
                OrderTabByInit();
                MyLog(" TRIE ");
                
            }


            //boucle pour chaque personnage
            for (int i = PlayingPlayerIndex; i < aliveCharactersList.Count; i++) {
                if (aliveCharactersList[i].Poison > 0) {
                    aliveCharactersList[i].CurrentLife -= aliveCharactersList[i].Poison;

                    MyLog(aliveCharactersList[i].Name + " est empoisonnée "+ aliveCharactersList[i].Poison);
                }
                if (aliveCharactersList[i].CurrentLife > 0) {
                    //select random target
                    aliveCharactersList[i].SelectTargetAndAttack();
                    if (deadCharactersList.Count > 0 && aliveCharactersList[i] is Zombie) {
                        MyLog("Zombie dévore un cadavre");
                        aliveCharactersList[i].Power();
                    }

                    if (aliveCharactersList[i].CurrentLife < aliveCharactersList[i].MaximumLife && aliveCharactersList[i] is Pretre) {
                        aliveCharactersList[i].Power();
                    }

                    if (aliveCharactersList[i] is Robot && round % 2 == 0) {
                        MyLog("Robot prends de la vitesse");
                        aliveCharactersList[i].Power();
                    }

                }
            }

            //trie des morts
            DeadFlush();
            // mort++
            round++;
            MyLog("------------------FINAttack-------------------- ");
            MyLog("------------------Round "+round+"-------------------- ");
            MyLog("------------------"+aliveCharactersList.Count+" -------------------- ");
            PlayingPlayerIndex = -2;
        }

        private void DeadFlush()
        {
            for (int i = aliveCharactersList.Count - 1; i >= 0; i--)
            {
                Character currentPersonnage = aliveCharactersList[i];
                if (currentPersonnage.CurrentLife <= 0)
                {
                    deadCharactersList.Add(currentPersonnage);
                    aliveCharactersList.Remove(currentPersonnage); 
                }
            }
        }

        private void OrderTabByInit()
        {
            aliveCharactersList = aliveCharactersList.OrderByDescending(personnage => personnage.Init).ToList();
        }

        private void ComputeInit()
        {
            foreach (Character p in aliveCharactersList) {
                p.Initiative();
                MyLog(" "+ p.Name+" Initiative : " + p.Init);
            }
        }

        private void ResetAll()
        {
            foreach(Character p in aliveCharactersList)
            {
                p.Reset();
            }
        }

        void ManageVictory()
        {
            fightEnded = true;
            if (aliveCharactersList.Count == 1)
            {
                MyLog(aliveCharactersList[0].Name + " remporte le battle royale");
            }
            else if (aliveCharactersList.Count <= 0)
            {
                MyLog("Tout le monde est mort, il n'y a pas de vainqueur");
            }
        }

        
        public void MyLog(string text)
        {
            Console.WriteLine(text);
        }
    }
}
