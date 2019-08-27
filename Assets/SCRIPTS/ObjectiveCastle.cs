using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveCastle : MonoBehaviour {

	public static int numberOfCastles;
	public static int castlesDetroyed;

	public GameObject panelWin;

	void Start()
	{
		castlesDetroyed = 0;
		numberOfCastles = 3;
	}

	void Update()
	{
		if (castlesDetroyed >= numberOfCastles) {
			Time.timeScale = 0f;
			panelWin.SetActive (true);
		}
	}
}
