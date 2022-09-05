using System.IO;
using LitJson; 
using UnityEngine;
namespace SaveLoadSystem {
    public static class SaveGameManager
    {
        
        const string SaveDirectory = "/SaveData/";
        const string SaveFileName = "SaveGame.sav";


        public static bool Save(SaveData currentSaveData)
        // Set In gamecontroller save function  "SaveLoadSystem.SaveGameManager.Save(dataToBeSaved) = "
        {

            var dir = Application.persistentDataPath + SaveDirectory; 
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string json = JsonUtility.ToJson(currentSaveData, true);
            File.WriteAllText (dir + SaveFileName, json);

            return true; 
        }

        public static SaveData Load() {

            string fullpath = Application.persistentDataPath + SaveDirectory+ SaveFileName;
            SaveData tempData = new SaveData();

            if (File.Exists(fullpath)) {

                string json = File.ReadAllText(fullpath);
                tempData = JsonUtility.FromJson<SaveData>(json);

            } 
            else
            {
                Debug.LogError("Save file does not exist!"); 
                    
            }
            // Deconstruct loaded save data where you call load and set each variable
            return tempData;

            //As such  Player.position = SaveLoadSystem.SaveGameManager.Load.playerPos; 
        }
    }
}