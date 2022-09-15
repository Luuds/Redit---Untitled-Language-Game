using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class EnvironmentHotspotDatabaseCreator : MonoBehaviour {
	public List<Hotspot> database = new List<Hotspot> (); 
	private JsonData hotspotData;

	// Use this for initialization
	void Awake () {

        //path = Application.dataPath + "/StreamingAssets/Inventorys.json";
        hotspotData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Resources/Json_Databases/EnvironmentHotspots.json", System.Text.Encoding.UTF7));
		//hotspotData = JsonMapper.ToObject (File.ReadAllText(path +"/Hotspots.json")); 
		ConstructHotspotDatabase (); 
	}

	public void ConstructHotspotDatabase(){
		for (int i = 0; i < hotspotData.Count; i++) {
			List<int> itemAcceptList = new List <int> (); 
			
			for (int k = 0; k < hotspotData [i] ["ItemAcceptList"].Count; k++) {
				itemAcceptList.Add ((int)hotspotData [i] ["ItemAcceptList"] [k]); 
			
				
			}
			
			database.Add (new Hotspot ((int)hotspotData[i]["ID"],hotspotData[i]["Name"].ToString(),hotspotData[i]["Slug"].ToString(), itemAcceptList)); 
		}
	}
	public Hotspot FetchHotspotByTitle(string name){

		for (int i = 0; i < database.Count; i++) 
			if (database[i].Name == name)
				return database [i];


		return null;

	}public Hotspot FetchHotspotBySlug(string slug){

		for (int i = 0; i < database.Count; i++) 
			if (database[i].Slug == slug)
				return database [i];
		


		return null;

	}
	public Hotspot FetchHotspotByID(int id){

		for (int i = 0; i < database.Count; i++) 
			if (database[i].ID == id)
				return database [i];


		return null;

	}
}

public class Hotspot{
	public int ID { get; set; }
	public string Name { get; set; }
	public string Slug{ get; set;}
	public List <int> itemAcceptList { get; set;}



	public Hotspot(int id, string name, string slug, List <int> itemAcceptList)
	{
		this.ID = id;
		this.Name = name;
		this.Slug = slug;
		this.itemAcceptList = itemAcceptList;
	
	}
	public Hotspot(){
		this.ID = -1; 

	}

}