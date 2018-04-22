using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestCoin{

	SpriteBehaviour subject;

	[SetUp]
	public void SetUp(){
		subject = new SpriteBehaviour ();
	}

	// SILVER COIN
	[Test]
	public void SpawnSilverCoinTest(){
		Vector3 spawnPosition = new Vector3(0, 0, -1);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.AreEqual (spawnPosition, coin.transform.position);
	}


	[Test]
	public void SpawnSilverCoinDesiredLocationTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsTrue (coin.transform.position.z == 0f);

	}

	[Test]
	public void SpawnSilverCoinDesiredUprightPositionTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsTrue (coin.transform.rotation.x == 0f);
		Assert.IsTrue (coin.transform.rotation.y == 0f);
		Assert.IsTrue (coin.transform.rotation.z == 0f);
	}

	[Test]
	public void SpawnSilverCoinUnDesiredUprightPositionTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (1, 1, 1);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.rotation.x == 0f);
		Assert.IsFalse (coin.transform.rotation.y == 0f);
		Assert.IsFalse (coin.transform.rotation.z == 0f);
	}

//	[Test]
//	public void SpawnSilverCoinDifferentDesiredLocationFor10000TimesTest(){
//		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
//		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
//
//		for (int i = 0; i < 10000; i++) {
//			Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
//			var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);
//
//			Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
//			Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
//			Assert.IsTrue (coin.transform.position.z == 0f);
//		}
//	}


	[Test]
	public void SpawnSilverCoinUndesiredLocationTest1(){
		Vector3 spawnPosition = new Vector3(-7f, 0f, 1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnSilverCoinUndesiredLocationTest2(){
		Vector3 spawnPosition = new Vector3(7f, 7f, -1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnSilverCoinUndesiredLocationTest3(){
		Vector3 spawnPosition = new Vector3(-7f, 7f, -1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnSilverCoinUndesiredLocationTest4(){
		Vector3 spawnPosition = new Vector3(7f, 0f, 1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Normal Coin") as GameObject;
		var coin = subject.InstantiateCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	// GOLD COIN
	[Test]
	public void SpawnGoldCoinTest(){
		Vector3 spawnPosition = new Vector3(0, 0, -1);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.AreEqual (spawnPosition, coin.transform.position);
	}


	[Test]
	public void SpawnGoldCoinDesiredLocationTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsTrue (coin.transform.position.z == 0f);

	}

	[Test]
	public void SpawnGoldCoinDesiredUprightPositionTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsTrue (coin.transform.rotation.x == 0f);
		Assert.IsTrue (coin.transform.rotation.y == 0f);
		Assert.IsTrue (coin.transform.rotation.z == 0f);
	}

	[Test]
	public void SpawnGoldCoinUnDesiredUprightPositionTest(){
		Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
		Quaternion spawnRotation = Quaternion.Euler (1, 1, 1);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.rotation.x == 0f);
		Assert.IsFalse (coin.transform.rotation.y == 0f);
		Assert.IsFalse (coin.transform.rotation.z == 0f);
	}



//	[Test]
//	public void SpawnGoldCoinDifferentDesiredLocationFor10000TimesTest(){
//		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
//		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
//
//		for (int i = 0; i < 10000; i++) {
//			Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(1f, 6f), 0f);
//			var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);
//
//			Assert.IsTrue (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
//			Assert.IsTrue (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
//			Assert.IsTrue (coin.transform.position.z == 0f);
//		}
//	}


	[Test]
	public void SpawnGoldCoinUndesiredLocationTest1(){
		Vector3 spawnPosition = new Vector3(-7f, 0f, -1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnGoldCoinUndesiredLocationTest2(){
		Vector3 spawnPosition = new Vector3(7f, 7, -1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnGoldCoinUndesiredLocationTest3(){
		Vector3 spawnPosition = new Vector3(-7f, 7f, 1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}


	[Test]
	public void SpawnGoldCoinUndesiredLocationTest4(){
		Vector3 spawnPosition = new Vector3(7f, 0f, 1f);
		Quaternion spawnRotation = Quaternion.Euler (0, 0, 0);
		var coinPrefab = Resources.Load ("Spike Coin") as GameObject;
		var coin = subject.InstantiateSpikeCoin (coinPrefab, spawnPosition, spawnRotation);

		Assert.IsFalse (coin.transform.position.x >= -6f && coin.transform.position.x <= 6f);
		Assert.IsFalse (coin.transform.position.y >= 1f && coin.transform.position.y <= 6f);
		Assert.IsFalse (coin.transform.position.z == 0f);
	}

}
