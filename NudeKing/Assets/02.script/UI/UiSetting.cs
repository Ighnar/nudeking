using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetting : MonoBehaviour {
	//0- gameOverPanel 1- settingPanel 2- gyroSettingPanel
	public GameObject[] panelView;
	public GameObject gameManager;

	Vector3 mainOriginP;
	Vector3 destinationP;
	RectTransform _rectTransform;
	// Use this for initialization

	void Start(){
		panelView [2].SetActive (false);
	}

	//at GameOver call;
	public void ShowPanel(int panelNum){
		if (panelNum != 2) {

			print ("call");
			print ("panelNum:" + panelNum);
			_rectTransform = panelView [panelNum].GetComponent<RectTransform> ();
			mainOriginP = _rectTransform.anchoredPosition;

			destinationP = new Vector3 (0.0f, 0.0f, 0.0f);
			_rectTransform.anchoredPosition = destinationP;
		} else {
			panelView [panelNum].SetActive(true);
		}
	}

	public void DisappearPanel(int panelNum){
		if (panelNum != 2) {
			_rectTransform.anchoredPosition = mainOriginP;
		} else {
			panelView [panelNum].SetActive (false);
		}
	}


}
