using System.Collections.Generic;
using System.Linq;

namespace EnglishApp.Services
{
    public class PictureService
    {
        private readonly Dictionary<string, Dictionary<string, string>> _pictureCategories = new Dictionary<string, Dictionary<string, string>>
        {
            {
                "Food", new Dictionary<string, string>
                {
                    { "apple", "תפוח" },
                    { "banana", "בננה" },
                    { "carrot", "גזר" },
                    { "pizza", "פיצה" }
                }
            },
            {
                "Animals", new Dictionary<string, string>
                {
                    { "4", "חתול" },
                    { "3", "כלב" },
                    { "2", "פיל" },
                    { "1", "אריה" }
                }
            },
            {
                "Colors", new Dictionary<string, string>
                {
                    { "blue", "כחול" },
                    { "green", "ירוק" },
                    { "red", "אדום" },
                    { "yellow", "צהוב" }
                }
            },
            {
                "Numbers", new Dictionary<string, string>
                {
                    { "1", "אחד" },
                    { "2", "שתיים" },
                    { "3", "שלוש" },
                    { "4", "ארבע" },
                    { "5", "חמש" },
                    { "6", "שש" }
                }
            },
            {
                "Clothes", new Dictionary<string, string>
                {
                    { "shirt", "חולצה" },
                    { "pants", "מכנסיים" },
                    { "dress", "שמלה" },
                    { "shoes", "נעליים" }
                }
            },
            {
                "Seasons", new Dictionary<string, string>
                {
                    { "spring", "אביב" },
                    { "summer", "קיץ" },
                    { "fall", "סתיו" },
                    { "winter", "חורף" }
                }
            },
            {
                "Family Members", new Dictionary<string, string>
                {
                    { "mother", "אמא" },
                    { "father", "אבא" },
                    { "brother", "אח" },
                    { "sister", "אחות" }
                }
            },
            {
                "Rooms", new Dictionary<string, string>
                {
                    { "living_room", "סלון" },
                    { "bedroom", "חדר שינה" },
                    { "kitchen", "מטבח" },
                    { "bathroom", "אמבטיה" }
                }
            },
            {
                "Transportation", new Dictionary<string, string>
                {
                    { "car", "מכונית" },
                    { "bus", "אוטובוס" },
                    { "bike", "אופניים" },
                    { "truck", "משאית" }
                }
            },
            {
                "The Human Body", new Dictionary<string, string>
                {
                    { "head", "ראש" },
                    { "arm", "זרוע" },
                    { "leg", "רגל" },
                    { "hand", "יד" }
                }
            },
            {
                "Stuff", new Dictionary<string, string>
                {
                    { "table", "שולחן" },
                    { "bottle", "בקבוק" },
                    { "ball", "כדור" },
                    { "bed", "מיטה" }
                }
            }
        };

        public IEnumerable<string> GetCategories()
        {
            return _pictureCategories.Keys;
        }

        public IEnumerable<KeyValuePair<string, string>> GetPicturesWithTranslations(string category)
        {
            if (_pictureCategories.TryGetValue(category, out var wordsAndTranslations))
            {
                return wordsAndTranslations;
            }
            return Enumerable.Empty<KeyValuePair<string, string>>();
        }

        public IEnumerable<string> GetPictures(string category)
        {
            // First, try to get the category with the provided casing
            if (_pictureCategories.TryGetValue(category, out var wordsAndTranslations))
            {
                return wordsAndTranslations.Select(kv => $"bootstrap/images/{category.ToLower().Replace(" ", "_")}/{kv.Key}.jpg.jpeg");
            }

            // If not found, try to find a case-insensitive match
            var key = _pictureCategories.Keys.FirstOrDefault(k => k.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (key != null && _pictureCategories.TryGetValue(key, out wordsAndTranslations))
            {
                return wordsAndTranslations.Select(kv => $"bootstrap/images/{key.ToLower().Replace(" ", "_")}/{kv.Key}.jpg.jpeg");
            }

            return Enumerable.Empty<string>();
        }

        public string GetHebrewTranslation(string category, string englishWord)
        {
            if (_pictureCategories.TryGetValue(category, out var wordsAndTranslations))
            {
                if (wordsAndTranslations.TryGetValue(englishWord, out var translation))
                {
                    return translation;
                }
            }
            return "Translation Not Found"; // Or handle as appropriate
        }
    }
}
