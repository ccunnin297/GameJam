using UnityEngine;
using System.Collections;

public class Player : Character {
	
	const float BASE_MOVE_SPEED = 10.0f;
	const float BASE_JUMP_SPEED = 20.0f;
	const float GRAVITY = 35.0f;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		moveSpeed = BASE_MOVE_SPEED;
		jumpSpeed = BASE_JUMP_SPEED;
		gravity = GRAVITY;
	}
	
	// Update is called once per frame
	protected override void Update()
	{
		AcceptInput();
		UpdateCamera();
		base.Update();
	}
	
	void AcceptInput()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
			MoveLeft();
		if(Input.GetKey(KeyCode.RightArrow))
			MoveRight();
		if(Input.GetKeyDown(KeyCode.Space))
			Jump();
		if(Input.GetKeyDown(KeyCode.F))
			Shoot();
	}
	
	void UpdateCamera()
	{
		//GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
		//cam.transform.Translate(velocity.x, 0, 0);
	}
}
