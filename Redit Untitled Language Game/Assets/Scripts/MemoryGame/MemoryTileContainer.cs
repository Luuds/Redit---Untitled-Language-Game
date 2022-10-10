using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryTileContainer : MonoBehaviour
{
    public string wordType = "Park";
    public List<Color> colors;
    public List<MemoryTile> tiles;
    private int tileID = 0; 
    public List<Word> words = new List<Word>();
    private List<bool> wordBools = new List<bool>();
    private GameController gameController;
    private WordDatabaseCreator wordDatabaseCreator;
    // Start is called before the first frame update
    void Awake()
    {
        tileID = 0; 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        wordDatabaseCreator= gameController.gameObject.GetComponent<WordDatabaseCreator>(); 
        words = wordDatabaseCreator.FetchWordListByType("Park");
        
        if (words.Count < 9)
        {  List<Word> extraWords = wordDatabaseCreator.FetchWordListByType(wordType);
            int extraWordCount = extraWords.Count;
           for (int i = 0; i < extraWordCount; i++)
           {
              words.Add(extraWords[i]);
           }
        }
        Shuffle(words);
        while (words.Count > 10)
        {
            words.RemoveAt(words.Count-1);
        }
        for (int i = 0; i < 10; i++)
        {
            wordBools.Add(true);
        }
       
        int wordCount = words.Count;
        for (int i = 0; i < wordCount; i++)
        {
            words.Add(words[i]);
            wordBools.Add(false);
        }
        ShuffleTwoEqualLists(words, wordBools);

        for (int i = 0; i < words.Count ; i++) 
        {
            Debug.Log (words[i].Name);
        }
      
    }
    public void Subscribe(MemoryTile tile)
    {
        if (tiles == null)
        {
            tiles = new List<MemoryTile>();
        }
        tiles.Add(tile);

        tile.myImage.color = new Color(Random.Range(colors[0].r, colors[1].r), Random.Range(colors[0].g, colors[1].g), Random.Range(colors[0].b, colors[1].b));
        tile.myWord = words[tileID];
        tile.word = wordBools[tileID];
        tile.name = tile.myWord.Name;
        tileID++;


    }
    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
    void ShuffleTwoEqualLists<T,L>(List<T> inputList1, List<L> inputList2)
    {
        for (int i = 0; i < inputList1.Count; i++)
        {
            T temp = inputList1[i];
            L temp2 = inputList2[i];
            int rand = Random.Range(i, inputList1.Count);
            inputList1[i] = inputList1[rand];
            inputList1[rand] = temp;
            inputList2[i] = inputList2[rand];
            inputList2[rand] = temp2;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
