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