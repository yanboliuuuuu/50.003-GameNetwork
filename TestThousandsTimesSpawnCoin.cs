using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestThousandsTimesSpawnCoin : MonoBehaviour {

	SpriteBehaviour subject;

	[SetUp]
	public void SetUp(){
		subject = new SpriteBehaviour ();
	}

	// SILVER COIN
	[Test]
	public void SpawnSilverCoinDifferentDesiredLocationFor10000TimesTest(){
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;

		for (int i = 0; i < 10000; i++) {
			Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
			var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

			Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
			Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
			Assert.IsTrue (coin.transform.position.z == 0f);
		}
	}


	// GOLD COIN
	[Test]
	public void SpawnGoldCoinDifferentDesiredLocationFor10000TimesTest(){
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;

		for (int i = 0; i < 10000; i++) {
			Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
			var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

			Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
			Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
			Assert.IsTrue (coin.transform.position.z == 0f);
		}
	}

}
