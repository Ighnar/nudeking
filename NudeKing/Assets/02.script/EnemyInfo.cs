using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour {

	// Use this for initialization

	public int id;

	public void info(int count){
		id = count;
		switch (id) {
		case 0:
			gameObject.name = "GIRL";
			break;
		case 1:
			gameObject.name = "POLICE";
			break;
		}
	}
}
