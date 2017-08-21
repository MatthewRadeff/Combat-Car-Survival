using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HoverScript : MonoBehaviour 
{

	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;

	private float powerInput;
	private float turnInput;
	private Rigidbody carRigidbody;

	// pizza prefab
	public GameObject pizzaSlicePrefab = null;
	// pizza bullet spawn
	public GameObject pizzaSliceSpawner = null;

	private AudioSource shootingGunClip;

	public AudioClip gunClip;




	void Awake () 
	{
		carRigidbody = GetComponent <Rigidbody>();
		shootingGunClip = GetComponent<AudioSource>();
	}






	void Update () 
	{

		powerInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
		CheckInput();
	}


	void FixedUpdate()
	{
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}
		carRigidbody.AddRelativeForce(0f,0f,powerInput * speed);
		carRigidbody.AddRelativeTorque(0f,turnInput * turnSpeed,0f);


	}



	void CheckInput()
	{
		Fire();
	}

	void Fire()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//create projectile
			GameObject projectile = Instantiate(this.pizzaSlicePrefab) as GameObject;
			//set the projectiles position to the spawner GLOBAL position
			projectile.transform.position = this.pizzaSliceSpawner.transform.position;
			//set the projectile rotation to match the spawner GLOBAL rotation so it goes,
			// in the z "forward" direction
			projectile.transform.rotation = this.pizzaSliceSpawner.transform.rotation;

			shootingGunClip.PlayOneShot(gunClip, 1f);

		

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag ("DeathTrap"))
		{
			// disable script when you die
			this.enabled = false;
			// go to game over screen
			Application.LoadLevel("GameOver");
		}

	}






}
