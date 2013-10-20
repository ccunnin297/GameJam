using UnityEngine;
using System.Collections;

public class Virus : Enemy
{
	public float moveDistance;
	
	float initX;
	bool movingRight;
	bool start;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		
		initX = gameObject.transform.position.x;
		movingRight = true;
		start = true;
	}
	
	protected override void UpdateBehavior()
	{
		//Move left and right
		if(start && Mathf.Abs(initX - gameObject.transform.position.x) < moveDistance / 2
			|| Mathf.Abs(initX - gameObject.transform.position.x) < moveDistance)
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
	
	protected override void OnBulletHit(string type)
	{
		switch(type)
		{
			case "Test":
				hitpoints--;
				break;
		}
	}
}

