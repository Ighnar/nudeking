using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text timeText;

	private GenItem _genItem;
	private GenPeople _genPeople;
	private GameParam _gameParam;

	public GameObject GameManager;
	public int time {
		get;
		set;
	}
	public int score;
		
	[System.NonSerialized]
	public string timeToString;


	void Start(){
		_genItem = GameManager.GetComponent<GenItem> ();
		_genPeople = GameManager.GetComponent<GenPeople>();
		_gameParam = GameManager.GetComponent<GameParam> ();
		StartCoroutine ("TimeCountDown");
	}

	IEnumerator TimeCountDown(){
		WaitForSeconds delay = new WaitForSeconds (0.1f);
		timeToString = time.ToString ();
		while (time >= 0) {
			while (!_gameParam.gameOver) {
				time += 1;
				score += 1;
//			_genItem.GenerateItem (time);
				_genPeople.GeneratePeople (time);
				//timeToString = string.Format ("{0:00}:{1:00}", time / 60, time % 60);
				StringBuilder addScore_sb = new StringBuilder ();
				addScore_sb.Append (score);
				timeText.text = addScore_sb.ToString ();
				yield return delay;
			}
			yield return delay;
		}
	}

	public void AddGirlScore(){
		score += 300;
	}
}
