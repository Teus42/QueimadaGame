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
			Instantiate(enemy[list], new Vector3(Random.Range(-5.3f, 10.96f), 1f, 14.44f), Quaternion.identity);
			yield return new WaitForSeconds(2.5f);
		}

	}


	IEnumerator PowerUpSpawn()
	{
		
		while (true) 
		{
			int list = Random.Range(0, powerUp.Length);
			Instantiate(powerUp[list], new Vector3(Random.Range(-5.07f, 17.99f), 1.52f, Random.Range(-31.51f, 13.56f)), Quaternion.identity);
			yield return new WaitForSeconds(10f);
		}
	}
	IEnumerator BossSpawn()
	{

		while (true)
		{
			yield return new WaitForSeconds(120f);
			Instantiate(boss, new Vector3(Random.Range(-5.3f, 10.96f), 1f, 14.44f), Quaternion.identity);
		}
	}
}
