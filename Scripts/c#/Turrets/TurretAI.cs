using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour 
{
	[SerializeField] private GameObject enemyProjectilePrefab = null;
	[SerializeField] private GameObject spawner = null;
	
	// seconds to spawn enemy
	[SerializeField] private float spawnSeconds = 1;
	
	[SerializeField] private bool limitsToOneBullet = true;
	
	//coroutine to spawn enemies at the given amount of seconds
	private IEnumerator SpawnEnemyBulletCoroutine()
	{
		while (true)
		{
			GameObject enemy = Instantiate(this.enemyProjectilePrefab) as GameObject;
			enemy.transform.position = this.spawner.transform.position;
			enemy.transform.rotation = this.spawner.transform.rotation;
			yield return new WaitForSeconds(this.spawnSeconds);
		}
	}



	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player") && limitsToOneBullet)
		{
			StartCoroutine(SpawnEnemyBulletCoroutine());
			limitsToOneBullet = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			StopAllCoroutines();
			limitsToOneBullet = true;
		}
	}





}

