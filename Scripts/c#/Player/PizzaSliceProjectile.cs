using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PizzaSliceProjectile : MonoBehaviour 
{
	public TurretDeath script;

	// speed of the pizza
	public float speed = 1;
	
	// lifespan of the pizza....3seconds
	public float lifeSpan = 0.5f;

	[SerializeField] private bool limitsToOneBullet = true;




	//start the timer
	void Start () 
	{
		script = GameObject.Find("Canvas").transform.FindChild("turretamount").GetComponent<TurretDeath>();
		StartCoroutine(DestroyAfterDelay(this.lifeSpan));

	}
	
	private IEnumerator DestroyAfterDelay (float delay)
	{
		yield return new WaitForSeconds(delay);
		UnityEngine.Object.Destroy(this.gameObject);
	}
	
	void Update ()
	{
		speed++;
		//move projectile in forward direction
		this.transform.Translate(0,0,this.speed);
	}



	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag ("enemy") && limitsToOneBullet)
		{
			limitsToOneBullet = false;
			script.DecreamentTurretCount();
			Destroy(other.gameObject);
			Destroy(this.gameObject);


	
		}
		else
		{
			limitsToOneBullet = true;
		}


		if(other.gameObject.CompareTag ("environment"))
		{
			Destroy(this.gameObject);
		}

		if(other.gameObject.CompareTag("lavaball"))
		{
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}

	}









}
