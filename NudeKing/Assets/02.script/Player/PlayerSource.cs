using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSource : MonoBehaviour {

	public Vector3 firstPosition;

	static public float speed = 4.0f;

	protected Gyroscope gyro;

	protected Vector3 gyroscope_rotation;

	protected GameObject GameManager;

	public static Vector3 zeroAngle = new Vector3(0,0,0);

	// Use this for initialization
	protected void Start () {
		gyro = Input.gyro;
		gyro.enabled = true;
		Input.gyro.updateInterval = 0.01f; 

		GameManager = GameObject.FindGameObjectWithTag ("gamemanager");

		firstPosition = new Vector3(219.0f,354.0f, 0);
		
	}
	
	protected void Update () {

		//right & left
		gyroscope_rotation.y =	Input.gyro.attitude.eulerAngles.y-PlayerSource.zeroAngle.y;
		if (gyroscope_rotation.y < 0)
			gyroscope_rotation.y += 360;

		///forward & backward
		gyroscope_rotation.x = Input.gyro.attitude.eulerAngles.x-PlayerSource.zeroAngle.x;
		if (gyroscope_rotation.x < 0)
			gyroscope_rotation.x += 360;
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
			return a * a *(-1)/300.0f;
		else
			return a * a /300.0f;
	}

	public void SelectZero(){
		zeroAngle.x = Input.gyro.attitude.eulerAngles.x;
		zeroAngle.y = Input.gyro.attitude.eulerAngles.y;
	}
	public void SelectReset(){
		zeroAngle.x = 0;
		zeroAngle.y = 0;
	}
}
