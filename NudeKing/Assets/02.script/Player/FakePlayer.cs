using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour {

	// Use this for initialization
	public static GameParam gameparam;

	public Vector3 firstPosition;

	void Start () {
		gameparam = GameObject.FindGameObjectWithTag ("gamemanager").GetComponent<GameParam>();
	}

	// Update is called once per frame
	void Update () {
		if (gameparam.gameOver)
			return;
		

		transform.Translate (new Vector3 (0, 100, 0) * Time.deltaTime);
		firstPosition = transform.position;

		if (transform.position.y > 1334.0f / 2.0f) {
			gameparam.UsingItem2 = false;
			Destroy (this.gameObject);
		} 
		else {
			gameparam.UsingItem2 = true;
		}
			
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag.Equals( "1"))
			Destroy(this.gameObject);
	}
}
