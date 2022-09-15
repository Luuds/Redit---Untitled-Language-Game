using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SaveData
    { // Include all save data here as individual variables
        public int LevelIndex  { get; set; } 
        public Vector3 PlayerPos { get; set; }
        public List<int> InventoryItemID { get; set; } //Lists items in inventory by their ID number, order indicates place in inventory, 
        public List<int> InventoryItemAmount { get; set; } //Lists items in inventory by their ID number, order indicates place in inventory,
        public List<int> WordsFound { get; set; } //Full list, numbers indicate amount found, 0 means not found  
        public List<int> EnvironmentObjectsScanned { get; set; } //Full list, 1 indicates scanned, 0 means not scanned
        public SaveData(int levelIndex, Vector3 playerPos, List<int> inventoryItemID, List<int> inventoryItemAmount, List<int> wordsFound, List<int> environmentObjectsScanned)
        {
            this.LevelIndex = levelIndex;
            this.PlayerPos = playerPos;
            this.InventoryItemID = inventoryItemID;
            this.InventoryItemAmount = inventoryItemAmount;
            this.WordsFound = wordsFound;   
            this.EnvironmentObjectsScanned = environmentObjectsScanned;
        }
        public SaveData() { }
    }


}