using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
[RequireComponent(typeof(Image))]
public class MemoryTile : MonoBehaviour
{
    public MemoryTileContainer myContainer;
    public Image myImage;
    public TextMeshProUGUI myText;
    public Sprite myHiddenSprite;
    public Sprite mySprite;
    public Word myWord;
    public bool word;
    bool shown = false; 
    private Color myColor;
    // Start is called before the first frame update
    void Start()
    {
     
      myImage= GetComponent<Image>();
     // mySprite= GetComponent<Sprite>();
      myText= transform.GetChild(0).GetComponent<TextMeshProUGUI>();
      myContainer.Subscribe(this);
      myColor = myImage.color;
    }

    public void ShowHiddenInfo () 
    {
        if (!shown)
        {
            if (word)
            {
                myImage.color = Color.clear;
                myText.text = myWord.Name;
            }
            else
            {
                myImage.color = Color.white; 
                myImage.sprite = Resources.Load<Sprite>("Icons_Words/" + myWord.Slug);
            }
            shown = true;
        }
        else {
            myText.text = "";
            myImage.color = myColor;
            myImage.sprite = mySprite;
            shown = false;
        }
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
