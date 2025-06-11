using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    private NavMeshAgent agente;
    [SerializeField]private Transform target;
    [SerializeField]private float velocidadeInimigo = 5f;
   
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(target.position);
        agent.speed = velocidadeInimigo;
    }
}
