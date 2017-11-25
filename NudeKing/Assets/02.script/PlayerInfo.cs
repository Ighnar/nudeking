using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
	//0 - normal 1- item1 2- item2
	public int status;

	public void info(int count){
		status = count;
		switch (status) {
		case 0:
			print("Item1");
			break;
		case 1:
			print("Item2");
			break;
		}
	}
}
