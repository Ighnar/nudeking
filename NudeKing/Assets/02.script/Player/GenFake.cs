using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenFake : MonoBehaviour {

	public GameObject[] fakeplayer;

	public void GenPlayer(Vector3 vec){
		Instantiate (fakeplayer[0], vec, Quaternion.identity);

	}
}
