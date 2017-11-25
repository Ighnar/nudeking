using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {
	public GameObject Player;

	Vector3 prePosition;

	public GameObject[] backgrounds;

	bool addBack = false;
	float length;
	int count = 0;
	// Use this for initialization
	void Start () {
		prePosition = backgrounds [3].transform.localPosition;
		length = backgrounds [3].GetComponent<SpriteRenderer> ().size.y;
		StartCoroutine ("MoveDown");
	}
	// Update is called once per frame

	IEnumerator MoveDown(){
		while(this.gameObject != null){
			this.transform.Translate (Vector2.down * Time.deltaTime* 0.75f);
				if (transform.position.y <= length * count) {
				Vector3 Nextposition = prePosition + new Vector3 (0.0f, 1.0f, 0.0f) * length * 0.8f;
				prePosition = Nextposition;
				GameObject instanceBackground = (GameObject)Instantiate (backgrounds [RandomBackNum()], Vector3.zero, Quaternion.identity);
				instanceBackground.transform.SetParent (this.transform);
				instanceBackground.transform.localPosition = prePosition;
				if (count < 0) {
					Destroy (this.transform.GetChild (0).gameObject);
				}
				count -= 1;
			} 
			yield return new WaitForSeconds (0.01f);
		}
	}

	int RandomBackNum(){
		int RandomNum = Random.Range (0, 10);
		if (RandomNum < 1) { //0,1
			RandomNum = 0;
		} else { //2-9
			if (RandomNum < 5) {// 2,3,4
				RandomNum = 1;
			} else { ////5,6,7,8,9
				if (RandomNum < 9) { //5,6,7
					RandomNum = 2;
				} else { //8,9
					RandomNum = 3;
				}
			}
		}
		return RandomNum;
	}



}
