//This Implements the factory method design pattern using abstract classes an overrides. Please see guide for a link to an implementation that uses interfaces instead.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    /// <summary>
    /// MainApp startup class for Real-World 
    /// Factory Method Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Note: constructors call Factory Method
            AnimalHome[] homes = new AnimalHome[3];
            homes[0] = new Zoo();
            homes[1] = new House();
            homes[2] = new Farm();
            // documents[1] = new Report();
            // Display document pages
            foreach (AnimalHome home in homes)
            {
                Console.WriteLine("\n-------" + home.GetType().Name + "------");
                foreach (Animal animal in home.Animals)
                {
                    Console.WriteLine(" " + animal.GetType().Name);
                }
            }
            // Wait for user
            Console.ReadKey();
        }
    }
    /// <summary>
    /// The 'Product' abstract class
    /// </summary>
    abstract class Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Dog : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Cat : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Giraffe : Animal
    {
    }
    /// <summary>
    /// A 'ConcreteProduct' class
    /// </summary>
    class Cow : Animal
    {
    }

    /// <summary>
    /// The 'Creator' abstract class
    /// </summary>
    abstract class AnimalHome
    {
        private List<Animal> _animals = new List<Animal>();
        // Constructor calls abstract Factory method
        public AnimalHome()
        {
            this.CreateAnimals();
        }
        public List<Animal> Animals
        {
            get { return _animals; }
        }
        // Factory Method
        public abstract void CreateAnimals();
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class Zoo : AnimalHome
    {
        // Factory Method implementation
        public override void CreateAnimals()
        {
            Animals.Add(new Giraffe());

        }
    }
    /// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
    class House : AnimalHome
    {
        // Factory Method implementation
        public override void CreateAnimals()
        {
            Animals.Add(new Cat());
            Animals.Add(new Dog());
            Animals.Add(new Dog());
            Animals.Add(new Dog());

        }

    }
	
	
	
	/// <summary>
    /// A 'ConcreteCreator' class
    /// </summary>
        class Farm : AnimalHome
        {
            // Factory Method implementation
            public override void CreateAnimals()
            {
                Animals.Add(new Cow());


            }


        }

    }
