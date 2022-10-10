using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) // happens before OnDragEnd
    {   
        if (transform.childCount==0)
        {//Might not need this at all since we might not move things in the inventory but could be used to combine things
            GameObject droppedObj = eventData.pointerDrag;
            DraggableItem draggedItem = droppedObj.GetComponent<DraggableItem>();
            draggedItem.parentAfterDrag = transform;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
