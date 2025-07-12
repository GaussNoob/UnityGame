using UnityEngine; // Importa o namespace principal da Unity, necessário para acessar classes como MonoBehaviour e Transform.
using UnityEngine.AI; // Importa o namespace para o sistema de navegação (NavMesh), usado para controle de agentes de IA.

public class IA : MonoBehaviour // Define a classe IA, que herda de MonoBehaviour, permitindo que o script seja anexado a um GameObject na Unity.
{
    // Declara uma variável privada para armazenar a referência ao componente NavMeshAgent, que controla a navegação do agente no NavMesh.
    private NavMeshAgent agente;
    
    // Declara uma variável pública serializada para definir o alvo (Transform) que o agente deve seguir, configurável no Inspector da Unity.
    [SerializeField] private Transform target;
    
    // Declara uma variável pública serializada para definir a velocidade do inimigo, com valor padrão de 5 unidades por segundo, configurável no Inspector.
    [SerializeField] private float velocidadeInimigo = 5f;

    // Método Start é chamado uma vez quando o GameObject é inicializado, antes do primeiro frame.
    void Start()
    {
        // Obtém o componente NavMeshAgent anexado ao mesmo GameObject que este script e o armazena na variável 'agente'.
        agente = GetComponent<NavMeshAgent>();
    }

    // Método Update é chamado a cada frame, atualizando a lógica do jogo continuamente.
    void Update()
    {
        // Define o destino do agente como a posição atual do objeto alvo (target), fazendo o agente se mover em direção a ele.
        agente.SetDestination(target.position);
        
        // Define a velocidade do agente para o valor configurado em 'velocidadeInimigo', controlando quão rápido ele se move.
        agente.speed = velocidadeInimigo;
    }
}
