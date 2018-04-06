using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starcollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision ){

		var hit = collision.gameObject;
		var points = hit.GetComponent<StarCountPlaceHolderPosition> ();
		if (hit.CompareTag("Player")){
			points.CollectStar(1);
		}
		Destroy(gameObject);
	}
//
	//	void OnTriggerEnter2D(Collider2D hit){
	//		if(hit.CompareTag("Player")){
	//			player.points += point;
	//
	//			haveStar = false;
	//			Spawn ();
	//
	//			Destroy (gameObject);
	//
	//			Debug.Log ("YES" + player.points);
	//		}
	//	}
}
