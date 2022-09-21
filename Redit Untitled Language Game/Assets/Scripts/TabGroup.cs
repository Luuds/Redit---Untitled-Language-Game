using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabGroup : MonoBehaviour
{   
    public List<TabButtonScript> buttons;
    public Sprite selectedTab;
    public Sprite unselectedTab;
    public TabButtonScript selectedButton;
    WordDatabaseCreator wordDatabase;
    GameObject dictionarySlot;
    GameObject dictionaryItem;
    public GameObject dictionaryScroller;
    public GameObject descMenu;
    GameObject dictionaryPanel; 
    GameObject tempDictionaryPage;
    public GameObject categoryText; 
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        dictionarySlot = Resources.Load("Prefabs/DictionarySlot") as GameObject;
        dictionaryItem = Resources.Load("Prefabs/DictionaryItem") as GameObject;
        dictionaryPanel = Resources.Load("Prefabs/DictionaryPanel") as GameObject;
        wordDatabase = GameObject.FindGameObjectWithTag("GameController").GetComponent<WordDatabaseCreator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void Subscribe(TabButtonScript button)
    {
        if (buttons == null) 
        {
            buttons = new List<TabButtonScript>();
        }
        buttons.Add(button);
    }
    public void OnTabSelected(TabButtonScript button)
    {
        categoryText.GetComponent<TextMeshProUGUI>().text = button.gameObject.name;
        selectedButton = button; 
        ResetTabs(); 
        button.background.sprite = selectedTab;
        InstantiateDictionaryPage(button.name);
    }

    public void InstantiateDictionaryPage( string type)
    {
        List<Word> wordsToCheck = new List<Word>();
        List<Word> wordsToDisplay = new List<Word>();
        wordsToCheck = wordDatabase.FetchWordListByType(type);
       
        foreach (Word word in wordsToCheck)
        {
            if (gameController.wordsFound[word.ID] == 1) { wordsToDisplay.Add(word); }
           
        }

        tempDictionaryPage = Instantiate(dictionaryPanel, dictionaryScroller.transform); 

        for (int i = 0; i < wordsToDisplay.Count; i++)
        {
            GameObject tempDictionaryItem = Instantiate(dictionaryItem, tempDictionaryPage.transform);
            DictionaryWord tempWordscript = tempDictionaryItem.GetComponent<DictionaryWord>(); 
            tempWordscript.myWord = wordsToDisplay[i];
            tempWordscript.dictionaryPanel = descMenu.GetComponent<DictionaryItemSelectionAndDisplay>(); 
            tempDictionaryItem.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tempWordscript.myWord.Name;
            tempDictionaryItem.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons_Words/" + tempWordscript.myWord.Slug);
        }
    }

    public void ResetTabs()
    {
        foreach (TabButtonScript button in buttons) 
        {
            button.background.sprite = unselectedTab; 
        }
        //categoryText.GetComponent<TextMeshProUGUI>().text = ""; 
        if (tempDictionaryPage != null) 
        {Destroy(tempDictionaryPage.gameObject);

        }
    }

  

    // Update is called once per frame
    void Update()
    {
        
    }
}
