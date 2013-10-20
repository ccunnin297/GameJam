using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	public GameObject projectile;
	
	protected float moveSpeed;
	protected float jumpSpeed;
	protected float gravity;
	
	protected Vector3 direction;
	protected Vector3 velocity;
	
	bool jump;
	bool left;
	bool right;
	
	CharacterController controller;
	
	// Use this for initialization
	protected virtual void Start()
	{
		velocity = Vector3.zero;
		direction = new Vector3(1, 0, 0);
		controller = (CharacterController)gameObject.GetComponent("CharacterController");
	}
	
	// Update is called once per frame
	protected virtual void Update()
	{
		if(left && !right)
		{
			velocity.x = -moveSpeed;
			direction.x = -1;
		}
		else if(!left && right)
		{
			velocity.x = moveSpeed;
			direction.x = 1;
		}
		else
			velocity.x = 0;
		
		left = false;
		right = false;
		
		if(controller.isGrounded && jump)
		{			
			velocity.y = jumpSpeed;
			jump = false;
		}
		
		velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
	}
	
	protected void MoveLeft()
	{
		left = true;
	}
	
	protected void MoveRight()
	{
		right = true;
	}
	
	protected void Jump()
	{
		jump = true;
	}
	
	protected void Shoot()
	{
		//spawn a projectile with a velocity
		Vector3 position = gameObject.transform.position;
		if(direction.x == 1)
			position.x += 1.0f;
		else if(direction.x == -1)
			position.x -= 1.0f;
		GameObject projectileClone = (GameObject)Instantiate(projectile, position, gameObject.transform.rotation);
		projectileClone.SendMessage("SetDirection", direction);
	}
}
