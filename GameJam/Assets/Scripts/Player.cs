using UnityEngine;
using System.Collections;

public class Player : Character {
		
	public int damageInvDuration;
	
	// Use this for initialization
	protected override void Start()
	{
		base.Start();
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
		if(Input.GetKey(KeyCode.UpArrow))
			AimUp();
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
	
	protected override void OnBulletHit(string type)
	{
		switch(type)
		{
			case "Test":
				hitpoints--;
				break;
		} 
	}
	
	protected void HitEnemy()
	{
		hitpoints--;
		Invulnerable(damageInvDuration);
		Flash();
	}
	
	protected override void Die()
	{
		Destroy(gameObject);
	}
}
