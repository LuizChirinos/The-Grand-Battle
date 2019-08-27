using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class ConstructionBehaviour : MonoBehaviour {

    [HideInInspector] public Health health;
    public GameObject reward;
    public NavMeshSurface surface;
    public enum States
    {
        normal,
        destroyed
    }
    public States currentState = States.normal;

    // Use this for initialization
    void Start () {
        health = GetComponent<Health>();
	}

    void Update()
    {
		
        switch(currentState)
        {
            case States.normal:
                break;
		case States.destroyed:

			Instantiate (reward, new Vector3 (transform.position.x, 1f, transform.position.z), transform.rotation);

			ObjectiveCastle.castlesDetroyed++;
			//Debug.Log (ObjectiveCastle.castlesDetroyed);
            Destroy(this.gameObject);

            if (gameObject.name == "Castelo Amigo")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
                break;
        }

    }

    public void TakeSomeDamage(float damage)
    {
        health.SubtractHP(damage);
    }
}
