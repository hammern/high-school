using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat MyCat = new Cat();
            Console.Write("Name: ");
            string CatName = Console.ReadLine();
            Console.Write("Type: ");
            string TypeOfCat = Console.ReadLine();
            Console.WriteLine("The Cat likes water (enter y if yes and n if no):");
            Console.Write("Likes to water: ");
            string Get_LikesWater = Console.ReadLine();
            bool LikesWater = true;
            bool LikesToMeow = true;
            if (Get_LikesWater == "y")
            {
                LikesWater = true;
            }
            else if (Get_LikesWater == "n")
            {
                LikesWater = false;
            }
            Console.WriteLine("The Cat likes to meow (enter y if yes and n if no):");
            Console.Write("Likes to meow: ");
            string Get_LikesToMeow = Console.ReadLine();
            if (Get_LikesToMeow == "y")
            {
                LikesToMeow = true;
            }
            else if (Get_LikesToMeow == "n")
            {
                LikesToMeow = false;
            }
            MyCat.Set_Cat(CatName, TypeOfCat, LikesWater, LikesToMeow);
            if (MyCat.IsThirsty() == true)
            {
                Console.WriteLine(MyCat.IsThirsty());
            }
            else
            {
                Console.WriteLine(MyCat.IsThirsty());
            }
            Console.WriteLine(MyCat.Meow(LikesToMeow));
            Console.WriteLine(MyCat.Get_StatsOfCat());
            Console.Read();
        }
    }
    public class Cat
    {
        private string CatName;
        private string TypeOfCat;
        private bool LikesWater;
        private bool LikesToMeow;

        public void Set_Cat(string newCatName, string newTypeOfCat, bool newWaterPreference, bool newMeowPreference)
        {
            CatName = newCatName;
            TypeOfCat = newTypeOfCat;
            LikesWater = newWaterPreference;
            LikesToMeow = newMeowPreference;
        }

        public bool IsThirsty()
        {
            return LikesWater;
        }
        public string Meow(bool LikesToMeow)
        {
            if (LikesToMeow == true)
            {
                return "Meow Meow Meow";
            }
            else
            {
                return "Meow";
            }
        }
        public string Get_StatsOfCat()
        {
            return "My Name is " + CatName + " and my type is " + TypeOfCat;
        }
    }
}
