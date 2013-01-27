using UnityEngine;
using System.Collections;

public class Keyboard : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//-- Ecran_titre
		//--> Space : Scene
		//--> Return : Credits
		
		//-- Credits
		//--> Return : Ecran_titre
		
		//-- SceneDeath
		//--> Space : Ecran_Titre
		
		string nextScene = string.Empty;
		
		if(Application.loadedLevelName == "Ecran_Titre")
		{
			if(Input.GetKey(KeyCode.Space))
				nextScene = "Scene";
			if(Input.GetKey(KeyCode.Return))
				nextScene = "Credits";
		}
		else if(Application.loadedLevelName == "Credits")
		{
			if(Input.GetKey(KeyCode.Space))
				nextScene = "Ecran_Titre";
		}
		else if(Application.loadedLevelName == "SceneDeath")
		{
			if(Input.GetKey(KeyCode.Space))
				nextScene = "Ecran_Titre";
		}
		
		if(!string.IsNullOrEmpty(nextScene))
			Application.LoadLevel(nextScene);
		
	}
}
