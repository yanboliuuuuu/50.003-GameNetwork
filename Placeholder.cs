using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Placeholder : MonoBehaviour {

	public Text CoinCount;
	public int Score;

	void Update () {
		Vector3 namePos = Camera.main.WorldToScreenPoint (this.transform.position);
		CoinCount.transform.position = namePos;}

	public void CollectCoin(int amt){
		//		if (!isServer) {
		//			return;
		//		}
		Score += amt;
		CoinCount.text = "Coins:" + Score.ToString ();
	}
}
