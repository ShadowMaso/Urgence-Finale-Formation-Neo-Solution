using System;
using System.Collections.Generic;

namespace Urgence_Finale_Formation_Neo_Solution
{
    /*
     * Cette classe représente une personne présente à une table de Blackjack.
     * Elle doit contenir une liste de cartes représentant la main de la personne,
     * d'autres propriétés et des fonctions pour pouvoir jouer.
     * Indice : le mot clé "abstract" avant le nom de la classe veut dire qu'on ne peut pas
     * instancier un objet Personne directement, mais on peut instancier un objet héritant de Personne.
    */
    abstract class Personne
    {
        // Une personne doit pouvoir garder les cartes qu'elle pioche en main,
        // savoir son total de points et si elle a des As en main.
        // Tu dois déclarer ici la liste de cartes et les variables stockant le total et le nombre d'As.
        // Personne d'autre ne doit pouvoir accéder à ces informations, ces propriétés ne doivent pas être
        // "public" ou "private" mais "protected" (ce qui veut dire qu'une classe fille peut les utiliser).
        protected List<Carte> Main;
        protected int Total;
        protected int As;

        // Le constructeur doit créer la liste de carte et mettre les autres propriétés à 0.
        public Personne()
        {
            Main = new List<Carte>();
            Total = 0;
            As = 0;
        }

        // Cette fonction doit piocher une carte dans le jeu et l'ajouter à la main de la personne.
        // Quand la carte est piochée, il faut ajouter son score au score total de la personne,
        // si c'est un As, il faut augmenter de un le compteur d'As de la personne.
        // Après avoir pioché la carte, si le score total dépasse 21 et qu'on a au moins un As dans la main,
        // l'As vaut maintenant 1, un déduit 10 au score total et on diminue de 1 le nombre d'As en main.
        // Pour finir, la fonction doit retourner le nom de la carte piochée.
        public string Piocher(Jeu jeu)
        {
            Carte carte = jeu.Distribuer();
            Total += carte.Valeur.Value;
            if (carte.Valeur.Key == "As")
                As++;
            Main.Add(carte);
            if (Total > 21 && As > 0)
            {
                Total -= 10;
                As--;
            }
            return carte.Afficher();
        }

        // Cette fonction doit afficher les cartes présentes dans la main.
        // Indice : n'y a-t-il pas une fonction du même nom dans la classe Carte ?
        public void Afficher()
        {
            foreach (Carte carte in Main)
                Console.WriteLine(carte.Afficher());
        }

        // Cette fonction doit retourner le total de points de la personne.
        public int ScoreTotal()
        {
            return Total;
        }

        // Cette fonction doit retourner "true" s'il y a Blackjack.
        // Il y a Blackjack quand la personne a un score de 21 avec seulement deux cartes en main.
        public bool Blackjack()
        {
            if (Total == 21 && Main.Count == 2)
                return true;
            return false;
        }

        // Cette fonction doit vider la main de la personne et réinitialiser ses propriétés.
        public void Reinitialiser()
        {
            Main.Clear();
            Total = 0;
            As = 0;
        }

    }
}
