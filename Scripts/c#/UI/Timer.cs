using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{

	public float myCoolTimer = 300;
	public Text timerText;

	// Use this for initialization
	void Start () 
	{
		timerText.GetComponent<Text>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		myCoolTimer -= Time.deltaTime;
		timerText.text = myCoolTimer.ToString("f0");

		if(myCoolTimer <= 0)
		{
			Application.LoadLevel("GameOver");
		}
	}
}
