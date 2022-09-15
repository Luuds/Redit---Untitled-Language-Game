using System.IO; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [HideInInspector]public  List<int> inventoryItemID = new List<int>(); // key = item number , value = item amount
    [HideInInspector] public List<int> inventoryItemAmount = new List<int>(); // key = item number , value = item amount
    // Start is called before the first frame update
    void Awake ()
    {   DontDestroyOnLoad(this); 

        for (int i = 0; i < 2; i++) { // Should be set with inventory database or somethign
            inventoryItemID.Add(i);
            inventoryItemAmount.Add(0);
        }
    }
    public void Save() {
    
    }
    public void Load() {
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
	
}
