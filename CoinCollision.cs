using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CoinCollision : NetworkBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		var hit = collision.gameObject;
		var textUpdate = hit.GetComponent<TextUpdate>();



		if (hit.CompareTag ("Player")){
			Debug.Log("hit coin");
			textUpdate.GainCoins(1);
			Destroy(gameObject);

			CoinRespawn ();
			
		}
//

		//Respawn intantiate

	}

	public GameObject RespawnCoin;

		//[Command]
		void CoinRespawn(){
			var spawnPosition = new Vector3(
				Random.Range(-6f, 6f),
				Random.Range(1f, 6f),
				0f);

			var spawnRotation = Quaternion.Euler( 
				0.0f, 
				0.0f, 
				0.0f);
	
			var coin = (GameObject)Instantiate(RespawnCoin, spawnPosition, spawnRotation);
			NetworkServer.Spawn(coin);
		}
}
