using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpableItem : MonoBehaviour
{
    GameController gameController;
    ItemDatabaseCreator itemDatabase;
    Item myItem;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        itemDatabase = gameController.gameObject.GetComponent<ItemDatabaseCreator>();
        myItem = itemDatabase.FetchItemBySlug(name);

    }
    private void OnDestroy()
    {
        gameController.inventoryItemID.Add(myItem.ID);
        gameController.inventoryItemAmount.Add(1); 
    }
}