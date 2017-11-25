using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetting : MonoBehaviour {
	//0- gameOverPanel 1- settingPanel 2- gyroSettingPanel
	public GameObject[] panelView;
	public GameObject gameManager;

	GameParam _gameParam;
	Vector3 mainOriginP;
	Vector3 destinationP;
	RectTransform _rectTransform;
	// Use this for initialization

	void Awake () {
		_gameParam = gameManager.GetComponent<GameParam> ();
	}
		
	//at GameOver call;
	public void ShowPanel(int panelNum){
		_rectTransform = panelView[panelNum].GetComponent<RectTransform> ();
		mainOriginP = _rectTransform.anchoredPosition;

		destinationP = new Vector3 (0.0f, 0.0f, 0.0f);
		_rectTransform.anchoredPosition = destinationP;
	}

	public void DisappearPanel(int panelNum){
		_rectTransform.anchoredPosition = mainOriginP;
	}


}
