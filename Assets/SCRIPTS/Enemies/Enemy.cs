using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [Header("Variáveis para Stats do Inimigo")]
	public Enemy enemy;

	[Header("Variáveis para velocidade do Agente")]
	NavMeshAgent agent;
	public GameObject target;
	public ProgressInterface player;
	public float speed;
	Vector3 dir;

	[Header("Variáveis para evitar obstáculo")]
	public float distToAvoidObstacle;
	public bool obstacleAhead;
	RaycastHit hitInfo;

	[Header("Variáveis de dano")]
	public float damage;

    [Header("Variáveis para inimigo tomar dano")]
    public float timeStun;
    [HideInInspector]public Health health;

    [Header("Variáveis de Recompensa")]
    public GameObject reward;

	public enum States
	{
		following,
		avoiding,
        dead
	}
	[Header("Estados do Inimigo")]
	public States currentState = States.following;

	// Use this for initialization
	void Start () {
		if (gameObject.name.Contains("EnemyLacaio"))
		{
			target = GameObject.Find("Castelo Amigo");
		}
		else
		{
			target = GameObject.FindWithTag ("Player");
			player = target.GetComponent<ProgressInterface> ();
		}
        health = GetComponent<Health>();
		agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
		transform.LookAt (target.transform);
	}
	
	// Update is called once per frame
	void Update () {
		ManageStates ();
	}

	void ManageStates()
	{
		switch(currentState)
		{
		case States.following:
			FollowStraight ();
			break;
		//case States.avoiding:
		//	FollowAvoiding ();
		//	break;
         case States.dead:
            agent.enabled = false;
            Instantiate(reward, transform.position, transform.rotation);
            Destroy(this.gameObject);
            break;
        }
	}

	void FollowStraight ()
	{
		agent.destination = target.transform.position;
		//dir = ( agent.destination - transform.position).normalized;

		Debug.DrawLine (transform.position, agent.destination, Color.yellow);

		//agent.velocity = dir * speed;


		//Ray ray = new Ray (transform.position, transform.TransformDirection(Vector3.forward));
		//obstacleAhead = Physics.Raycast (ray, out hitInfo, 100f);
		Debug.DrawLine (transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);

		#region Transição para Avoiding
		//if (obstacleAhead)
		//{
		//	Debug.Log(hitInfo.collider.gameObject.name);
		//	if (hitInfo.distance < distToAvoidObstacle) {
		//		if (hitInfo.collider.tag != "Enemy" && hitInfo.collider.tag != "Player") {
		//			agent.velocity = Vector3.zero;
		//			currentState = States.avoiding;
		//		}
		//	}
		//}
		#endregion
	}

	void FollowAvoiding()
	{
		agent.destination = target.transform.position;

		#region Transição para Following
		if (obstacleAhead)
		{
			if (hitInfo.distance > distToAvoidObstacle + 1f) {
				if (hitInfo.collider.tag != "Enemy" || hitInfo.collider.tag != "Player") {
					currentState = States.following;
				}
			}
		}
		else
			currentState = States.following;
		
		#endregion
	}

    public void TakeSomeDamage(float damage)    
    {
        health.SubtractHP(damage);
        StartCoroutine(StunTime());
    }

    IEnumerator StunTime()
    {
        agent.speed = 0f;
        yield return new WaitForSeconds(timeStun);
        agent.speed = speed;

    }
/*
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			Debug.Log ("Colidindo com " + col.gameObject.name);
			player.SubtractHP (damage + 30f);
		}
	}
*/
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			Debug.Log ("Colidindo com " + col.gameObject.name);
			player.SubtractHP (damage);
		}
	}

	void OnTriggerStay (Collider col)
	{
		Debug.Log("colidindo");
		if (col.gameObject.tag == "Construction")
		{

			Debug.Log ("Colidindo com " + col.gameObject.name);
			target.GetComponentInParent<Health>().SubtractHP (damage);
		}
	}
}
