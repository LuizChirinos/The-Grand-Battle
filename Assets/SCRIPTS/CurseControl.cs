using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseControl : MonoBehaviour {

	public bool colidiu;
	public SpawnEnemies[] spawnEnemies;
	public float ManaNeeded;

	void Update()
	{
		//Debug.Log (PlayerProgress.Mana);

		if (colidiu)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (PlayerProgress.Mana >= ManaNeeded)
				{
					this.gameObject.SetActive(false);
					for (int i = 0; i < spawnEnemies.Length; i++)
					{
						spawnEnemies[i].contTimeToSpawn -= 2f;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			colidiu = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
		{
			colidiu = false;
		}
	}

}
