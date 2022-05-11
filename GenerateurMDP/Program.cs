using System;

namespace GenerateurMDP
{
    class Program
    {
        static int DemanderLongueurMDP()
        {
            while (true)
            {
                Console.WriteLine("Quelle longueur de mot de passe souhaitez-vous ?");
                string longueurMDP = Console.ReadLine();
                try
                {
                    int tailleMDP = int.Parse(longueurMDP);
                    return tailleMDP;
                }
                catch
                {
                    Console.WriteLine("Veuillez entrer un entier.");
                }
            }

        }
        static int DemanderLongueurEntre(int nbMin, int nbMax)
        {
            Console.WriteLine($"Le mot de passe doit faire plus de {nbMin} caractères\net moins que {nbMax} caractères.");
            int reponse = DemanderLongueurMDP();            
            if (reponse >= nbMin && reponse <= nbMax)
            {
                return reponse;
            }
            else
            {
                Console.WriteLine($"Veuillez donnez une taille entre {nbMin} et {nbMax}.");
                return DemanderLongueurEntre(nbMin, nbMax);
            }
        }
        static string SelectionnerAlphabet()
        {
            string minuscules = "abscdefghijklmnopqrstuvwxyz";
            string majuscules = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string nombres = "0123456789";
            string symboles = "$%#@";
            string caracAmbigues = "{}[]()/\\\'\"`~,;:.<>";
            string alphabet;
            while (true)
            {
                Console.WriteLine("Quel alphabet souhaitez-vous ?\n1- Min & Maj \n2- Min, Maj, Nombres\n3- Min & Maj, Nombres, Symboles\n4- Min, Maj, Nombres, Caractères spéciaux");
                string choixAlphabet = Console.ReadLine();
                try
                {
                    int choix = int.Parse(choixAlphabet);
                    if (choix > 4 || choix < 1)
                    {
                        Console.WriteLine("Choisir entre ces 4 options.");
                    }
                    else
                    {
                        switch (choix)
                        {
                            case 1:
                                return alphabet = minuscules + majuscules;
                            case 2:
                                return alphabet = minuscules + majuscules + nombres;
                            case 3:
                                return alphabet  = minuscules + majuscules + nombres + symboles;
                            case 4:
                                return alphabet  = minuscules + majuscules + nombres + symboles + caracAmbigues;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez entrer un entier entre 1 & 4.");
                }
            }

            
        }
        static int NbMDP()
        {
            while (true)
            {
                Console.WriteLine("Combien de mot de passe souhaitez-vous ?");
                string reponse = Console.ReadLine();
                try
                {
                    int nbMDP = int.Parse(reponse);
                    if(nbMDP > 0)
                    {
                        return nbMDP;
                    }
                    else
                    {
                        Console.WriteLine("Veuillez choisir un entier strictement positif.");
                    }
                    
                }
                catch
                {
                    Console.WriteLine("Veuillez choisir un entier strictement positif.");
                }
            }

        }
        static string GenererMDP(int taille, string alphabet)
        {
            string nouveauMDP = "";
            for(int i = 0; i<taille; i++)
            {
                Random rnd = new Random();
                int l = alphabet.Length;
                int index = rnd.Next(0, l);
                nouveauMDP += alphabet[index];
            }
            return nouveauMDP;
        }
        static void Main(string[] args)
        {
            int reponse = DemanderLongueurEntre(5, 24);
            Console.WriteLine($"La taille de mdp choisie est de {reponse}");
            string alphabet = SelectionnerAlphabet();
            Console.WriteLine($"Votre alphabet est {alphabet}");
            int nbMDP = NbMDP();
            for(int i = 0; i<nbMDP; i++)
            {
                string MDP = GenererMDP(reponse, alphabet);
                Console.WriteLine($"{MDP}\n");
            }

        }
    }
}
