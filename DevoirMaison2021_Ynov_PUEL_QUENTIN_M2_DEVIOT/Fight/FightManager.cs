using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevoirMaison2021_Ynov_PUEL_QUENTIN_M2_DEVIOT.Fight
{
    public class FightManager
    {
        public List<Character> charactersList = new List<Character>();
        public int round = 0;
        public DateTime startTime;
        public int StartNumberFighter = 0;
        public bool continueFight = false;
        public int PlayingPlayerIndex = 0;
        bool fightEnded = false;

        public FightManager(List<Character> charactersList, int round = 0)
        {
            this.charactersList = charactersList;
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
            StartNumberFighter = charactersList.Count;
            //faire en sorte que les personnages ne soient pas blessé avant le début du combat
            //Reset des personnages
            ResetAll();
            MyLog(" RESET Fait ");
            MyLog("----- Debut du combat -----");
            //a commenter pour enchainer les rounds à la main
            //faire des rounds tant qu'il y a plus d'un combattant vivant
            while (charactersList.Count > 1)
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
                Console.ReadLine();
            }


            //boucle pour chaque personnage
            for (int i = PlayingPlayerIndex; i < charactersList.Count; i++) {
                //select random target
                //deal damage
            }

            //trie des morts
            // mort++


        }



        private void OrderTabByInit()
        {
            charactersList = charactersList.OrderByDescending(personnage => personnage.Init).ToList();
        }

        private void ComputeInit()
        {
            foreach (Character p in charactersList) {
                p.Initiative();
                MyLog(" "+ p.Name+" Initiative : " + p.Init);
            }
        }

        private void ResetAll()
        {
            foreach(Character p in charactersList)
            {
                p.Reset();
            }
        }

        void ManageVictory()
        {
            fightEnded = true;
            if (charactersList.Count == 1)
            {
                MyLog(charactersList[0].Name + " remporte le battle royale");
            }
            else if (charactersList.Count <= 0)
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
