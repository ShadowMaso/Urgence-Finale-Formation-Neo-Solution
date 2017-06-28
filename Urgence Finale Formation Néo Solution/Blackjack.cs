using System;

namespace Urgence_Finale_Formation_Neo_Solution
{
    class Blackjack
    {
        /*
         * ALERTE ! INTRUSION DÉTECTÉE ! ACTIVATION DES MESURES DE SÉCU@#&$%€
         * 
         *                      :PB@Bk:
         *                  ,jB@@B@B@B@BBL.
         *               7G@B@B@BMMMMMB@B@B@Nr
         *           :kB@B@@@MMOMOMOMOMMMM@B@B@B1,
         *       :5@B@B@B@BBMMOMOMOMOMOMOMM@@@B@B@BBu.
         *    70@@@B@B@B@BXBBOMOMOMOMOMOMMBMPB@B@B@B@B@Nr
         *  G@@@BJ iB@B@@  OBMOMOMOMOMOMOM@2  B@B@B. EB@B@S
         *  @@BM@GJBU.  iSuB@OMOMOMOMOMOMM@OU1:  .kBLM@M@B@
         *  B@MMB@B       7@BBMMOMOMOMOMOBB@:       B@BMM@B
         *  @@@B@B         7@@@MMOMOMOMM@B@:         @@B@B@
         *  @@OLB.          BNB@MMOMOMM@BEB          rBjM@B
         *  @@  @           M  OBOMOMM@q  M          .@  @@
         *  @@OvB           B:u@MMOMOMMBJiB          .BvM@B
         *  @B@B@J         0@B@MMOMOMOMB@B@u         q@@@B@
         *  B@MBB@v       G@@BMMMMMMMMMMMBB@5       F@BMM@B
         *  @BBM@BPNi   LMEB@OMMMM@B@MMOMM@BZM7   rEqB@MBB@
         *  B@@@BM  B@B@B  qBMOMB@B@B@BMOMBL  B@B@B  @B@B@M
         *   J@@@@PB@B@B@B7G@OMBB.   ,@MMM@qLB@B@@@BqB@BBv
         *      iGB@,i0@M@B@MMO@E  :  M@OMM@@@B@Pii@@N:
         *         .   B@M@B@MMM@B@B@B@MMM@@@M@B
         *             @B@B.i@MBB@B@B@@BM@::B@B@
         *             B@@@ .B@B.:@B@ :B@B  @B@O
         *               :0 r@B@  B@@ .@B@: P:
         *                   vMB :@B@ :BO7
         *                       ,B@B
         *
         * ¡Hola! ¿Qué onda?
         * C'est du beau travail ce que tu avez fait avec votre nouveau QG.
         * Moi ? Non, je ne suis pas là pour te faire tout recommencer, j'ai déjà récuperé ce que je voulais.
         * Je suis là pour qu'on s'amuse. Après tout, si tu es arrivé si loin si vite c'est que tu as du potentiel.
         * Ça te dit une petite partie de Blackjack ?
         * 
         * Je me suis déjà occupée de créer le menu et la gestion d'une partie, tu n'as pas interet à modifier quoi que ce soit dans ce fichier !
         * Tu vas devoir finir d'implémenter les autres parties et faire en sorte que le tout fonctionne avec ce que j'ai fait.
         * Pour cela, tu vas devoir mettre en pratique tout ce que tu as déjà vu.
        */

        static void Main(string[] args)
        {
            Jeu jeu = new Jeu();
            Joueur joueur = new Joueur();
            Croupier croupier = new Croupier();
            bool jouer = true;
            int option;

            jeu.Melanger();
            Console.WriteLine("Bienvenu à cette table de Blackjack !\nPrenez ces $" + joueur.Argent + " pour jouer.");
            while (jouer)
            {
                Console.WriteLine("\n1. Nouveau Jeu\n"
                        + "2. Mélanger les cartes dans le Jeu\n"
                        + "3. Afficher toutes les cartes restantes dans le Jeu\n"
                        + "4. Jouer au Blackjack\n"
                        + "5. Quitter la table\n"
                        + "Choisissez une option : [1/2/3/4/5] ");
                try
                {
                    option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        jeu = new Jeu();
                        Console.WriteLine("\nNouveau Jeu créé.");
                    }
                    else if (option == 2)
                    {
                        jeu.Melanger();
                        Console.WriteLine("\nJeu mélangé.");
                    }
                    else if (option == 3)
                        jeu.Afficher();
                    else if (option == 4)
                        Partie(jeu, joueur, croupier);
                    else if (option == 5)
                    {
                        Console.WriteLine("\nVous partez avec $" + joueur.Argent + ".\nMerci d'avoir joué !");
                        jouer = false;
                    }
                    else
                        Console.WriteLine("\nMauvaise option, veuillez réessayer.");
                    if (jouer && joueur.Argent == 0)
                    {
                        Console.WriteLine("\nVous n'avez plus d'argent !\nGAME OVER !");
                        jouer = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nEntrée invalide ! Veuillez n'utiliser que des Integers.");
                }
            }
            Console.WriteLine("Appuyez sur n'importe quelle touche pour quitter");
            Console.ReadKey();
        }

        private static void Partie(Jeu jeu, Joueur joueur, Croupier croupier)
        {
            int mise = 0;
            bool tourJoueur = true;
            string reponse;

            Console.WriteLine();
            if (jeu.Cartes.Count < 10)
            {
                Console.WriteLine("Il y a moins de 10 cartes dans le Jeu. Veuillez créer un nouveau Jeu.");
                return;
            }
            Console.WriteLine("Il y a " + jeu.Cartes.Count + " cartes dans le Jeu.");
            while (mise <= 0 || mise > joueur.Argent)
            {
                Console.WriteLine("Vous avez $" + joueur.Argent + ". Combien voulez-vous miser ? ");
                try
                {
                    mise = int.Parse(Console.ReadLine());
                    if (mise <= 0 || mise > joueur.Argent)
                        Console.WriteLine("vous devez miser au moins $1 et vous ne pouvez pas miser plus que vous ne pouvez");
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nEntrée invalide ! Veuillez n'utiliser que des Integers.\n");
                }
            }
            if (joueur.Argent == mise)
                Console.WriteLine("Tapis !");
            Console.WriteLine();
            joueur.Piocher(jeu);
            joueur.Piocher(jeu);
            croupier.Piocher(jeu);
            croupier.Piocher(jeu);
            while (tourJoueur && joueur.ScoreTotal() < 21 && jeu.Cartes.Count > 0)
            {
                Console.WriteLine("Croupier:");
                croupier.AffichageSecret();
                Console.WriteLine();
                Console.WriteLine("Vous: Total = " + joueur.ScoreTotal());
                joueur.Afficher();
                Console.WriteLine("\nVoulez-vous une autre carte ? [O/N] ");
                reponse = Console.ReadLine();
                if (reponse == "O" || reponse == "o")
                    Console.WriteLine("Vous piochez: " + joueur.Piocher(jeu));
                else if (reponse == "N" || reponse == "n")
                    tourJoueur = false;
                else
                    Console.WriteLine("\nMauvaise réponse, veuillez réessayer.\n");
                if (joueur.ScoreTotal() >= 21)
                    tourJoueur = false;
            }
            Console.WriteLine();
            if (jeu.Cartes.Count == 0)
            {
                Console.WriteLine("Le Jeu est vide ! La aprtie est annulée. Veuillez créer un nouveau Jeu.");
                joueur.Reinitialiser();
                croupier.Reinitialiser();
                return;
            }
            if (joueur.ScoreTotal() <= 21)
            {
                while (croupier.ScoreTotal() < 17 && jeu.Cartes.Count > 0)
                    Console.WriteLine("Le croupier pioche: " + croupier.Piocher(jeu));
                if (jeu.Cartes.Count == 0)
                {
                    Console.WriteLine("Le Jeu est vide ! La partie est annulée. Veuillez créer un nouveau Jeu.");
                    joueur.Reinitialiser();
                    croupier.Reinitialiser();
                    return;
                }
                Console.WriteLine("Le croupier reste ...\n");
            }
            Console.WriteLine("Résultats:\n");
            if (joueur.ScoreTotal() > 21)
            {
                Console.WriteLine("Vous: Total = " + joueur.ScoreTotal());
                joueur.Afficher();
                Console.WriteLine("\nVotre total dépasse 21. Vous perdez !");
                joueur.Argent = joueur.Argent - mise;
            }
            else
            {
                Console.WriteLine("Croupier: Total = " + croupier.ScoreTotal());
                croupier.Afficher();
                if (croupier.Blackjack())
                    Console.WriteLine("BLACKJACK !!!");
                Console.WriteLine();
                Console.WriteLine("Vous: Total = " + joueur.ScoreTotal());
                joueur.Afficher();
                if (joueur.Blackjack())
                    Console.WriteLine("BLACKJACK !!!");
                Console.WriteLine();

                if (joueur.Blackjack() && !croupier.Blackjack())
                {
                    Console.WriteLine("Blackjack ! Vous gagnez deux fois votre mise !");
                    joueur.Argent = joueur.Argent + (mise * 2);
                }
                else if (croupier.ScoreTotal() > 21 || joueur.ScoreTotal() > croupier.ScoreTotal())
                {
                    Console.WriteLine("Vous avez gagné !");
                    joueur.Argent = joueur.Argent + mise;
                }
                else if ((joueur.Blackjack() && croupier.Blackjack())
                        || (joueur.ScoreTotal() == croupier.ScoreTotal()))
                    Console.WriteLine("C'est une égalité. Vous gardez votre mise !");
			else {
                    Console.WriteLine("Vous avez perdu !");
                    joueur.Argent = joueur.Argent - mise;
                }
            }
            joueur.Reinitialiser();
            croupier.Reinitialiser();
            Console.WriteLine("Vous avez $" + joueur.Argent + ".");
        }

    }
}
