using UnityEngine;
using System.Collections;

public class triggerbarrier : MonoBehaviour
{

	public GameObject barrier;


	void OnTriggerStay(Collider other) 
	{
		if(Input.GetKey("e"))
		{
			Destroy(barrier);
		}
	}
}
