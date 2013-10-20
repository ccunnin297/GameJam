using UnityEngine;
using System.Collections;

public abstract class Projectile : MonoBehaviour
{
	Vector3 velocity;
	Vector3 direction;
	
	protected string type;
	
	protected float speed;
	
	// Update is called once per frame
	void Update()
	{
		gameObject.transform.Translate(velocity);
	}
	
	void OnCollisionEnter(Collision coll)
	{
		coll.gameObject.SendMessageUpwards("OnBulletHit", type, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
		
	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	
	void SetDirection(Vector3 dir)
	{
		direction = dir;
		velocity = speed * direction;
	}
}

