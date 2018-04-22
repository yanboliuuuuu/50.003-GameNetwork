using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestMovement{
	
	SpriteBehaviour subject;

	[SetUp]
	public void SetUp(){
		subject = new SpriteBehaviour ();
	}

	//	INTIAL PLAYER STATUS
	[Test]
	public void XSpeedTest() {
		Assert.IsTrue (subject.XSpeed >= 0);
	}

	[Test]
	public void YSpeedTest() {
		Assert.IsTrue (subject.YSpeed >= 0);
	}

	[Test]
	public void DashStatusTest() {
		Assert.IsTrue (subject.dashStatus == 0);
	}

	[Test]
	public void DirectionStatusTest() {
		Assert.IsTrue (subject.dashStatus == 0);
	}


	//	MOVE LEFT
	[Test]
	public void MoveLeftXSpeedTest() {
		//		var player = new GameObject ().AddComponent<SpriteBehaviour> ();

		subject.MoveLeft ();
		Assert.IsTrue (subject.XSpeed == -5);
	}

	[Test]
	public void MoveLeftDirectionStatusTest() {
		subject.MoveLeft ();
		Assert.IsTrue (subject.directionStatus == -1);
	}


	//	MOVE RIGHT
	[Test]
	public void MoveRightXSpeedTest() {
		subject.MoveRight ();
		Assert.IsTrue (subject.XSpeed == 5);
	}

	[Test]
	public void MoveRightDirectionStatusTest() {
		subject.MoveRight ();
		Assert.IsTrue (subject.directionStatus == 1);
	}


	//	NO MOVEMENT
	[Test]
	public void SetVelocityZeroTest() {
		subject.SetVelocityZero ();
		Assert.IsTrue (subject.XSpeed == 0);
	}


	//	DASH LEFT
	[Test]
	public void DashLeftXSpeedTest() {
		subject.MoveLeft ();
		subject.Dash ();
		Assert.IsTrue (subject.XSpeed == -30);
	}

	[Test]
	public void DashLeftDirectionStatusTest() {
		subject.MoveLeft ();
		subject.Dash ();
		Assert.IsTrue (subject.directionStatus == 0);
	}

	[Test]
	public void DashLeftStatusTest() {
		subject.dashDuration = 0;
		subject.MoveLeft ();
		subject.Dash ();
		Assert.IsTrue (subject.dashStatus == 1);
	}

	[Test]
	public void DashLeftDurationTest() {
		subject.MoveLeft ();
		subject.Dash ();
		Assert.IsTrue (subject.dashDuration <= 0.07);
	}



	//	DASH RIGHT
	[Test]
	public void DashRightXSpeedTest() {
		subject.MoveRight ();
		subject.Dash ();
		Assert.IsTrue (subject.XSpeed == 30);
	}

	[Test]
	public void DashRightDirectionStatusTest() {
		subject.MoveRight ();
		subject.Dash ();
		Assert.IsTrue (subject.directionStatus == 0);
	}

	[Test]
	public void DashRightStatusTest() {
		subject.MoveRight ();
		subject.Dash ();
		Assert.IsTrue (subject.dashStatus == 1);
	}

	[Test]
	public void DashRightDurationTest() {
		subject.dashDuration = 0;
		subject.MoveLeft ();
		subject.Dash ();
		Assert.IsTrue (subject.dashDuration <= 0.07);
	}


	//	DOUBLE DASH BUT CANNOT
	[Test]
	public void DashLeftTwiceButFailTest(){
		var player = new GameObject ().AddComponent<SpriteBehaviour> ();

		player.MoveLeft ();
		player.Dash ();
		player.Dash ();
		Assert.IsFalse (subject.dashStatus == 1);
	}

	[Test]
	public void DashRightTwiceButFailTest(){
		subject.MoveRight ();
		subject.Dash ();
		//yield return new WaitForSeconds (0.01f);
		//subject.MoveRight ();
		subject.Dash ();
		Assert.IsFalse (subject.dashStatus == 1);
	}

	// CANNOT DASH AS NO MOVEMENT BEFOREHAND
	[Test]
	public void DashFromIdlePositionTest(){
		subject.Dash ();
		Assert.IsFalse (subject.dashStatus == 1);
	}


	// DASH BRANCHES
	[Test]
	public void DashBranchTest(){
		subject.dashStatus = 0;
		subject.directionStatus = 0;
		subject.Dash ();
		Assert.IsFalse (subject.dashStatus == 1);

	}



	//	JUMP
	[Test]
	public void JumpVerticallyYSpeedTest(){
		subject.Jump ();
		Assert.IsTrue (subject.YSpeed == 15);
	}

	[Test]
	public void JumpBranchTest(){
		subject.jumpStatus = 1;
		subject.Jump ();
		Assert.IsFalse (subject.YSpeed == 15);
	}

	//	JUMP RIGHT
	[Test]
	public void JumpRightSpeedTest(){
		subject.MoveRight();
		subject.Jump ();
		Assert.IsTrue (subject.XSpeed == 5);
		Assert.IsTrue (subject.YSpeed == 15);
	}


	[Test]
	public void JumpDashRightTest(){
		subject.MoveRight();
		subject.Jump ();
		subject.Dash ();
		Assert.IsTrue (subject.XSpeed == 30);
		Assert.IsTrue (subject.YSpeed == 15);
	}

	//  JUMP LEFT
	[Test]
	public void JumpLeftSpeedTest(){
		subject.MoveLeft();
		subject.Jump ();
		Assert.IsTrue (subject.XSpeed == -5);
		Assert.IsTrue (subject.YSpeed == 15);
	}


	[Test]
	public void JumpDashLeftTest(){
		subject.MoveLeft();
		subject.Jump ();
		subject.Dash ();
		Assert.IsTrue (subject.XSpeed == -30);
		Assert.IsTrue (subject.YSpeed == 15);
	}

	//	JUMP but cannot
	[UnityTest]
	public IEnumerator AttemptToDoubleJumpButFail(){
		subject.Jump ();
		yield return new WaitForSeconds (0.01f);
		subject.Jump ();
		Assert.IsTrue (subject.jumpStatus == 1); //--> This means that it cannot perform double jump
	}

	//	JUMP but cannot
	[UnityTest]
	public IEnumerator AttemptToDoubleJumpFor100TimesButFail(){
		subject.Jump ();
		for(int i = 0; i < 100; i++){
			yield return new WaitForSeconds (0.01f);
			subject.Jump ();
			Assert.IsTrue (subject.jumpStatus == 1); //--> This means that it cannot perform double jump
		}
	}


	//	FLIP CHARACTER
	[Test]
	public void FlipLeftTest(){
		var player = new GameObject ().AddComponent<SpriteBehaviour> ();
		player.MoveLeft();
		player.facingRight = true;
		player.Flip ();
		Assert.IsTrue (player.transform.localScale.x < 0);
	}

	[Test]
	public void FlipRightTest(){
		var player = new GameObject ().AddComponent<SpriteBehaviour> ();
		player.MoveRight();
		player.facingRight = false;
		player.transform.localScale = new Vector3 (-1, 0, 0);
		player.Flip();
		Assert.IsTrue (player.transform.localScale.x > 0);
	}

	//Branch Testing
	[Test]
	public void FlipBranchTest1(){
		var player = new GameObject ().AddComponent<SpriteBehaviour> ();
		player.transform.localScale = new Vector3 (-1, 0, 0);
		player.MoveRight();
		player.facingRight = true;
		player.Flip();
		Assert.IsFalse (player.transform.localScale.x > 0);
	}

	[Test]
	public void FlipBranchTest2(){
		var player = new GameObject ().AddComponent<SpriteBehaviour> ();
		player.transform.localScale = new Vector3 (1, 0, 0);
		player.MoveLeft();
		player.facingRight = false;
		player.Flip();
		Assert.IsFalse (player.transform.localScale.x < 0);
	}


}
