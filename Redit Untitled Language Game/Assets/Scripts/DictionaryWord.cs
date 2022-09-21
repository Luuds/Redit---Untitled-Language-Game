using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DictionaryWord : MonoBehaviour,IPointerClickHandler
{
    public Word myWord;
    public DictionaryItemSelectionAndDisplay dictionaryPanel; 

    // Start is called before the first frame update
    void Start()
    {
        dictionaryPanel.Subscribe(this);
        if (transform.GetSiblingIndex() == 0) 
        {
            dictionaryPanel.OnWordSelected(this);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        dictionaryPanel.OnWordSelected(this); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
