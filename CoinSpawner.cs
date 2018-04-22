using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoinSpawner : NetworkBehaviour {

	public GameObject CoinPrefab;
	//public int numOfCoins;

	public override void OnStartServer(){

		var spawnPosition = new Vector3(
			Random.Range(-6f, 6f),
			Random.Range(1f, 6f),
			0);;

		var spawnRotation = Quaternion.Euler( 
			0.0f, 
			0.0f, 
			0.0f);

		var coin = (GameObject)Instantiate(CoinPrefab, spawnPosition, spawnRotation);
		NetworkServer.Spawn(coin);
	}

//		for (int i =0; i < numOfCoins; i++){
//			
//	}

}
