using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System;

public class WordDatabaseCreator : MonoBehaviour
{
	public List<Word> database = new List<Word>();
	private JsonData wordData;
	GameController gameController;
	void Awake()
	{
		gameController = GetComponent<GameController>();


		wordData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Json_Databases/Words.json", System.Text.Encoding.UTF7));
		ConstructWordDatabase();

		Debug.Log("Database count:" + database.Count.ToString()); 

	}
	public Word FetchWordByTitle(string name)
	{

		for (int i = 0; i < database.Count; i++)
			if (database[i].Name == name)
				return database[i];


		return null;

	}

	public Word FetchWordByID(int id)
	{

		for (int i = 0; i < database.Count; i++)
			if (database[i].ID == id)
				return database[i];


		return null;

	}
	public List <Word> FetchWordListByType(string type)
	{
		

		//Debug.Log(database[1].Type.Count);
		List<Word> words = new List<Word>();
		for (int i = 0; i < database.Count; i++)
		{
			for (int j = 0; j < database[i].Type.Count; j++)
			{
				if (database[i].Type[j] == type)
				{
					
					//Debug.Log(database[i].Type[j]);
					words.Add(database[i]);
					continue; 
				

				}
			
			}
		}
		SortWordByName sortWordByName = new SortWordByName();
		words.Sort(sortWordByName);
		
		return words;

	}

	void ConstructWordDatabase()
	{
		
		
		for (int i = 0; i < wordData.Count; i++)
		{
			List<string> types = new List<string>();

			for (int k= 0; k < wordData[i]["Type"].Count ; k++)
            {
				
				types.Add(wordData[i]["Type"][k].ToString());
			}

			database.Add(new Word((int)wordData[i]["ID"], wordData[i]["Name"].ToString(), wordData[i]["Slug"].ToString(), types, wordData[i]["Description"].ToString()));
			gameController.wordsFound.Add(0); 
		}
	}
}
public class SortWordByName : IComparer<Word>
{
	public int Compare(Word x, Word y)
	{
		return x.Name.CompareTo(y.Name);
	}
}
public class Word
{

	public int ID { get; set; }
	public string Name { get; set; }
	public string Slug { get; set; }
	public List <string> Type { get; set; }
	public string Description { get; set; }
	public Sprite Sprite { get; set; }



	public Word(int id, string name, string slug, List <string>type, string description)
	{

		this.ID = id;
		this.Name = name;
		this.Slug = slug;
		this.Type = type;
		this.Description = description;
		this.Sprite = Resources.Load<Sprite>("Icons_Words/" + slug);

	}
	public Word()
	{

		this.ID = -1;
		//this.Title = "no Word"; 
	}

}