using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGyro : MonoBehaviour {
	private Gyroscope gyro;
	Vector3 gyroscope_rotation;
	float gyroscopeVec;
	int forwardParam;
	int rightParam;

	float gyroZ;
	// Use this for initialization
	void Start () {
		gyro = Input.gyro;
		gyro.enabled = true;
		Input.gyro.updateInterval = 0.01f; 
		print ("INIT");
		print ("gyroscope_rotation.x:" + gyroscope_rotation.x);
		print ("gyroscope_rotation.y:" + gyroscope_rotation.y);
	}
	
	// Update is called once per frame
	void Update () {
		
		gyroZ = Input.gyro.attitude.z;
//		print ("attitude.z: " + gyroZ);
		if (gyroZ < 1 && gyroZ > -1) {
			gyroZ = 0.0f;
		}

		//right & left
		gyroscope_rotation.y =	Input.gyro.attitude.eulerAngles.y;// Input.gyro.rotationRateUnbiased.y;

		///forward & backward
		gyroscope_rotation.x = Input.gyro.attitude.eulerAngles.x;//rotationRateUnbiased.x;
		//.........
/*		if (Mathf.Abs (gyroscope_rotation.y) < 0.5f) {
			gyroscope_rotation.y = 0;
		} else {
		
		}

		if (gyroscope_rotation.y <= 60.0f) {
			//right

		}else if(gyroscope_rotation.y >= 300.0f){
			//left
		}
*/
		if (gyroscope_rotation.x <= 60.0f) {
			//forward
			if(gyroscope_rotation.x < 0.5f){
				gyroscope_rotation.x = 0;
			}
			forwardParam = -1;
		}else if(gyroscope_rotation.x >= 300.0f){
			forwardParam = 1;
			gyroscope_rotation.x = 360 - gyroscope_rotation.x;
			//back
		}
		transform.Translate (Vector3.up* forwardParam * gyroscope_rotation.x * Time.deltaTime * 0.1f);

		print ("gyroscope_rotation.x :" + gyroscope_rotation.x);
//		transform.Rotate (0.0f, 0.0f, gyroscope_rotation.y * Time.deltaTime * 50.0f);

//		print ("gyroscope_rotation.y:" + gyroscope_rotation.y);
//		print ("gyroscope_rotation.z:" + gyroscope_rotation.z);

//		transform.Rotate (0.0f, gyroscope_rotation.y * Time.deltaTime * 50.0f, 0.0f);

//		print ("transform.rotate:" + transform.rotation);
//		print ("transform.quant:" + transform.rotation.eulerAngles);

	}
}
