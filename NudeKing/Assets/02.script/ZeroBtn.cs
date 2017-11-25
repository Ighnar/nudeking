using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZeroBtn : MonoBehaviour {

	public Button buttons;

	PlayerSource _playersource;

	// Use this for initialization
	void Start(){
		_playersource = GameObject.FindGameObjectWithTag ("ZeroPlayer").GetComponent<PlayerSource>();
	}
	// Update is called once per frame
	public void StartBtnAct(){
		_playersource.SelectZero ();
	}
}
