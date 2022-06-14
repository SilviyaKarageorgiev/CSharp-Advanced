using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            List<Trainer> trainers = new List<Trainer>();

            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                if (trainers.Any(trainer => trainer.Name == trainerName) == false)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }
                
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers.First(trainer => trainer.Name == trainerName).Pokemons.Add(pokemon);
            }

            string element;
            while ((element = Console.ReadLine()) != "End")
            {
                CheckPokemons(trainers, element);
            }

            foreach (Trainer trainer in trainers.OrderByDescending(trainer => trainer.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

        }
        private static void CheckPokemons(List<Trainer> trainers, string element)
        {
            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(pokemon => pokemon.Element == element))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (Pokemon pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }

                    trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                }
            }
        }
    }
}
