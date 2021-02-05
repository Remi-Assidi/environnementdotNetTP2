using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TP2.Entities;
using TP2.Utils;

namespace TP2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var item in FakeDb.Instance.Users)
            {
                Console.WriteLine(item);
            }

            #region Q1
                Console.WriteLine("Question 1");
            // Afficher le nombre de personne s'appelant Dupond ou Dupont.
            var count = FakeDb.Instance.Users.Where(x => x.Lastname.Equals("Dupont") || x.Lastname.Equals("Dupond")).Count();
            Console.WriteLine("Il y a actuellement {0} personnes qui s'appellent Dupont ou Dupond!", count);
            #endregion
            #region Q2
            Console.WriteLine("Question 2");
            // Afficher les personnes enregistré avec le role Automobiliste.
            Role role = FakeDb.Instance.Roles.First(x => x.Name.Equals("Automobiliste"));
            foreach (var item in FakeDb.Instance.Users.Where(x => x.Roles.Contains(role)).ToList())
            {
                Console.WriteLine(item);
            }


            #endregion
            #region Q3
            Console.WriteLine("Question 3");
            // Afficher les plaques d'immatriculation de toutes les voitures (une seule fois par voiture) liées à au moins un utilisateur.
            foreach (var item in FakeDb.Instance.Cars.FindAll(x => x.Registration != null).GroupBy(x => x.Registration).ToList())
            {
                foreach (var subitem in item)
                {
                    Console.WriteLine(subitem.Registration);
                }
            }

            #endregion
            #region Q4
            Console.WriteLine("Question 4");
            // Afficher la ou les voiture(s) avec le plus de kilomètre
            double? max = FakeDb.Instance.Cars.Select(x => x.Mileage).Max();
            if (max != null)
            {
                foreach (var item in FakeDb.Instance.Cars.FindAll(x => x.Mileage == max))
                {
                    Console.WriteLine(item);
                }

            }
            #endregion
            #region Q5
            Console.WriteLine("Question 5");
            // Afficher le classement des types de voiture par nombre de voiture unique présentes du plus grand au plus petit.
            foreach(var item in FakeDb.Instance.Cars.GroupBy(x => x.Type).OrderByDescending(x => x.Count().ToString()))
            {
                foreach (var subitem in item)
                {
                    var nbr = FakeDb.Instance.Cars.FindAll(x => x.Type == subitem.Type).Count();
                    Console.WriteLine(nbr + " => " + subitem.Type);
                    break;
                }
            }

            #endregion
            #region Q6
            Console.WriteLine("Question 6");
            // Afficher les "Garagiste" liés à 4 voitures ou plus.
            role = FakeDb.Instance.Roles.First(x => x.Name.Equals("Garagiste"));
            var garagistes = FakeDb.Instance.Users.FindAll(x => x.Roles.Contains(role));
            foreach(var garagiste in garagistes)
            {
                var nbrVoitures = garagiste.Cars.Count();
                Console.WriteLine(nbrVoitures + " " + garagiste);

                if (nbrVoitures > 3)
                {
                    Console.WriteLine(nbrVoitures + " " + garagiste);
                }
            }
            #endregion
            #region Q7
            Console.WriteLine("Question 7");
            // Afficher les "Controlleur" et la liste des voitures aux quelles ils sont liés.
            role = FakeDb.Instance.Roles.First(x => x.Name.Equals("Controlleur"));
            var controleurs = FakeDb.Instance.Users.FindAll(x => x.Roles.Contains(role));
            foreach(var controleur in controleurs)
            {
                Console.WriteLine(controleur);
                foreach(var voiture in controleur.Cars.ToList())
                {
                    Console.WriteLine(voiture);
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
