using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiXPing
{
    public class SaveManager
    {
        /* ----------------------------------------------------- *\
        |                                                         |
        |                         Methods                         |
        |                                                         |
        \* ----------------------------------------------------- */
        #region Methods

        public static void Save(PlayerData data, string filename)
        {
            string saveFolderPath = Path.Combine("..", "..", "..", "source", "Saves");
            string fullPath = Path.Combine(saveFolderPath, filename);

            var content = JsonSerializer.Serialize(data);

            File.WriteAllText(fullPath, content);
        }

        public static PlayerData Load(string filename)
        {
            string saveFolderPath = Path.Combine("..", "..", "..", "source", "Saves");
            string fullPath = Path.Combine(saveFolderPath, filename);

            if (!File.Exists(fullPath))
            {
                throw new ArgumentException("There is no file named as {0}.", filename);
            }

            // Lire le contenu JSON du fichier
            string content = File.ReadAllText(fullPath);

            // Désérialiser le contenu JSON en un objet GameData
            PlayerData data = JsonSerializer.Deserialize<PlayerData>(content);

            return data;
        }

        #endregion Methods
    }
}
