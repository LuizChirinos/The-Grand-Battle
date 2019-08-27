using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float hp;
	public Slider HpBar;

	void Start()
	{
        if (HpBar == null)
        {
            HpBar = GetComponentInChildren<Slider>();
        }

        HpBar.maxValue = hp;
	}

	// Update is called once per frame
	void Update () {
		HpBar.value = hp;

		if (hp <= 0f)
		{
            if (gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (gameObject.tag == "Enemy")
            {
                GetComponent<Enemy>().currentState = Enemy.States.dead;
            }
            else if (gameObject.tag == "Construction")
            {
                GetComponent<ConstructionBehaviour>().currentState = ConstructionBehaviour.States.destroyed;
            }
            

        }
	}

	public void SubtractHP (float damage)
	{
		hp -= damage;
	}
}
