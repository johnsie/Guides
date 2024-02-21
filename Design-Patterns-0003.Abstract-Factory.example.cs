using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{


 //Defind the abstract objects that the concrete classes will extend
 //We're selling burger and a side. The factories will decide which types of burger to and side to build

    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Burger { }

    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Side { }






    //Concrete classes for the burders. These are the different types of burger and side (see above) which are available

    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class BigMeatBuger : Burger { }



    /// <summary>
    /// A concrete object
    /// </summary>
    class VeganPlantBurger : Burger { }

    /// <summary>
    /// A concrete object
    /// </summary>
    class Carrot : Side { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    /// 


    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class Hotwing : Side { }



//All meals created will need to have a burger and a side. So create the abstract class for that

    /// <summary>
    /// The AbstractFactory class, which defines methods for creating abstract objects.
    /// </summary>
    abstract class ComboFactory
    {
        public abstract Burger CreateBurger();
        public abstract Side CreateSide();
    }









    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class CarnivoreFoodFactory : ComboFactory
    {
        public override Burger CreateBurger()
        {
            return new BigMeatBuger();
        }

        public override Side CreateSide()
        {
            return new Hotwing();
        }
    }



    class VeganFoodFactory : ComboFactory
    {
        public override Burger CreateBurger()
        {
            return new VeganPlantBurger();
        }

        public override Side CreateSide()
        {
            return new Carrot();
        }
    }





//Below we have code that utlises factoies to create meals depending on the customer's preference

 

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you eat animal products? (Y)es or (N)o?");
            char input = Console.ReadKey().KeyChar;
            ComboFactory factory;
            switch (input)
            {
                case 'y':
                    factory = new CarnivoreFoodFactory();
                    break;

                case 'n':
                    factory = new VeganFoodFactory();
                    break;

                default:
                    throw new NotImplementedException();

            }

            //This user has selected their preference and the appropriate factory has been chosen
            //Now use that factory to build the meals

            var burger = factory.CreateBurger();
            var side = factory.CreateSide();

            Console.WriteLine("\nBurger: " + burger.GetType().Name);
            Console.WriteLine("Side: " + side.GetType().Name);

            Console.ReadKey();
        }
    }
}
