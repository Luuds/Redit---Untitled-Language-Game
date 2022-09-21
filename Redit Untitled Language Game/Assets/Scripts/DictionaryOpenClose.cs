using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryOpenClose : MonoBehaviour
{
    GameObject tempDicMenu;
    GameObject dictionaryMenu; 
    bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        dictionaryMenu = Resources.Load("Prefabs/DictionaryMenu") as GameObject; 
    }
    public void DictionaryOpenClosed()
    {
        if (!open)
        {
            tempDicMenu = Instantiate(dictionaryMenu,transform.parent);
            open = true;

        }
        else
        {
            Destroy(tempDicMenu);
            tempDicMenu = null;
            open = false; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
