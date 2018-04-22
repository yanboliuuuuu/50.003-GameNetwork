using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestScoreUpdate{

	SpriteBehaviour subject;

	[SetUp]
	public void SetUp(){
		subject = new SpriteBehaviour ();
	}

	// SCORE UPDATE
	[Test]
	public void ScoreSilverCoinUpdateTest(){
		subject.Score = 0;
		subject.CoinScoreUpdate ();
		Assert.IsTrue (subject.Score == 1);
	}

	//Check if it only +1 not +2
	[Test]
	public void ScoreSilverCoinUpdateErrorTest1(){
		subject.Score = 0;
		subject.CoinScoreUpdate ();
		Assert.IsFalse (subject.Score == 2);
	}

	//Check if it only +1 not -1
	[Test]
	public void ScoreSilverCoinUpdateErrorTest2(){
		subject.Score = 0;
		subject.CoinScoreUpdate ();
		Assert.IsFalse (subject.Score == -1);
	}

	//Check if it only +1 not -2
	[Test]
	public void ScoreSilverCoinUpdateErrorTest3(){
		subject.Score = 0;
		subject.CoinScoreUpdate ();
		Assert.IsFalse (subject.Score == -2);
	}

	[Test]
	public void ScoreGoldCoinUpdateTest(){
		subject.Score = 0;
		subject.SpikeCoinScoreUpdate ();
		Assert.IsTrue (subject.Score == 2);
	}

	//Check if it only +2 not +1
	[Test]
	public void ScoreGoldCoinUpdateErrorTest1(){
		subject.Score = 0;
		subject.SpikeCoinScoreUpdate ();
		Assert.IsFalse (subject.Score == 1);
	}


	//Check if it only +2 not +3
	[Test]
	public void ScoreGoldCoinUpdateErrorTest2(){
		subject.Score = 0;
		subject.SpikeCoinScoreUpdate ();
		Assert.IsFalse (subject.Score == 3);
	}

	//Check if it only +2 not -2
	[Test]
	public void ScoreGoldCoinUpdateErrorTest3(){
		subject.Score = 0;
		subject.SpikeCoinScoreUpdate ();
		Assert.IsFalse (subject.Score == -2);
	}

	//Check if it only +2 not -1
	[Test]
	public void ScoreGoldCoinUpdateErrorTest4(){
		subject.Score = 0;
		subject.SpikeCoinScoreUpdate ();
		Assert.IsFalse (subject.Score == -1);
	}
		
}
