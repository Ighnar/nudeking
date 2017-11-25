using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnAct : MonoBehaviour {

	// Update is called once per frame
	public void StartBtnAct(){
		SceneManager.LoadScene ("GameScene");
	}
}
