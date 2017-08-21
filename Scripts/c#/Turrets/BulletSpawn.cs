using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour 
{

	public float bulletSpeed = 10f;

	void FixedUpdate() 
	{
		transform.Translate(0,0,bulletSpeed);
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("environment"))
		{
			Destroy(this.gameObject);
		}
	}

}
