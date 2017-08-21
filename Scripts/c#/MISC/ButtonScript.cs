using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour 
{
	public void ChangeScene(string sceneName)
	{
		Application.LoadLevel(sceneName);
	}

}
