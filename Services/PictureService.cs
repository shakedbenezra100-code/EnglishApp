using System.Collections.Generic;
using System.Linq;

namespace EnglishApp.Services
{
    public class PictureService
    {
        private readonly Dictionary<string, List<string>> _pictureCategories = new Dictionary<string, List<string>>
        {
            {
                "Food", new List<string>
                {
                    "images/food/apple.png",
                    "images/food/banana.png",
                    "images/food/carrot.png",
                    "images/food/pizza.png"
                }
            },
            {
                "Animals", new List<string>
                {
                    "images/animals/cat.png",
                    "images/animals/dog.png",
                    "images/animals/elephant.png",
                    "images/animals/lion.png"
                }
            },
            {
                "Colors", new List<string>
                {
                    "images/colors/blue.png",
                    "images/colors/green.png",
                    "images/colors/red.png",
                    "images/colors/yellow.png"
                }              
            },
            {
                "Numbers", new List<string>
                {
                    "images/numbers/one.png",
                    "images/numbers/two.png",
                    "images/numbers/three.png",
                    "images/numbers/four.png"
                }        
            },
            {
                "Clothes", new List<string>
                {
                    "images/clothes/shirt.png",
                    "images/clothes/pants.png",
                    "images/clothes/dress.png",
                    "images/clothes/shoes.png"
                }              
            },
            {
                "Seasons", new List<string>
                {
                    "images/seasons/spring.png",
                    "images/seasons/summer.png",
                    "images/seasons/fall.png",
                    "images/seasons/winter.png"
                }     
            },
            {
                "Family Members", new List<string>
                {
                    "images/family_members/mother.png",
                    "images/family_members/father.png",
                    "images/family_members/brother.png",
                    "images/family_members/sister.png"
                }                
            },
            {
                "Rooms", new List<string>
                {
                    "images/rooms/living_room.png",
                    "images/rooms/bedroom.png",
                    "images/rooms/kitchen.png",
                    "images/rooms/bathroom.png"
                }                
            },
            {
                "Transportation", new List<string>
                {
                    "images/transportation/car.png",
                    "images/transportation/bus.png",
                    "images/transportation/bike.png",
                    "images/transportation/truck.png"
                }                
            },
            {
                "The Human Body", new List<string>
                {
                    "images/human_body/head.png",
                    "images/human_body/arm.png",
                    "images/human_body/leg.png",
                    "images/human_body/hand.png"
                }                
            },
            {
                "Stuff", new List<string>
                {
                    "images/stuff/table.png",
                    "images/stuff/bottle.png",
                    "images/stuff/ball.png",
                    "images/stuff/bed.png"
                }                
            }
        };

        public IEnumerable<string> GetCategories()
        {
            return _pictureCategories.Keys;
        }

        public IEnumerable<string> GetPictures(string category)
        {
            if (_pictureCategories.TryGetValue(category, out var pictures))
            {
                return pictures;
            }
            return Enumerable.Empty<string>();
        }
    }
}