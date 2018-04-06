using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Networking;


public class StarCountPlaceHolderPosition : MonoBehaviour {
	//this script acts like a healthbar, updates the score for each player

	//[SyncVar]
	public Text StarCount;
	public int Score;

	// Update is called once per frame
	void Update () {
		Vector3 namePos = Camera.main.WorldToScreenPoint (this.transform.position);
		StarCount.transform.position = namePos;}

	public void CollectStar(int amt){
//		if (!isServer) {
//			return;
//		}
		Score += amt;
		StarCount.text = "Star Count:" + Score.ToString ();
	}

//	void SetScoreText(){
//		StarCount.text = "Star Count:" + Score.ToString ();
//	}
//

}
