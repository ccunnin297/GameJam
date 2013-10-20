using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Vector3 velocity;
	Vector3 direction;
	
	public string type;
	
	public float speed;
	
	// Update is called once per frame
	protected void Update()
	{
		gameObject.transform.Translate(velocity);
	}
	
	protected void OnTriggerEnter(Collider collider)
	{
		collider.gameObject.SendMessageUpwards("OnBulletHit", type, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
		
	protected void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
	
	protected void SetDirection(Vector3 dir)
	{
		direction = dir;
		velocity = speed * direction;
	}
}

