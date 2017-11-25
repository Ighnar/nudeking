using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

[System.Serializable] 
public class Item{
	public int MyScore;
	public int PlayCount;

	public Item(int myScore, int playCount){
		MyScore = myScore;
		PlayCount = playCount;
	}
}
	
public class GameData : MonoBehaviour {

	public Item myItem;
	string saveName ;


	void Awake(){
		saveName = "/savedgame.json";
		StartCoroutine ("LoadCo");
	}

	public void SaveFunc(){
		string toJson = JsonUtility.ToJson (myItem);

		//creat new file
		//이미 존재 하면 덮어씀
		#if UNITY_IOS
		File.WriteAllText (Application.persistentDataPath + saveName, toJson);
		#else
		File.WriteAllText (Application.persistentDataPath + saveName, toJson);
		#endif
	}

	void InitList(){
		//초기값 설정
		myItem.MyScore = 0;	
		myItem.PlayCount = 0;
	}

	public void LoadFunc(){
		StartCoroutine ("LoadCo");
	}

	IEnumerator LoadCo(){

		if (File.Exists (Application.persistentDataPath + saveName)) {
			#if UNITY_IOS
			string JsonString = File.ReadAllText(Application.persistentDataPath + saveName);
			#else
			string JsonString = File.ReadAllText (Application.persistentDataPath + saveName);
			#endif

			InitList ();
			JsonUtility.FromJsonOverwrite(JsonString, myItem);
	
		} else {
			//file not exist -> creat file
			InitList ();
			SaveFunc();
		}
		yield return null;
	}
}
