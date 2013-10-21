using UnityEngine;
using System.Collections;

public abstract class Enemy : Character {
	
	protected override void Start()
	{
		base.Start();
		gameObject.tag = "Enemy";
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			if(enemy != gameObject)
				Physics.IgnoreCollision(enemy.collider, controller.collider);
		}	
	}
	
	protected override void Update()
	{
		UpdateBehavior();
		base.Update();
	}
	
	protected abstract void UpdateBehavior();
	
	protected override void Die()
	{
		Destroy(gameObject);
	}
	
	protected void OnBecameVisible()
	{
		enabled = true;
	}
}
