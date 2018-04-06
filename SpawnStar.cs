using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

//this script controls handling non-player objects, they should be spawned on the server basis

public class SpawnStar : NetworkBehaviour {

	public GameObject StarPrefab;
	//public int numOfstar;
	//Vector3 StarPos;
	public bool haveStar = false;

	public override void OnStartServer(){
			Vector3 StarPos = new Vector3 (Random.Range (-8.0f, 8.0f), Random.Range (-7f, 7f), 0);
			GameObject StarSpawner = (GameObject)Instantiate(StarPrefab,StarPos,Quaternion.identity);
			NetworkServer.Spawn(StarSpawner);
			Debug.Log ("Star");
		}

//	void Respawn(){
//		NetworkServer.
//	}
			
}
