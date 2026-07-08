using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace EnglishApp.Services
{
    public class GameService
    {
        public List<string> GetCategoryImages(string categoryName)
        {
            var imageUrls = new List<string>();
            
            try
            {
                string baseImagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "bootstrap", "images");

                if (!Directory.Exists(baseImagesPath))
                {
                    return imageUrls;
                }

                string normalizedSearch = categoryName.ToLower().Trim();

                // מוצא את התיקייה הנכונה (למשל food)
                string folderPath = Directory.GetDirectories(baseImagesPath)
                    .FirstOrDefault(d => {
                        string actualName = Path.GetFileName(d).ToLower();
                        return actualName == normalizedSearch || 
                               actualName == normalizedSearch.TrimEnd('s') || 
                               normalizedSearch == actualName.TrimEnd('s');
                    });

                if (folderPath == null || !Directory.Exists(folderPath))
                {
                    folderPath = Directory.GetDirectories(baseImagesPath).FirstOrDefault();
                }

                if (folderPath != null && Directory.Exists(folderPath))
                {
                    // שולף את כל הקבצים
                    var files = Directory.GetFiles(folderPath, "*.*")
                                         .Where(s => s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || 
                                                     s.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || 
                                                     s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                                         .ToList();

                    string actualFolderName = Path.GetFileName(folderPath);

                    foreach (var file in files)
                    {
                        // 🌟 התיקון הקריטי: לוקח אך ורק את השם האמיתי של הקובץ מהדיסק בלי שום מניפולציה או תוספת!
                        string fileName = Path.GetFileName(file);
                        
                        imageUrls.Add($"bootstrap/images/{actualFolderName}/{fileName}");
                    }
                }
            }
            catch (Exception)
            {
                // הגנה מקריסה
            };

            return imageUrls.Take(8).ToList();
        }
    }
}