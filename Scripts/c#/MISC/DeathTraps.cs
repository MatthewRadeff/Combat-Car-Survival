using UnityEngine;
using System.Collections;

public class DeathTraps : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
			Destroy(other.gameObject);
	}

}
