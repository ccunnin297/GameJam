using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	public GameObject projectile;
	public int hitpoints;
	public float moveSpeed;
	public float jumpSpeed;
	public float gravity;
	public int flashDuration;
	public int flashes;
	public int shootCooldown;
	public int shootSpawnDistance;
	public int invDuration;
	
	protected Vector3 direction;
	protected Vector3 velocity;
	
	protected bool invulnerable;
	
	int flashCounter;
	int flashesCounter;
	bool flashing;
	
	int invCounter;
	
	int shootCounter;
	bool jumping;
	bool falling;
	
	bool jump;
	bool left;
	bool right;
	bool up;
	bool down;
	bool aimingUp;
	
	protected CharacterController controller;
	
	// Use this for initialization
	protected virtual void Start()
	{
		velocity = Vector3.zero;
		direction = new Vector3(1, 0, 0);
		controller = (CharacterController)gameObject.GetComponent("CharacterController");
		flashCounter = 0;
		flashesCounter = 0;
		shootCounter = shootCooldown;
		invulnerable = false;
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
		
		if(up && !down)
		{
			velocity.y = moveSpeed;
		}
		else if(!up && down)
		{
			velocity.y = -moveSpeed;
		}
		else if(gravity == 0)
			velocity.y = 0;
		else
		{
			if(controller.isGrounded && jump && !jumping)
			{			
				velocity.y = jumpSpeed;
				jump = false;
				jumping = true;
			}
			else if(jumping && controller.isGrounded)
			{
				jumping = false;
			}
			else if(jumping)
			{
				if((controller.collisionFlags & CollisionFlags.CollidedAbove) != 0)
					velocity.y = 0;
			}
			
			if(!jumping && !falling && !controller.isGrounded)
			{
				falling = true;
				velocity.y = 0;
			}
			else if(falling && controller.isGrounded)
			{
				falling = false;
			}
		}
		
		left = false;
		right = false;
		up = false;
		down = false;
		
		if(falling || jumping)
			velocity.y -= gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		
		if(flashing)
		{
			MeshRenderer ren = (MeshRenderer)GetComponent("MeshRenderer");
			if(flashCounter < flashDuration)
			{
				flashCounter++;
			}
			else
			{
				ren.enabled = !ren.enabled;
				if(flashesCounter < flashes)
				{
					flashesCounter++;
				}
				else
				{
					flashesCounter = 0;
					flashing = false;
					ren.enabled = true;
				}
				flashCounter = 0;
			}
		}
		
		if(invulnerable)
		{
			if(invCounter < invDuration)
			{
				invCounter++;	
			}
			else
			{
				invCounter = 0;
				invulnerable = false;
			}
		}
		
		if(hitpoints <= 0)
			Die();
		
		if(shootCounter < shootCooldown)
			shootCounter++;
		aimingUp = false;
	}
	
	protected void MoveLeft()
	{
		left = true;
	}
	
	protected void MoveRight()
	{
		right = true;
	}
	
	protected void MoveUp()
	{
		up = true;
	}
	
	protected void MoveDown()
	{
		down = true;
	}
	
	protected void Jump()
	{
		if(!jumping)
			jump = true;
	}
	
	protected void AimUp()
	{
		aimingUp = true;
	}
	
	protected void Shoot()
	{
		if(shootCounter < shootCooldown)
			return;
		shootCounter = 0;
		
		//spawn a projectile with a velocity
		Vector3 position = gameObject.transform.position;
		if(aimingUp)
		{
			position.y += shootSpawnDistance;
			GameObject projectileClone = (GameObject)Instantiate(projectile, position, gameObject.transform.rotation);
			projectileClone.SendMessage("SetDirection", new Vector3(0, 1, 0), SendMessageOptions.DontRequireReceiver);
		}
		else 
		{
			if(direction.x == 1)
				position.x += shootSpawnDistance;
			else
				position.x -= shootSpawnDistance;
			GameObject projectileClone = (GameObject)Instantiate(projectile, position, gameObject.transform.rotation);
			projectileClone.SendMessage("SetDirection", direction, SendMessageOptions.DontRequireReceiver);
		}
	}
	
	//Flash to indicate damage
	protected void Flash()
	{
		flashing = true;
	}
	
	protected void Invulnerable()
	{
		invulnerable = true;
	}
	
	protected void OnBulletHit(string type)
	{
		Invulnerable();
		Flash();
		hitpoints--;
	}
	
	protected abstract void Die();
}
