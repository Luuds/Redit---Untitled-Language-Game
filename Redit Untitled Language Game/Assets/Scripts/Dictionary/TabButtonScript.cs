using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

[RequireComponent (typeof(Image))]
public class TabButtonScript : MonoBehaviour, IPointerClickHandler
{   public TabGroup tabGroup;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this); 
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image> ();
        tabGroup.Subscribe(this);
        if (transform.GetSiblingIndex() == 0) 
        {
            tabGroup.OnTabSelected(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
