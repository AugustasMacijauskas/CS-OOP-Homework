﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1.Step2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = ReadDogData();
            dogs = ReadDogData();
            SaveReportToFile(dogs);

            Console.WriteLine("Kurio amžiaus agresyvius šunis skaičiuoti?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Agresyvių šunų kiekis: " + CountAggressive(dogs, age));

            Console.WriteLine("Kurios veislės šunis filtruoti?");
            string breedToFilter = Console.ReadLine();
            List<Dog> filteredByBreed = FilterByBreed(dogs, breedToFilter);
            foreach(Dog dog in filteredByBreed)
            {
                Console.WriteLine(dog.Name);
            }

            Console.WriteLine("Kurios veislės seniausius šunis surasti?");
            breedToFilter = Console.ReadLine();
            List<Dog> oldestDogs = FindOldestDogs(dogs, breedToFilter);
            PrintDogsToConsole(oldestDogs);

            List<string> breeds = GetBreeds(dogs);

            Console.WriteLine("Skirtingos Veislės:");
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }

            Console.WriteLine("Vakcinos galiojimas baigėsi:");
            foreach (Dog dog in dogs)
            {
                if (dog.isVaccinationExpired())
                {
                    Console.WriteLine(String.Format("Vardas: {0}, Šeimininkas: {1}, Telefonas: {2} ", dog.Name, dog.Owner, dog.Phone));
                }
            }

            Console.Read();
        }

        /// <summary>
        /// Saves dog data to CSV type file
        /// </summary>
        /// <param name="dogs">List of dogs to save into CSV file</param>
        private static void SaveReportToFile(List<Dog> dogs)
        {
            using (StreamWriter writer = new StreamWriter(@"L1SavedData.csv"))
            {
                writer.WriteLine("Vardas;MikroId;Svoris;Amžius;Savininkas;Tel. Nr.;Vakcinacija;Agresyvumas");
                foreach (Dog dog in dogs)
                {
                    writer.WriteLine("{0};{1};{2};{3};{4};{5};{6};{7}", dog.Name, dog.ChipId, dog.Weight, dog.Age, dog.Owner, dog.Phone, dog.VaccinationDate, dog.Aggressive);
                }
            }
        }

        /// <summary>
        /// Prints dog data into Console window
        /// </summary>
        /// <param name="dogs">List of dogs to print</param>
        static void PrintDogsToConsole(List<Dog> dogs)
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine("Vardas: {0}\nMikroschemos ID: {1}\nSvoris: {2}\nAmžius: {3}\nSavininka: {4}\nTelefonas: {5}\nVakcinacijos data: {6}\nAgrsyvus: {7}\n", dog.Name, dog.ChipId, dog.Weight, dog.Age, dog.Owner, dog.Phone, dog.VaccinationDate, dog.Aggressive);
            }
        }

        /// <summary>
        /// Read dog data from CSV file
        /// </summary>
        /// <returns>List of dogs</returns>
        private static List<Dog> ReadDogData()
        {
            List<Dog> dogs = new List<Dog>();

            using (StreamReader reader = new StreamReader(@"L1Data.csv"))
            {
                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(';');
                    string name = values[0];
                    int chipId = int.Parse(values[1]);
                    double weight = Convert.ToDouble(values[2]);
                    int age = int.Parse(values[3]);
                    string breed = values[4];
                    string owner = values[5];
                    string phone = values[6];
                    DateTime vaccinationDate = DateTime.Parse(values[7]);
                    bool aggressive = bool.Parse(values[8]);

                    Dog dog = new Dog(name, chipId, weight, age, breed, owner, phone, vaccinationDate, aggressive);

                    dogs.Add(dog);
                }
            }

            return dogs;
        }

        /// <summary>
        /// Find all different breeds existing in a dog list 
        /// </summary>
        /// <param name="dogs">The list of dogs</param>
        /// <returns>Breed list</returns>
        private static List<string> GetBreeds(List<Dog> dogs)
        {
            List<string> breeds = new List<string>();

            foreach(Dog dog in dogs)
            {
                if (!breeds.Contains(dog.Breed))
                {
                    breeds.Add(dog.Breed);
                }
            }

            return breeds;
        }

        /// <summary>
        /// Filter dogs by its breed
        /// </summary>
        /// <param name="dogs">List of dogs</param>
        /// <param name="breed">Specific breed to look for</param>
        /// <returns>List of filtered dogs</returns>
        private static List<Dog> FilterByBreed(List<Dog> dogs, string breed)
        {
            List<Dog> filtered = new List<Dog>();

            foreach (Dog dog in dogs)
            {
                if (breed.Equals(dog.Breed))
                {
                    filtered.Add(dog);
                }
            }

            return filtered;
        }

        /// <summary>
        /// Find oldest dogs of the specific breed
        /// </summary>
        /// <param name="dogs">List of dogs</param>
        /// <param name="breed">Breed to look for</param>
        /// <returns>List of the oldest dogs</returns>
        private static List<Dog> FindOldestDogs(List<Dog> dogs, string breed)
        {
            List<Dog> oldestDogs = new List<Dog>();
            List<Dog> filteredDogs = FilterByBreed(dogs, breed);
            int maxAge = 0;

            foreach (Dog dog in filteredDogs)
            {
                if (dog.Age > maxAge)
                {
                    maxAge = dog.Age;
                }
            }

            foreach (Dog dog in filteredDogs)
            {
                if (dog.Age == maxAge)
                {
                    oldestDogs.Add(dog);
                }
            }

            return oldestDogs;
        }

        /// <summary>
        /// Count aggressive dogs of the specific age
        /// </summary>
        /// <param name="dogs">List of dogs</param>
        /// <param name="age">Age to filter</param>
        /// <returns></returns>
        private static int CountAggressive(List<Dog> dogs, int age)
        {
            int counter = 0;
            foreach (Dog dog in dogs)
            {
                if ((dog.Aggressive.Equals(true))&&(dog.Age == age))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
