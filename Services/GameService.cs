using System.Collections.Generic;
using System.Linq;
using System;

namespace EnglishApp.Services
{
    public class GameService
    {
        public string SelectedCategory { get; private set; } = "";
        public List<string> CurrentCategoryImages { get; private set; } = new();

        // אירוע שיעדכן את הרכיבים כשהקטגוריה משתנה
        public event Action? OnCategoryChanged;

        // הגדרת התמונות מראש (או שמות הקבצים המדויקים שיש לך בתיקיות)
        private readonly Dictionary<string, List<string>> _categoryDatabase = new()
        {
        // משנים מ-.jpg ל-.png ומוסיפים את התחילית _food או _animal לפי השמות האמיתיים
            { "Food", Enumerable.Range(1, 20).Select(i => $"/images/Food/{i}.jpg").ToList() },
            { "Animals", Enumerable.Range(1, 10).Select(i => $"/images/Animals/{i}.jpg").ToList() }
        };

        public void SelectCategory(string category)
        {
            if (_categoryDatabase.ContainsKey(category))
            {
                SelectedCategory = category;
                CurrentCategoryImages = _categoryDatabase[category];
                OnCategoryChanged?.Invoke();
            }
        }

        // פונקציית עזר להגרלת X תמונות ייחודיות מתוך המאגר הנוכחי
        public List<string> GetRandomImages(int count)
        {
            var random = new Random();
            return CurrentCategoryImages.OrderBy(x => random.Next()).Take(count).ToList();
        }

        // פונקציית תאימות עבור המשחקים שמחפשים את רשימת התמונות של הקטגוריה
        public List<string> GetCategoryImages(string category)
        {
            if (_categoryDatabase.ContainsKey(category))
            {
                return _categoryDatabase[category];
            }
        // תמיכה למקרה שהמשחק שולח "Food" או "מאכלים"
            if (category == "מאכלים" && _categoryDatabase.ContainsKey("Food")) return _categoryDatabase["Food"];
            if (category == "חיות" && _categoryDatabase.ContainsKey("Animals")) return _categoryDatabase["Animals"];
        
            return CurrentCategoryImages;
        }
    }
}