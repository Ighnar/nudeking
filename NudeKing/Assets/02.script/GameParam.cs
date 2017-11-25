using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParam : MonoBehaviour {
	public float SizeX = 750;

	public float SizeY = 1334;

	public bool gameOver {
		get;
		set;
	}

	public bool UsingItem1 {
		get;
		set;
	}
	public bool UsingItem2{
		get;
		set;
	}

	public bool HavingItem1{
		get;
		set;
	}

	public int itemNum {
		get;
		set;
	}

	void Awake(){
		Init ();
	}

	public void Init(){
		gameOver = false;
		HavingItem1 = false;
		UsingItem1 = false;
		UsingItem2 = false;
		itemNum = 0;
	}
}
