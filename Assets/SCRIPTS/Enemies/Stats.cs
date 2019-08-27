using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Create Characters/New Character")]
public class Stats : ScriptableObject {

	public new string name = "New Character";
	public int life;
	public int defense;
	public int mana;
}
