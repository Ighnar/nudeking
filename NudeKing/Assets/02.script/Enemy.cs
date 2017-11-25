using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	GameObject player;
	GameParam gameparam;
	Player _player;
	FakePlayer _fakeplayer;

	Vector3 DirectionVector;



	void Start () {
		gameparam = GameObject.FindGameObjectWithTag ("gamemanager").GetComponent<GameParam>();

		player = GameObject.FindGameObjectWithTag ("Player");
		_player = player.GetComponent<Player>();

		StartCoroutine ("UpdatePosition");

		if (!gameparam.UsingItem2) {
			DirectionVector = _player.firstPosition - transform.position;
		} else {
			player = GameObject.FindGameObjectWithTag ("FakePlayer");
			_fakeplayer = player.GetComponent<FakePlayer> ();
			DirectionVector = _fakeplayer.firstPosition - transform.position;
		}


		float Enemyspeed = 100.0f;

		float DirectionSize = Mathf.Sqrt (DirectionVector.x * DirectionVector.x + DirectionVector.y * DirectionVector.y);

		DirectionVector = DirectionVector / DirectionSize * Enemyspeed;

	}

	// Update is called once per frame
	IEnumerator UpdatePosition () {
		while (!gameparam.gameOver) {
			
			transform.Translate (DirectionVector * Time.deltaTime);
		
			yield return null;
		}
	}
}
