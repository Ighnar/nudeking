using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

	// Use this for initialization

	public GameObject GameManager;
	GameParam _gameParam ;

	void Start () {
		_gameParam = GameObject.FindGameObjectWithTag ("gamemanager").GetComponent<GameParam>();
		 

	}
	
	// Update is called once per frame
	void Update () {
		if (_gameParam.gameOver)
			return;
		
		transform.Translate (new Vector3 (100, 0, 0) * Time.deltaTime);

		if (transform.position.x > _gameParam.SizeX / 2.0f) {
			Destroy (this.gameObject);
		} 
	}
}
