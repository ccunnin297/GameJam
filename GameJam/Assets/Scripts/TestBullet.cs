using UnityEngine;
using System.Collections;

public class TestBullet : Projectile
{
	const float BULLET_SPEED = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		speed = BULLET_SPEED;	
	}
}

