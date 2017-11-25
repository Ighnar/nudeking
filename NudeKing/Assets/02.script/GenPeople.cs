using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPeople : MonoBehaviour {
	//0-girl 1- police
	public GameObject[] people;

	int girlGenNum = 3;
	int policeGenNum = 4;
	// Use this for initialization

	public void GeneratePeople(int time){
		
		
		if(time % 50 == 0){
			for (int i = 0; i < girlGenNum; i++) 
				Instance_girl();

		}
		if(time % 20 == 0){
			for (int i = 0; i < policeGenNum; i++) 
				Instance_enemy();
		}
		if (time % 15 == 0) {
			policeGenNum += (int)Random.Range(-1,1);
			if (policeGenNum <= 2)
				policeGenNum = 3;
		}
	}	

	void Instance_enemy(){
		Vector3 randomPosition = GenPosition (1);
		GameObject instanceEnemy = (GameObject)Instantiate (people[1], randomPosition, Quaternion.identity);
	
	}

	void Instance_girl(){
		Vector3 randomPosition = GenPosition (0);
		GameObject instanceGirl = (GameObject)Instantiate (people[0], randomPosition, Quaternion.identity);
	}

	Vector3 GenPosition(int peopleNum){
		
		Vector3 position = Vector3.zero;
		float random;
		switch (peopleNum) {
		case 0:
			random = Random.Range (-8, 8);
			position = new Vector3(-4.0f,random* 0.1f,0.0f);
			break;
		case 1:
			random = Random.Range (-2.7f, 2.7f);
			position = new Vector3(random,4.8f,0.0f);
			break;
		}

		return position;
	}
}
