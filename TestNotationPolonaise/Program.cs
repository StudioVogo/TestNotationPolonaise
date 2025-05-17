using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// Calcul de l'expression en notation polonaise
        /// </summary>
        /// <param name="formule"></param>
        /// <returns></returns>
        static float Polonaise(string formule)
        {
            try
            {
                //création d'un tableau de type string contenant les éléments de la formule
                string[] tab = formule.Split(' ');
                //creation d'une variable de valeur égale à la taille du tableau
                int nbCases = tab.Length;
                //variable de valeur égale à la taille du tableau
                int k = nbCases;

                //algorithme de calcul
                while (nbCases > 2)
                {
                    //le tableau est parcouru de la fin vers le début
                    k--;

                    //si le caractere est un calcul
                    switch (tab[k])
                    {
                        case "+":
                            //calcul de l'addition
                            tab[k] = (float.Parse(tab[k + 1]) + float.Parse(tab[k + 2])).ToString();
                            //décalage du tableau
                            try
                            {
                                for (int j = k + 1; j < nbCases - 1; j++)
                                {
                                    tab[j] = tab[j + 2];
                                }
                            }
                            catch { }
                            //prise en compte du nombre de cases restantes
                            nbCases -= 2;
                            break;

                        case "-":
                            //calcul de la soustraction
                            tab[k] = (float.Parse(tab[k + 1]) - float.Parse(tab[k + 2])).ToString();
                            //décalage du tableau
                            try
                            {
                                for (int j = k + 1; j < nbCases - 1; j++)
                                {
                                    tab[j] = tab[j + 2];
                                }
                            }
                            catch { }
                            //prise en compte du nombre de cases restantes
                            nbCases -= 2;
                            break;

                        case "*":
                            //calcul de la multiplication
                            tab[k] = (float.Parse(tab[k + 1]) * float.Parse(tab[k + 2])).ToString();
                            //décalage du tableau
                            try
                            {
                                for (int j = k + 1; j < nbCases - 1; j++)
                                {
                                    tab[j] = tab[j + 2];
                                }
                            }
                            catch { }
                            //prise en compte du nombre de cases restantes
                            nbCases -= 2;
                            break;

                        case "/":
                            //calcul de la division
                            tab[k] = (float.Parse(tab[k + 1]) / float.Parse(tab[k + 2])).ToString();
                            //décalage du tableau
                            try
                            {
                                for (int j = k + 1; j < nbCases - 1; j++)
                                {
                                    tab[j] = tab[j + 2];
                                }
                            }
                            catch { }
                            //prise en compte du nombre de cases restantes
                            nbCases -= 2;
                            break;
                    }
                }

                //verification de la possibilité du calcul
                if (tab[0] != "∞" && nbCases <= 1)
                {
                    // on renvoie le résultat
                    return float.Parse(tab[0]);
                }
                else
                {
                    // si le résultat est infini, on renvoie NaN
                    return float.NaN;
                }
            }
            // si erreur de conversion, on renvoie NaN
            catch
            {
                return float.NaN;
            }
        }


        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
