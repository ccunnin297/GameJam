using UnityEngine;
using System.Collections;

public class FlyingBacteria : Enemy
{
	public bool facingLeft;
	public float verticalRange;
	
	bool chasing;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		chasing = false;
	}
	
	protected override void UpdateBehavior()
	{
		if(!chasing)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if(player == null)
				return;
			if(Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) < verticalRange)
			{
				chasing = true;
			}
		}
		else
		{
			if(facingLeft)
				MoveLeft();
			else
				MoveRight();
		}
	}
}

