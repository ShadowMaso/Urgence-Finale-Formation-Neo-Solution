using System;

namespace Urgence_Finale_Formation_Neo_Solution
{
    /*
     * Cette classe représente la personne qui va miser de l'argent pour jouer.
     * Tout comme le Croupier, le Joueur est une Personne, mais avec des différences.
    */
    class Joueur : Personne
    {
        // Le joueur doit pouvoir miser de l'argent pour jouer.
        // Tu dois déclarer ici la variable qui stockera l'argent.
        public int Argent { get; set; }

        // Le constructeur doit définir l'argent de base du Joueur, il doit commencer avec $10.
        public Joueur()
        {
            Argent = 10;
        }
    }
}
