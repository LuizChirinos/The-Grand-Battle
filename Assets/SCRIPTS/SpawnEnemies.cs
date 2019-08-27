using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SpawnEnemies : MonoBehaviour {

	public Transform spawnpoint;
	public GameObject[] enemy;
	public float contSpawn;
	public float contTimeToSpawn;

	// Update is called once per frame
	void Update () {
		contSpawn += Time.deltaTime;

		if (contSpawn > contTimeToSpawn)
		{
			contSpawn = 0f;
            int sorteio = (int)Random.Range(0f, enemy.Length);
			Instantiate (enemy[sorteio], spawnpoint.position, Quaternion.identity);
		}
	}
}
