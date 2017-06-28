using System;

namespace Urgence_Finale_Formation_Neo_Solution
{
    /*
     * Cette classe représente la personne qui distribue les cartes et gère les mises.
     * Tout comme le Joueur, le Croupier est une Personne, mais avec des différences.
    */
    class Croupier : Personne
    {
        // En plus de pouvoir afficher sa main, le Croupier doit pouvoir afficher ses cartes en cachant la première.
        // Cette fonction doit afficher les cartes présentent dans la main, mais remplacer la première carte par "???".
        public void AffichageSecret()
        {
            for (int i = 0; i < Main.Count; i++)
            {
                if (i == 0)
                    Console.WriteLine("???");
			    else
                    Console.WriteLine(Main[i].Afficher());
            }
        }
    }
}
