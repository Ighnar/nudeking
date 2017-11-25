using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenItem : MonoBehaviour {
	//0-무적 1- 바바리맨

	public GameObject[] Item;

	public void GenerateItem(int time){
		GameObject instanceItem;
		if (time % 70 == 0) {
			print ("Item1");
			instanceItem = (GameObject) Instantiate(Item[0],new Vector3(0.0f,0.0f,0.0f), Quaternion.identity);
		}if(time % 100 == 0){
			print ("Item2");
			instanceItem = (GameObject) Instantiate(Item[1],new Vector3(0.0f,-10.0f,0.0f), Quaternion.identity);			
		}	
	}
}
