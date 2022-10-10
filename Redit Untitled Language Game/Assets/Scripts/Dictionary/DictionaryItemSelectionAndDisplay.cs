using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; 

public class DictionaryItemSelectionAndDisplay : MonoBehaviour
{
    public List<DictionaryWord> words;

    GameObject wordDescription;
    GameObject wordImage;
    GameObject wordName;

    // Start is called before the first frame update
    void Start()
    {   wordImage = transform.GetChild(0).gameObject; 
         wordDescription = transform.GetChild(1).gameObject;
        wordName = transform.GetChild(2).gameObject;
    }
    public void Subscribe(DictionaryWord word)
    {
      

        if (words == null)
        {
            words = new List<DictionaryWord>();
        }
        words.Add(word);
    }
    public void OnWordSelected(DictionaryWord word)
    {
        wordDescription.GetComponent<TextMeshProUGUI>().text = word.myWord.Description;
        wordImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Icons_Words/" + word.myWord.Slug);
        wordName.GetComponent<TextMeshProUGUI>().text = word.myWord.Name;
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
