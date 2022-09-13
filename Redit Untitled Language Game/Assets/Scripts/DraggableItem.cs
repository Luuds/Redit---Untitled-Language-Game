using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour , IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [HideInInspector] public Transform parentAfterDrag;
    Image itemImage;

    void Start()
    {
        itemImage = GetComponent<Image>();
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
        transform.SetParent(parentAfterDrag);
        itemImage.raycastTarget = true;

    }

   
}
