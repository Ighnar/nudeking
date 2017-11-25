using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParam : MonoBehaviour {

	public bool gameOver {
		get;
		set;
	}

	void Awake(){
		Init ();
	}

	public void Init(){
		gameOver = false;
	}
}
