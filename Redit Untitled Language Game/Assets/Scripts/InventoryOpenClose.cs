using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro; 
public class InventoryOpenClose : MonoBehaviour
{
    ItemDatabaseCreator itemDatabaseCreator;
    GameController gameController;
    GameObject inventoryScroll;
    GameObject inventorySlot;
    GameObject inventoryItem;
    GameObject tempInvMenu;
    Button button;
    Image image;
    public  Sprite bagOpen;
    public Sprite bagClosed;
    bool open = false;

    void Start()
    {
        itemDatabaseCreator = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemDatabaseCreator>();
        gameController = GameObject.FindGameObjectWithTag( "GameController").GetComponent<GameController>();    
        button = GetComponent<Button>(); 
        inventoryScroll = Resources.Load("Prefabs/InventoryScroller") as GameObject;
        inventorySlot = Resources.Load("Prefabs/InventorySlot") as GameObject;
        inventoryItem = Resources.Load("Prefabs/InventoryItem") as GameObject;
        image= GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 1f; 
    }

        public void InventoryOpenClosed() 
    {
        if (!open)
        {
            tempInvMenu = Instantiate(inventoryScroll, transform.parent);
            tempInvMenu.transform.SetAsFirstSibling();
            Transform panel = tempInvMenu.transform.GetChild(0);

            for (int i = 0; i < gameController.inventoryItemID.Count; i++)
            {
                GameObject tempSlot = Instantiate(inventorySlot, panel);
                GameObject tempItem = Instantiate(inventoryItem, tempSlot.transform);
                DraggableItem itemData = tempItem.GetComponent<DraggableItem>(); 
                itemData.itemPlaceNumber = i;
                itemData.itemID = gameController.inventoryItemID[i];
                itemData.itemAmount = gameController.inventoryItemAmount[i];
                itemData.itemName = itemDatabaseCreator.FetchItemByID(gameController.inventoryItemID[i]).Name;
                tempItem.name = itemDatabaseCreator.FetchItemByID(gameController.inventoryItemID[i]).Name;
                itemData.itemSlug = itemDatabaseCreator.FetchItemByID(gameController.inventoryItemID[i]).Slug;
                tempItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons_Items/" + itemData.itemSlug);
                tempItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemData.itemName;
               
            }
           open = true;
            GetComponent<Image>().sprite = bagOpen; 
        }
        else {
        
            Destroy(tempInvMenu);
            tempInvMenu = null;
            open = false;
            GetComponent<Image>().sprite = bagClosed;
            EventSystem.current.SetSelectedGameObject(null);
        }
        //button.interactable = false; 
    }


    // Update is called once per frame
    void Update()
    {
        if (open && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() )
        {
            InventoryOpenClosed(); 
        }
    }
}
