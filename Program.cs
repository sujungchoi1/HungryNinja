using System;
using System.Collections.Generic;
namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            // [x] In your Program's Main method, instantiate a Buffet and Ninja object, and have the Ninja eat until they are full!

            Buffet buffet = new Buffet();
            // buffet.Serve();
            Ninja ninja = new Ninja();

            // only eat while ninja is not full
            while(!ninja.IsFull)
            {
                // ninja.Eat(buffet.Serve());
                var food = buffet.Serve(); //returns a random food item
                ninja.Eat(food);
            }
            ninja.Eat(buffet.Serve()); 
            // Console.WriteLine("ninja is full and cannot eat anymore!");

        }

        class Food
        {
            public string Name;
            public int Calories;
            public bool IsSpicy;
            public bool IsSweet;
            // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet

            public Food(string iName, int iCalories, bool iIsSpicy, bool iIsSweet)
            {
                Name = iName;
                Calories = iCalories;
                IsSpicy = iIsSpicy;
                IsSweet = iIsSweet;
            }
        }
        class Buffet
        {
            // Create a Buffet class, which will contain a Menu of Food objects
            // add a constructor and set Menu to a hard coded list of 7 or more Food objects you instantiate manually
            // build out a Serve method that randomly selects a Food object from the Menu list and returns the Food object
            public List<Food> Menu;

            //constructor
            public Buffet()
            {
                Menu = new List<Food>()
                {
                    new Food("chicken parm", 500, false, false),
                    new Food("caesar salad", 300, false, true),
                    new Food("brownie", 400, false, true),
                    new Food("hawaiin pizza", 200, true, true),
                    new Food("fried chicken", 500, false, false),
                    new Food("grilled eggplant", 1000, false, false),
                    new Food("pineapple", 100, false, true)
                };
            }

            public Food Serve()
            {
                Random rand = new Random();
                var randomIndex = rand.Next(0, Menu.Count);
                return Menu[randomIndex];

                // Random rand = new Random();
                // Food serving = Menu[rand.Next(Menu.Count)];
                // Console.WriteLine(serving.Name);
                // return serving;
            }
        }
       
        class Ninja
        {
            private int calorieIntake;
            public List<Food> FoodHistory;

            // add a constructor
            // [x] add a constructor that sets calorieIntake to 0 and creates a new, empty list of Food objects to FoodHistory
            public Ninja(int calorieIntake = 0)
            {
                FoodHistory = new List<Food>();
            }

            // add a public "getter" property called "IsFull"
            // [x] add a public "getter" property called "IsFull" that returns a boolean based on if the Ninja's calorie intake is greater than 1200 calories
            public bool IsFull
            {
                get
                {
                    if (calorieIntake > 1200)
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
            }

            // build out the Eat method that: if the Ninja is NOT full
                // [x]adds calorie value to ninja's total calorieIntake
                // [x]adds the randomly selected Food object to ninja's FoodHistory list
                // [x]writes the Food's Name - and if it is spicy/sweet to the console
            // if the Ninja IS full
                // [x]issues a warning to the console that the ninja is full and cannot eat anymore
            public void Eat(Food item)
            {
                if (!IsFull)
                {
                    calorieIntake += item.Calories;
                    FoodHistory.Add(item);
                    Console.WriteLine($"*{item.Name}: *Spicy? {item.IsSpicy}; *Sweet? {item.IsSweet}; *Calories so far? {calorieIntake} ");
                }
                else
                {
                    Console.WriteLine("The ninja is full and cannot eat anymore!");
                }
            }
        }


    }



}
