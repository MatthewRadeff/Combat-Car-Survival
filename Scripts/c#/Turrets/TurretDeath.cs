using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TurretDeath : MonoBehaviour 
{
	Text numberOfTurrets;

	public int nmbrOfTurrets = 10;


	 void Start()
	{
		numberOfTurrets = this.gameObject.GetComponent<Text>();
		nmbrOfTurrets = 10;
	}
	


	public void DecreamentTurretCount()
	{
		nmbrOfTurrets -= 1;
		numberOfTurrets.text = nmbrOfTurrets.ToString();

		if(nmbrOfTurrets <= 0)
		{
			Application.LoadLevel("GameWin");
		}
	}



}
