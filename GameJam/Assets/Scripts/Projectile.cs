using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	Vector3 velocity;
	Vector3 direction;
	
	public string type;	
	public float speed;
	public float range;
	
	Vector3 initPos;
	
	protected void Start()
	{
		initPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	protected void Update()
	{
		gameObject.transform.Translate(velocity);
		if(Vector3.Distance(gameObject.transform.position, initPos) > range)
		{
			Destroy(gameObject);
		}
	}
	
	protected void OnTriggerEnter(Collider collider)
	{
		collider.gameObject.SendMessageUpwards("OnBulletHit", type, SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
	
	protected void SetDirection(Vector3 dir)
	{
		direction = dir;
		velocity = speed * direction;
	}
}

