using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextUpdate : NetworkBehaviour {


	[SyncVar(hook = "SetCountText")]
	public int Score = 0;
	public Text ScoreText;

	public void GainCoins(int amount)
	{
		if (!isServer)
		{
			return;
		}

		Score += amount;

	

	}

	public void SetCountText(int Score){
		ScoreText.text = "   Coins: " + Score.ToString ();
	}
}
