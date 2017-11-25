using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBtnAct : MonoBehaviour {
	//0- replay, 1- rank
	public Button[] gameOverBtn;
	//0- 환경설정 1- 초기화 2- 영점설정 3- 뒤로가기 (창 끄기)
	public Button[] SettingBtn;
	UiSetting _uiSetting;

	int BtnNum;
	// Use this for initialization
	void Start(){
		_uiSetting = this.GetComponent<UiSetting> ();
	}

	public void ReplayBtn(){
		//Load Scene;
		SceneManager.LoadScene("GameScene");
	}

	public void RankBtn(){
		//google play, gameCenter link

	}

	public void SettingBtnAct(){
		//show setting panel
		BtnNum = 1;
		_uiSetting.ShowPanel (BtnNum);
	}

	public void CancleBtnAct(){
	//Disappear setting Panel
		BtnNum = 1;
		_uiSetting.DisappearPanel (BtnNum);
	}

	public void InitGyroBtnAct(){
		//Initializing Gyro
	}

	public void SettingGyroBtnAct(){
	//show GyzoSetting
	}
}
