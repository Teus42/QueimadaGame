using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> enemy = new List<GameObject>();
	[SerializeField]
	private List<GameObject> powerUp = new List<GameObject>();
	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(EnemySpawn());
		StartCoroutine(PowerUpSpawn());
	}

	IEnumerator EnemySpawn()
	{
		int list = 0;
		while (true)
		{
			Instantiate(enemy[list], new Vector3(Random.Range(-6, 5), 1.95f, 2.75f), Quaternion.identity);
			yield return new WaitForSeconds(3);
		}

	}


	IEnumerator PowerUpSpawn()
	{
		int list = 0;
		while (true) 
		{ 
		Instantiate(powerUp[list], new Vector3(Random.Range(1.24f, 5f), 1.52f, -7.65f), Quaternion.identity);
		yield return new WaitForSeconds(3);
		}
	}

}
