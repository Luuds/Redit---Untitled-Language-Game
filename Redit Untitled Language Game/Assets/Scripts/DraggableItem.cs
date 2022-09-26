using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour , IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Image itemImage;
    GameController gameController;
    public int itemPlaceNumber;
    public int itemID;
    public int itemAmount;
    public string itemName;
    public string itemSlug;

    void Start()
    {
       
        itemImage = GetComponent<Image>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {   
        parentAfterDrag = transform.parent; 
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        itemImage.raycastTarget = false; 
        
    }

    public void OnDrag(PointerEventData eventData)
    {
       transform.position = Input.mousePosition; // editor expection for touch?
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);

        if (hit.collider.CompareTag("Scannable")) {
           
            GameObject tempHotspotObj = hit.collider.gameObject; 
            Hotspot tempHotSpotData = tempHotspotObj.GetComponent<EnvironmentHotspot>().thisHotspotData;
            bool isAcceptable = false;
            for (int i = 0; i < tempHotSpotData.itemAcceptList.Count; i++)
            {
                if (itemID == tempHotSpotData.itemAcceptList[i]) { 
                isAcceptable = true;
                }
            }
            if (isAcceptable)
            {
                Debug.Log("Destroy!");
                Destroy(parentAfterDrag.gameObject);
                gameController.inventoryItemID.Remove(itemID);
               gameController.inventoryItemAmount.Remove(itemID);
                Destroy(this.gameObject);
            }
            else
            {
                transform.SetParent(parentAfterDrag);
                itemImage.raycastTarget = true;
            }
        }
        else {
            transform.SetParent(parentAfterDrag);
            itemImage.raycastTarget = true;
        }
    }
    public void OnDestroy()
    {
        
        

    }

}
