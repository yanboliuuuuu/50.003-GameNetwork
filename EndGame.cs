using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour{

	[SerializeField] private string EndGameScene;

	public void EndButton(){
		SceneManager.LoadScene (EndGameScene);
	}



}
