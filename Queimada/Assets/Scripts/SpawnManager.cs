using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private GameObject[] enemy = new GameObject[5];
	[SerializeField]
	private GameObject[] powerUp = new GameObject[5];

	[SerializeField]
	private GameObject boss;
    
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(EnemySpawn());
		StartCoroutine(PowerUpSpawn());
		StartCoroutine(BossSpawn());
	}

	IEnumerator EnemySpawn()
	{
		
     	while (true)
		{
			int list = Random.Range(0, enemy.Length);
			Instantiate(enemy[list], new Vector3(Random.Range(-8.14f, 18.5f), 1f, -15f), Quaternion.identity);
			yield return new WaitForSeconds(2.5f);
		}

	}


	IEnumerator PowerUpSpawn()
	{
		
		while (true) 
		{
			int list = Random.Range(0, powerUp.Length);
			Instantiate(powerUp[list], new Vector3(Random.Range(1.24f, 5f), 1.52f, -7.65f), Quaternion.identity);
			yield return new WaitForSeconds(5f);
		}
	}
	IEnumerator BossSpawn()
	{

		while (true)
		{
			yield return new WaitForSeconds(120f);
			Instantiate(boss, new Vector3(Random.Range(1.24f, 5f), 1.52f, -7.65f), Quaternion.identity);
		}
	}
}
