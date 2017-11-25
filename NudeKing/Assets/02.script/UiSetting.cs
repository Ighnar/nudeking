using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSetting : MonoBehaviour {
	public GameObject[] panelView;
	public GameObject gameManager;

	GameParam _gameParam;
	Vector3 mainOriginP;
	// Use this for initialization

	void Awake () {
		_gameParam = gameManager.GetComponent<GameParam> ();
		StartInit (_gameParam.gameStart, false);
	}
	//startBtn act
	public void StartInit(bool startBool, bool replayBool){
		RectTransform _rectTransform = panelView [0].GetComponent<RectTransform> ();
		//
		if (!startBool) {
			mainOriginP = _rectTransform.anchoredPosition;
			_rectTransform.anchoredPosition = new Vector2 (0.0f, 0.0f);
		} else {
			_rectTransform.anchoredPosition = mainOriginP;
			panelView [0].SetActive (false);
		}
	}
}
