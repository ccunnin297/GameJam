using UnityEngine;
using System.Collections;

public abstract class Enemy : Character {
	
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
