using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour {
	private Gyroscope gyro;

	Vector3 gyroscope_rotation;
	public Vector3 firstPosition;
	public bool gameOver;
	static public float speed = 10.0f;

	static Vector3 zeroAngle = new Vector3(0,0,0);

	public GameObject GameManager;
	public GameObject _canvas;

	GameParam _gameParam;
	Score _score;

	void Start () {
		_gameParam = GameManager.GetComponent<GameParam> ();
		_score = _canvas.GetComponent<Score> ();
		gyro = Input.gyro;
		gyro.enabled = true;
		Input.gyro.updateInterval = 0.01f; 
		firstPosition = new Vector3(0, 0, 0);
	}

	void Update () {

		//right & left
		gyroscope_rotation.y =	Input.gyro.attitude.eulerAngles.y-zeroAngle.y;

		///forward & backward
		gyroscope_rotation.x = Input.gyro.attitude.eulerAngles.x-zeroAngle.x;

		//0~60 300~360

		//0~60 -60~ 0
		if (gyroscope_rotation.x >= 300)
			gyroscope_rotation.x -= 360;
		else if (gyroscope_rotation.x >= 210)
			gyroscope_rotation.x = -60;
		else if (gyroscope_rotation.x >= 150)
			return;
		else if (gyroscope_rotation.x >= 60)
			gyroscope_rotation.x = 60;

		if (gyroscope_rotation.y >= 300)
			gyroscope_rotation.y -= 360;
		else if (gyroscope_rotation.y >= 210)
			gyroscope_rotation.y = -60;
		else if (gyroscope_rotation.y >= 150)
			return;
		else if (gyroscope_rotation.y >= 60)
			gyroscope_rotation.y = 60;



		Vector3 DirectionVector = new Vector3 (GetGraph (gyroscope_rotation.y), GetGraph (gyroscope_rotation.x *(-1)), 0);


		speed = Mathf.Sqrt (DirectionVector.x * DirectionVector.x + DirectionVector.y * DirectionVector.y);

//		print ("x : " + DirectionVector.x);
		firstPosition += DirectionVector*Time.deltaTime;


		transform.Translate (DirectionVector * Time.deltaTime);

		float Angle;

		if (DirectionVector.x != 0) {
			float TanValue = DirectionVector.y / DirectionVector.x;

			Angle = Mathf.Atan (TanValue) * 180.0f / Mathf.PI;
			if (Angle > 0) {
				if (DirectionVector.x < 0)
					Angle += 180;
			} else {
				if (DirectionVector.x > 0)
					Angle += 360;
				else
					Angle += 180;
			}
		} else {
			Angle = DirectionVector.y>0?90:270 ;


		}

		transform.SetPositionAndRotation(firstPosition, Quaternion.Euler (new Vector3 (0, 0, Angle-90)));

	}

	float GetGraph(float a){
		if(a<0)
			return a * a / 100.0f*(-1);
		else
			return a * a / 100.0f;
	}

	void OnTriggerEnter2D(Collider2D other){
		//tag 1: girl, 2: police
		switch (other.tag) {
		case "1":
			_score.AddGirlScore ();
			Destroy (other.gameObject);
			break;
		case "2":
			Destroy (this.gameObject);
			_gameParam.gameOver = true;
			gameOver = _gameParam.gameOver;
			break;
		}
	}
}