using UnityEngine;
using System.Collections;

public class TestEnemy : Enemy
{
	const float BASE_MOVE_SPEED = 10.0f;
	const float BASE_JUMP_SPEED = 20.0f;
	const float GRAVITY = 35.0f;
	
	const float MOVE_DISTANCE = 2.0f;
	float initX;
	
	bool movingRight;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		
		moveSpeed = BASE_MOVE_SPEED;
		jumpSpeed = BASE_JUMP_SPEED;
		gravity = GRAVITY;
		
		initX = gameObject.transform.position.x;
		movingRight = true;
	}
	
	protected override void UpdateBehavior()
	{
		//Move left and right
		if(Mathf.Abs(initX - gameObject.transform.position.x) < MOVE_DISTANCE)
		{
			if(movingRight)
				MoveRight();
			else
				MoveLeft();
		}
		else
		{
			initX = gameObject.transform.position.x;
			movingRight = !movingRight;
		}
	}
}

