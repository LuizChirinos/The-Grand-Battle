using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour {

    [Header("Variáveis para Stats do Player")]

    #region Variáveis para movimentação do Player
    [Header("Variáveis para movimentação do Player")]
	public Camera cam;
    [Header("Variáveis para Agent")]
	NavMeshAgent agent;
	public float speed;
    [SerializeField] LayerMask floorMask;
    [SerializeField] Light lighting;

    Vector3 dir;
    #endregion

    #region
    [Header("Variáveis de Ataque")]
    public float distAttack;
    public float attackDamage;
    public float manaUsed;
    //public float 
    #endregion


    void Start() 
    {
		agent = GetComponent<NavMeshAgent> ();
        agent.speed = speed;
    }

    void Update() 
    {
        CheckMousePosition();
        RecoverMana();
        RecoverHealth();
    }

    private void CheckMousePosition() 
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.layer == 11)         //LAYER DO INIMIGGO
                {
					if (PlayerProgress.Mana > manaUsed) {
						#region Ataca o inimigo em cima do mouse
						if (Vector3.Distance (transform.position, hit.collider.transform.position) < distAttack) {
							hit.collider.gameObject.GetComponentInParent<Enemy> ().TakeSomeDamage (PlayerProgress.Attack);
							MagicAttack (hit.collider.transform);
							agent.destination = transform.position;

						}
						#endregion
					}

                }
                if (hit.collider.gameObject.layer == 12)         //LAYER DAS CONSTRUÇÕES
                {
					if (PlayerProgress.Mana > manaUsed) {
						#region Ataca o inimigo em cima do mouse
						if (Vector3.Distance (transform.position, hit.collider.transform.position) < 15f) {
							hit.collider.gameObject.GetComponentInParent<ConstructionBehaviour> ().TakeSomeDamage (PlayerProgress.Attack);

                            Debug.Log("atacou");
                            MagicAttack(hit.collider.transform);
							
							agent.destination = transform.position;

						}
						#endregion
					}

                }
                else if (hit.collider.gameObject.layer == 9)         //LAYER DO CHAO
                {
                    #region Move em direção ao Ponto Clicado
                    Vector3 newPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                    lighting.transform.position = newPos;
                    agent.destination = newPos;
                    lighting.gameObject.SetActive(true);

                    dir = (agent.destination - transform.position).normalized;

                    Debug.DrawLine(transform.position, agent.destination, Color.yellow);
                    //agent.velocity = dir * speed;
                    #endregion
                }
            }
        }


		if (Vector3.Distance (transform.position, lighting.transform.position) < 0.1f) {
			lighting.gameObject.SetActive(false);
		}
    }

    //Este código Ataca o inimigo e remove mana dos stats do personagem
    void MagicAttack(Transform enemy)
    {
        transform.LookAt(enemy);
        PlayerProgress.Mana -= manaUsed;
    }

    void RecoverMana()
    {
        PlayerProgress.Mana += Time.deltaTime * PlayerProgress.manaRecovery;
    }
    void RecoverHealth()
    {
        PlayerProgress.HP += Time.deltaTime * PlayerProgress.healthRecovery;
    }
}
