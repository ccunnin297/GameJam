using UnityEngine;
using System.Collections;

public class ShieldBacteria : Enemy
{
	public bool facingLeft;
	public int randomShotInterval;
	
	int randomShotCounter;
	bool movingUp;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		randomShotCounter = Random.Range(0, randomShotInterval);
		movingUp = true;
		direction.x = facingLeft ? -1 : 1;
	}
	
	protected override void UpdateBehavior()
	{
		if(movingUp)
		{
			if((controller.collisionFlags & CollisionFlags.CollidedAbove) != 0)
				movingUp = false;
			else
				MoveUp();
		}
		else
		{
			if((controller.collisionFlags & CollisionFlags.CollidedBelow) != 0)
				movingUp = true;
			else
				MoveDown();
		}
		
		if(randomShotCounter < randomShotInterval)
			randomShotCounter++;
		else
		{
			randomShotCounter = Random.Range(0, randomShotInterval);
			Shoot();
		}
		
	}
}

