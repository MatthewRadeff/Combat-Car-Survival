using UnityEngine;
using System.Collections;

public class lavaBall : MonoBehaviour
{
	// lifespan of the lava ball.
	public float lifeSpan = 13;
	
	//start the timer
	void Start () 
	{
		StartCoroutine(DestroyAfterDelay(this.lifeSpan));
	}
	
	private IEnumerator DestroyAfterDelay (float delay)
	{
		yield return new WaitForSeconds(delay);
		UnityEngine.Object.Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag ("endpoint") || other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}

	}



}
