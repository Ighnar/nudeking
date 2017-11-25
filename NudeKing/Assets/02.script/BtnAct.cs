using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnAct : MonoBehaviour {

	public Button[] buttons;

	// Use this for initialization
	void Start(){
		
	}
	// Update is called once per frame
	public void StartBtnAct(){
		print ("start");
		SceneManager.LoadScene ("GameScene");
	}
}
