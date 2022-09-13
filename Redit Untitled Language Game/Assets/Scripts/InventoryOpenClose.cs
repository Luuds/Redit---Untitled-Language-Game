
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class InventoryOpenClose : MonoBehaviour
{
    GameObject inventoryScroll;
    GameObject inventorySlot;
    GameObject inventoryItem;
    GameObject tempInvMenu;
    Button button;
    Image image;
    public  Sprite bagOpen;
    public Sprite bagClosed;
    public int inventorySlotsCountTemp = 5; // remove should be controlled through inventory database
    bool open = false;

    void Start()
    {   button = GetComponent<Button>(); 
        inventoryScroll = Resources.Load("Prefabs/InventoryScroller") as GameObject;
        inventorySlot = Resources.Load("Prefabs/InventorySlot") as GameObject;
        inventoryItem = Resources.Load("Prefabs/InventoryItem") as GameObject;
        image= GetComponent<Image>();
      //  bagClosed = Resources.Load("Menu_Icons/Bag_closed.png") as Sprite;
        //bagOpen = Resources.Load("Menu_Icons/Bag.png") as Sprite;
        image.alphaHitTestMinimumThreshold = 1f; 
    }

        public void InventoryOpenClosed() 
    {
        if (!open)
        {
            tempInvMenu = Instantiate(inventoryScroll, transform.parent);
            tempInvMenu.transform.SetAsFirstSibling();
            Transform panel = tempInvMenu.transform.GetChild(0);

            for (int i = 0; i < inventorySlotsCountTemp; i++)
            {
                GameObject tempSlot = Instantiate(inventorySlot, panel);
                GameObject tempItem = Instantiate(inventoryItem, tempSlot.transform);
                tempItem.GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // testing purposes
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
