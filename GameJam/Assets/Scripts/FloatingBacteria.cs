using UnityEngine;
using System.Collections;

public class FloatingBacteria : Enemy
{
	public float moveDistance;
	public int randomDuration;
	
	Vector3 initPosition;
	int dir;
	
	int randomCounter;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		
		initPosition = gameObject.transform.position;
		randomCounter = 0;
		dir = 0;
	}
	
	protected override void UpdateBehavior()
	{
		if(randomCounter < randomDuration)
		{
			randomCounter++;
			
			switch(dir)
			{
				case 0:
					if(gameObject.transform.position.x < initPosition.x - moveDistance)
					{
						dir = Random.Range(0, 2);
						if(dir == 0)
							dir = 3;
					}
					else
						MoveLeft();
					break;
				case 1:
					if(gameObject.transform.position.x > initPosition.x + moveDistance)
					{
						dir = Random.Range(0, 2);
						if(dir == 1)
							dir = 3;
					}
					else
						MoveRight();
					break;
				case 2:
					if(gameObject.transform.position.y > initPosition.y + moveDistance)
					{
						dir = Random.Range(0, 2);
						if(dir == 2)
							dir = 3;
					}
					else
						MoveUp();
					break;
				case 3:
					if(gameObject.transform.position.y < initPosition.y - moveDistance)
						dir = Random.Range(0, 2);
					else
						MoveDown();
					break;
			}
		}
		else
		{
			randomCounter = 0;
			dir = Random.Range(0, 3);
		}
	}
}

