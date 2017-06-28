using System.Collections.Generic;

namespace Urgence_Finale_Formation_Neo_Solution
{
    /*
     * Cette classe représente une carte, composée d'une enseigne (ex: "Trèfle") et d'une valeur (ex: "As")
     * ainsi que du score qu'elle vaut au Blackjack.
    */
    class Carte
    {
        // Je te donne cette liste qui représente les enseignes que nous allons utiliser.
        public static readonly List<string> EnseigneListe = new List<string>
        {
            "Trèfle",
            "Coeur",
            "Pique",
            "Carreau"
        };

        // Je te donne ce dictionnaire qui représente les valeurs que nous allons utiliser et leurs scores.
        public static readonly Dictionary<string, int> ValeurListe = new Dictionary<string, int>
        {
            { "As", 11 },
            { "Deux", 2 },
            { "Trois", 3 },
            { "Quatre", 4 },
            { "Cinq", 5 },
            { "Six", 6 },
            { "Sept", 7 },
            { "Huit", 8 },
            { "Neuf", 9 },
            { "Dix", 10 },
            { "Valet", 10 },
            { "Dame", 10 },
            { "Roi", 10 }
        };

        // Tu déclareras ici les propriétés d'une carte.
        public string Enseigne { get; set; }
        public KeyValuePair<string, int> Valeur { get; set; }

        // Le constructeur reçoit en paramètre l'enseigne et la valeur de la carte.
        public Carte(string enseigne, KeyValuePair<string, int> valeur)
        {
            Enseigne = enseigne;
            Valeur = valeur;
        }

        // Cette fonction doit retourner le nom de la carte, par exemple : "As de Trèfle".
        public string Afficher()
        {
            return Valeur.Key + " de " + Enseigne;
        }
    }
}
