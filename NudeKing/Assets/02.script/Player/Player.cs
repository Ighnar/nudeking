using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerSource {


	public bool gameOver;


	public GameObject _canvas;

	PlayerInfo _playerInfo;
	GameParam _gameParam;
	Score _score;

	GenFake _genfake;

	void Start () {
		base.Start ();
		_gameParam = GameManager.GetComponent<GameParam> ();
		_score = _canvas.GetComponent<Score> ();
		_genfake = GameManager.GetComponent<GenFake>();

		FakePlayer.gameparam = _gameParam;

		firstPosition = new Vector3(3.82f, -491.0f, 0);
	}
	void Update(){
		base.Update ();
	}
	void OnTriggerEnter2D(Collider2D other){
		//tag 1: girl, 2: police 3: item1(무적), 4: item2(복제)
		IEnumerator coroutine;
		switch (other.tag) {
		case "1":
			_score.AddGirlScore ();
			//player가 item을 먹었는지 판단
			Destroy (other.gameObject);
			break;
		case "2":
			print ("other.name:" + other.name);
			//player가 item을 먹었는지 판단
			if (!_gameParam.UsingItem1&&_gameParam.HavingItem1) {
				_gameParam.HavingItem1 = false;
				_gameParam.UsingItem1 = true;
				coroutine = WaitItem(3.0f,1);
				StartCoroutine (coroutine);

			}else if(_gameParam.UsingItem1){
				
			}else{
				_gameParam.gameOver = true;
				//GAME OVER
			}
			gameOver = _gameParam.gameOver;
			break;
		case "3":
			_gameParam.HavingItem1 = true;
			Destroy (other.gameObject);
			print ("Item1");
			break;
		case "4":
			//
			_genfake.GenPlayer(transform.position);
			Destroy (other.gameObject);
			print ("Item2");
			break;
		}
	}
	private IEnumerator WaitItem(float waitTime,int type)
	{
		yield return new WaitForSeconds(waitTime);
		if(type==1)
			_gameParam.UsingItem1 = false;
		else if(type==2)
			_gameParam.UsingItem2 = false;
	}
}