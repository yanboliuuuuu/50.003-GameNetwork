using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SpriteBehaviour : NetworkBehaviour {
	public Rigidbody2D rb;

	//public Transform groundCheck;
//	public float groundCheckRadius;
//	public LayerMask whatIsGround;

	//public bool haveStar = false;

	public float maxPos = 19f;
	Vector3 p;

	public Text StarCount;
	private int Score;
	//SpawnStar respawn;

	public float XSpeed = 0;
	public float YSpeed = 0;
	public float dashDuration = 0;
	public float dashStatus = 0;
	public float jumpStatus = 0;

	private int directionStatus = 0;



	void Start () {
		rb = GetComponent<Rigidbody2D> ();}
		
	void Update () {

		if (!isLocalPlayer) {
			GetComponentInChildren<Canvas> ().enabled = false;
			return;
		}
		if (isLocalPlayer) {
			GetComponent<SpriteRenderer>().material.color = Color.blue;
			GetComponentInChildren<Canvas> ().enabled = true;
		}

		//CmdSpawnStar ();
	
		p = transform.position;
		p.x = Mathf.Clamp (p.x, -10f, 10f);	//TO DO LIST: need to find the reference point

		transform.position = p;

		Vector3 namePos = Camera.main.WorldToScreenPoint (this.transform.position);
		StarCount.transform.position = namePos;
	}
		
	void FixedUpdate(){
			Debug.Log (dashDuration);

		if (dashDuration > 0.07 && dashStatus == 1){ 
			dashDuration = 0;
			dashStatus = 0;
			SetVelocityZero ();
		}

		if (dashStatus == 1) {
			Debug.Log ("HERE" + dashStatus);
			dashDuration += Time.deltaTime;
		}

		rb.velocity = new Vector2 (XSpeed, rb.velocity.y);
	}

	public void MoveLeft(){
		XSpeed = -5f;
		directionStatus = -1;
	}

	public void MoveRight(){
		XSpeed = 5f;
		directionStatus = 1;
		Debug.Log("RIght");
	}

	public void SetVelocityZero(){
		XSpeed = 0;
	}

	public void Dash(){
		Debug.Log ("DASH" + dashStatus);

		if (directionStatus == 1 && dashStatus == 0) {
			directionStatus = 0;
			XSpeed = 5f * 6;
			dashStatus = 1;

		}
		else if (directionStatus == -1 && dashStatus == 0) {
			directionStatus= 0;
			dashStatus = 1;

		}

		dashDuration += Time.deltaTime;
	}

	public void Jump(){
		if (rb.velocity.y == 0) {
			rb.velocity = new Vector2 (rb.velocity.x, 8);
		}
	}

	void OnCollisionEnter2D(Collision2D collision ){

		var hit = collision.gameObject;
		//var points = hit.GetComponent<StarCountPlaceHolderPosition> ();
		if (hit.CompareTag("Pick Up")){
			//points.CollectStar(1);
			Destroy(hit.gameObject);
			//respawn.OnStartServer ();

			Score = Score + 1;
			SetCountText ();
		}

	}
	void SetCountText(){
		StarCount.text = "Star Count: " + Score.ToString ();
	}

}
