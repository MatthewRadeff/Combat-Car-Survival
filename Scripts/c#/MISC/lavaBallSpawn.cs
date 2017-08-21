using UnityEngine;
using System.Collections;

public class lavaBallSpawn : MonoBehaviour 
{
	[SerializeField] private GameObject lavaBallPrefab = null;
	[SerializeField] private GameObject spawner = null;
	
	// seconds to spawn enemy
	[SerializeField] private float spawnSeconds = 2;
	
	void Awake()
	{
		StartCoroutine(SpawnLavaBallCoroutine());
	}
	
	//coroutine to spawn enemies at the given amount of seconds
	private IEnumerator SpawnLavaBallCoroutine()
	{
		while (true)
		{
			GameObject enemy = Instantiate(this.lavaBallPrefab) as GameObject;
			enemy.transform.position = this.spawner.transform.position;
			yield return new WaitForSeconds(this.spawnSeconds);
		}	
	}








}
