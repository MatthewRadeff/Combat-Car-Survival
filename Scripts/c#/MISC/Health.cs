using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
	Image healthBar;
	public float tmpHealth = 1f;

	private AudioSource hurtingPlayerClip;
	public AudioClip hurtingClip;

	private AudioSource fireBurningClip;
	public AudioClip burningClip;


	void Awake()
	{
		hurtingPlayerClip = GetComponent<AudioSource>();
		fireBurningClip = GetComponent<AudioSource>();
	}

	void Start()
	{
		healthBar = GameObject.Find("Canvas").transform.FindChild("healthbar").GetComponent<Image>();
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("lavalog"))
		{
			if(tmpHealth > 0 && (tmpHealth != 0 || tmpHealth < 0))
			{
				tmpHealth -= 0.001f;
				healthBar.fillAmount = tmpHealth;   
				fireBurningClip.PlayOneShot(burningClip, 1f);
			}
			else
			{
				Application.LoadLevel("GameOver");
			}
		}
		if(other.gameObject.CompareTag("lavaball") || other.gameObject.CompareTag("bullet"))
		{
			if(tmpHealth > 0 && (tmpHealth != 0 || tmpHealth < 0))
			{
				tmpHealth -= 0.01f;
				healthBar.fillAmount = tmpHealth;
				hurtingPlayerClip.PlayOneShot(hurtingClip, 1f);
			}
			else
			{
				Application.LoadLevel("GameOver");
			}
		}
	}




	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.CompareTag("lavalog"))
		{
			if(tmpHealth > 0 && (tmpHealth != 0 || tmpHealth < 0))
			{
				tmpHealth -= 0.001f;
				healthBar.fillAmount = tmpHealth; 
				//fireBurningClip.PlayOneShot(burningClip, 1f);
			}
			else
			{
				Application.LoadLevel("GameOver");
			}
		}

		if(other.gameObject.CompareTag("bullet") || other.gameObject.CompareTag("lavaball"))
		{
			if(tmpHealth > 0 && (tmpHealth != 0 || tmpHealth < 0))
			{
				tmpHealth -= 0.01f;
				healthBar.fillAmount = tmpHealth;
				hurtingPlayerClip.PlayOneShot(hurtingClip, 1f);
			}
			else
			{
				Application.LoadLevel("GameOver");
			}
		}
	}



	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("lavalog"))
		{
			fireBurningClip.Stop ();
		}
	}












}
