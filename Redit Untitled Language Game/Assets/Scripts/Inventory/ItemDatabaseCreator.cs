using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson; 
using System.IO;


public class ItemDatabaseCreator : MonoBehaviour {
	public List<Item> database = new List<Item> (); 
	private JsonData itemData;

	void Awake ()
	{

       
		itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Json_Databases/Items.json", System.Text.Encoding.UTF7));
		ConstructItemDatabase (); 

	

	}
	public Item FetchItemByTitle(string name){
	
		for (int i = 0; i < database.Count; i++) 
			if (database[i].Name == name)
				return database [i];
				
			
			return null;

	}
	public Item FetchItemBySlug(string slug)
	{

		for (int i = 0; i < database.Count; i++)
			if (database[i].Slug == slug)
				return database[i];


		return null;

	}

	public Item FetchItemByID(int id){

		for (int i = 0; i < database.Count; i++) 
			if (database[i].ID == id)
				return database [i];


		return null;

	}

	void ConstructItemDatabase(){
		for (int i = 0; i < itemData.Count; i++) {
			database.Add (new Item ((int)itemData [i] ["ID"], itemData [i] ["Name"].ToString (),itemData [i] ["Slug"].ToString ()));
			
		}
	}
}

public class Item
{

	public int ID { get; set; }
	public string Name { get; set; }
	public string Slug { get; set; }
	public Sprite Sprite { get; set; }


	public Item(int id, string name, string slug)
	{

		this.ID = id;
		this.Name = name;
		this.Slug = slug;
		this.Sprite = Resources.Load<Sprite>("Icons_Items/" + slug);
	}
	public Item()
	{

		this.ID = -1;
		//this.Title = "no item"; 
	}

}
	

