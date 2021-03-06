using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SpriteBehaviour : NetworkBehaviour {
	public Rigidbody2D rb;
	public Animator anim;

	public float XSpeed;
	public float YSpeed;
	public float dashDuration;
	public float dashStatus = 0;
	public float jumpStatus;
	public int directionStatus;
	public int facingStatus;
	public bool facingRight;
	public int Score = 0;	
//	public GameObject spikecoin;
//	public GameObject coin;
	public GameObject placeholder;


//	public int points = 0;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
//		spikecoin = new GameObject ();
//		coin = new GameObject();
		anim = GetComponent<Animator> ();
		facingRight = true;
	}

	void Update () {
		rb.freezeRotation = true;

		if (!isLocalPlayer) {
			GetComponentInChildren<Canvas> ().enabled = false;
			//GameObject holder; 
			//placeholder = localpla.FindGameObjectsWithTag ("placeholder");
			placeholder.GetComponent<SpriteRenderer> ().material.color = Color.yellow;

//			CmdSetCountText ();

			return;
		}
		if (isLocalPlayer) {
			GetComponentInChildren<Canvas> ().enabled = true;
//			CmdSetCountText ();
		}
	}

	void FixedUpdate(){
//		SpikeCoinRespawn.transform.Rotate (0, 60f * Time.deltaTime, 0, Space.World);		// give small issue
//		CoinRespawn.transform.Rotate (0, 60f * Time.deltaTime, 0, Space.World);			// give small issue

		AnimPlayer (facingStatus);
		Flip ();

		if (dashDuration > 0.07 && dashStatus == 1){
			dashDuration = 0;
			dashStatus = 0;
			SetVelocityZero ();
		}
		if (dashStatus == 1) {
			dashDuration += Time.deltaTime;
		}

		if (rb.velocity.y == 0 && jumpStatus == 1) {
			rb.velocity = new Vector2 (rb.velocity.x, YSpeed);
			jumpStatus = 0;
		}

		rb.velocity = new Vector2 (XSpeed, rb.velocity.y);
	}

	void AnimPlayer(float playerSpeed){
		if (playerSpeed == 0 && rb.velocity.y == 0) {
			anim.SetFloat ("Speed", 0);
			anim.SetFloat ("NoJump", 1);
		}
		if (playerSpeed != 0 && rb.velocity.y == 0) {
			anim.SetFloat ("Speed", 1);
			anim.SetFloat ("NoJump", 1);
		}
		if (rb.velocity.y > 0) {
			anim.SetFloat ("Jump", 1);
			anim.SetFloat ("NoJump", 0);

		}
		if (rb.velocity.y < 0) {
			anim.SetFloat ("Jump", 0);
		}
	}

	public void Flip(){
		if (!facingRight && XSpeed > 0 || facingRight && XSpeed < 0){
			facingRight = !facingRight;

			Vector3 temp = transform.localScale;
			temp.x *= -1;
			transform.localScale = temp;
		}
	}

	public void MoveLeft(){
		XSpeed = -5f;
		YSpeed = 0;
		directionStatus = -1;
		facingStatus = -1;
	}

	public void MoveRight(){
		XSpeed = 5f;
		YSpeed = 0;
		directionStatus = 1;
		facingStatus = 1;
	}

	public void SetVelocityZero(){
		XSpeed = 0;
		YSpeed = 0;
		facingStatus = 0;
	}

	public void Dash(){
		if (dashStatus == 1) {
			dashStatus = 0;
		}

		if (directionStatus == 1 && dashStatus == 0) {
			directionStatus = 0;
			XSpeed = 5f * 6;
			dashStatus = 1;
			dashDuration += Time.deltaTime;
		}
		else if (directionStatus == -1 && dashStatus == 0) {
			directionStatus= 0;
			XSpeed = -5f * 6;
			dashStatus = 1;
			dashDuration += Time.deltaTime;
		}
	}

	public void Jump(){
		if (jumpStatus == 0){
			YSpeed = 15;
			jumpStatus = 1;
		}
	}

	//[SyncVar(hook = "SetCountText")]
	public Text CoinCount;
	[SerializeField] private string gameEnd;


//	void SetCountText(){
//		CoinCount.text = "   Coins: " + Score.ToString ();
//	}

	void OnCollisionEnter2D(Collision2D collision ){

		var hit = collision.gameObject;
		if (hit.CompareTag ("Platform")) {
			TouchPlatform ();
		}
		if (hit.CompareTag ("coin")) {
//			Debug.Log (hit.gameObject);
			CmdSetCountText ();
			CmdRespawnCoin ();
			CmdDestroy (hit.gameObject);
		}

		if (hit.CompareTag ("Spike") && Score > 0) {

			CmdSetSpikeText ();//-2
			CmdRespawnSpikeCoin ();//hit spike release special coin worht 2 points
			CmdDestroy (hit.gameObject);
			
		}

		if (hit.CompareTag ("spikecoin")) {

			CmdSetSpikeCoinText ();//collect special spike coin: +2 points
			//CmdRespawnSpikeCoin ();
			CmdDestroy (hit.gameObject);

		}

	}


	public GameObject CoinRespawn;
	public GameObject SpikeCoinRespawn;

	[Command]
	void CmdRespawnCoin(){
		var spawnPosition = new Vector3(
			Random.Range(-6f, 6f),
			Random.Range(1f, 6f),
			0f);

		var spawnRotation = Quaternion.Euler( 
			0.0f, 
			0.0f, 
			0.0f);


		var coin = InstantiateCoin (CoinRespawn, spawnPosition, spawnRotation);
		//var coin = (GameObject)Instantiate(CoinRespawn, spawnPosition, spawnRotation);
		NetworkServer.Spawn(coin);
	}

	[Command]
	void CmdRespawnSpikeCoin (){
		var spikespawnPosition = new Vector3(
			Random.Range(-6f, 6f),
			Random.Range(1f, 6f),
			0f);

		var spikespawnRotation = Quaternion.Euler( 
			0.0f, 
			0.0f, 
			0.0f);

		var spikecoin = InstantiateSpikeCoin (SpikeCoinRespawn, spikespawnPosition, spikespawnRotation);
		//var coin = (GameObject)Instantiate(CoinRespawn, spawnPosition, spawnRotation);
		NetworkServer.Spawn(spikecoin);
	}

	public GameObject InstantiateCoin (GameObject coinRespawn, Vector3 spawnPosition, Quaternion spawnRotation){
		var coin = (GameObject)Instantiate(coinRespawn, spawnPosition, spawnRotation);
		return coin;
	}

	public GameObject InstantiateSpikeCoin (GameObject SpikeCoinRespawn, Vector3 spikespawnPosition, Quaternion spikespawnRotation){
		var spcoin = (GameObject)Instantiate(SpikeCoinRespawn, spikespawnPosition, spikespawnRotation);
		return spcoin;
	}



	[Command]
	void CmdSetCountText(){
		var textUpdate = this.gameObject.GetComponent<TextUpdate> ();

		CoinScoreUpdate ();
		textUpdate.Score = Score;
	}

	[Command]
	void CmdSetSpikeText(){
		var textUpdate = this.gameObject.GetComponent<TextUpdate> ();

		SpikePointUpdate ();
		textUpdate.Score = Score;
	}

	[Command]
	void CmdSetSpikeCoinText(){
		var textUpdate = this.gameObject.GetComponent<TextUpdate> ();

		SpikeCoinScoreUpdate ();
		textUpdate.Score = Score;
	}

	public void CoinScoreUpdate(){
		Score = Score + 1;
		if (Score >= 20) {
			SceneManager.LoadScene (gameEnd);
		}
	}

	public void SpikeCoinScoreUpdate(){
		Score = Score + 2;
		if (Score >= 20) {
			SceneManager.LoadScene (gameEnd);
		}
	}


	public void SpikePointUpdate(){
		
		if (Score < 2) {
			Score = 0;
		} 
		else {
			Score = Score - 2;
		}
		if (Score >= 20) {
			SceneManager.LoadScene (gameEnd);
		}
	}

	public void TouchPlatform(){
		jumpStatus = 0;
	}

	[Command]
	void CmdDestroy(GameObject obj){
		NetworkServer.Destroy (obj);	
	}
		
	public IEnumerator Knockback(float kbDuration,float kbPower,Vector3 kbDirection){
		float timer = 0;

		while (kbDuration > timer) {
			timer += Time.deltaTime;
			rb.AddForce (new Vector3 (kbDirection.x * -150, kbDirection.y * kbPower, transform.position.z));
		}
		yield return 0;
	}
		
}
	



