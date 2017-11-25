using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPeople : MonoBehaviour {
	//0-girl 1- police
	public GameObject[] people;

	int girlGenNum = 1;
	int policeGenNum = 1;
	private EnemyInfo _enemy;
	// Use this for initialization

	public void GeneratePeople(int time){
		if(time % 50 == 0){
			for (int i = 0; i < girlGenNum; i++) {
		//		Vector3 randomPosition = GenPosition (0);
		//		GameObject instanceGirl = (GameObject) Instantiate(people[0], randomPosition, Quaternion.identity);	
				_enemy = Instance_enemy(0);
			}
		}else if(time % 20 == 0){
			for (int i = 0; i < policeGenNum; i++) {
		//		Vector3 randomPosition = GenPosition (1);
		//		GameObject instancePol = (GameObject) Instantiate(people[1], randomPosition, Quaternion.identity);	
				_enemy = Instance_enemy(1);
			}		
		}
	}	

	EnemyInfo Instance_enemy(int enemynum){
		Vector3 randomPosition = GenPosition (enemynum);
		GameObject instanceGirl = (GameObject)Instantiate (people[enemynum], randomPosition, Quaternion.identity);
		EnemyInfo newEnemy = instanceGirl.GetComponent <EnemyInfo> ();
	
		newEnemy.info (enemynum);
		return newEnemy;
	}



	Vector3 GenPosition(int peopleNum){
		Vector3 position = Vector3.zero;
		float random;
		switch (peopleNum) {
		case 0:
			random = Random.Range (-10, 10);
			position = new Vector3(random * 0.1f,6.2f,0.0f);
			break;
		case 1:
			random = Random.Range (15, 25);
			position = new Vector3(-4.2f,random * 0.1f,0.0f);
			break;
		}
		return position;
	}
}
