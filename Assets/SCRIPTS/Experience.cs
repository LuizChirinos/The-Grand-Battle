using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {

    public float xpEarned;
    public float manaEarned;
	public float hpEarned;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerProgress.XP += xpEarned;
            PlayerProgress.Mana += manaEarned;
			PlayerProgress.HP += hpEarned;
            Destroy(this.gameObject);
        }
    }

}
