using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	GameObject player;
	Player _player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		_player = player.GetComponent<Player> ();
		StartCoroutine ("UpdatePosition");
	}

	// Update is called once per frame
	IEnumerator UpdatePosition () {
		while (!_player.gameOver) {
			Vector3 DirectionVector = _player.firstPosition - transform.position;

			float Enemyspeed = 5.0f;

			float DirectionSize = Mathf.Sqrt (DirectionVector.x * DirectionVector.x + DirectionVector.y * DirectionVector.y);

			DirectionVector = DirectionVector / DirectionSize * Enemyspeed;

			transform.Translate (DirectionVector * Time.deltaTime);
		
			yield return null;
		}
	}
}
