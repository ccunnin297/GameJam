using UnityEngine;
using System.Collections;

public abstract class Enemy : Character {
	
	protected override void Update()
	{
		UpdateBehavior();
		base.Update();
	}
	
	protected virtual void Destroy()
	{
		Destroy(gameObject);
	}
	
	protected abstract void UpdateBehavior();
}
