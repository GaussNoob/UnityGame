using UnityEngine; // Importa o namespace principal da Unity, necessário para acessar classes como MonoBehaviour, CharacterController e Vector3.

public class Movimentacao : MonoBehaviour // Define a classe Movimentacao, que herda de MonoBehaviour, permitindo que o script seja anexado a um GameObject na Unity.
{
    // Declara uma variável pública serializada para definir a velocidade de movimento do personagem, configurável no Inspector (padrão: 9.5).
    [SerializeField] private float velocidade = 9.5f;
    
    // Declara uma variável pública serializada para definir a força da gravidade aplicada ao personagem (padrão: -9.81, valor típico da gravidade terrestre).
    [SerializeField] private float gravidade = -9.81f;
    
    // Declara uma variável pública serializada para definir a força do pulo do personagem, configurável no Inspector (padrão: 5).
    [SerializeField] private float forcaDoPulo = 5f;

    // Declara uma variável privada para armazenar a referência ao componente CharacterController, usado para movimentação e colisão.
    private CharacterController controller;
    
    // Declara uma variável privada para controlar a direção e velocidade vertical do personagem (usada para pulo e gravidade).
    private Vector3 direcaoY;

    // Método Start é chamado uma vez quando o GameObject é inicializado, antes do primeiro frame.
    void Start()
    {
        // Obtém o componente CharacterController anexado ao mesmo GameObject que este script e o armazena na variável 'controller'.
        controller = GetComponent<CharacterController>();
    }

    // Método Update é chamado a cada frame, atualizando a lógica de movimentação do personagem.
    void Update()
    {
        // Obtém os valores dos eixos de entrada horizontal (A/D ou setas esquerda/direita) e vertical (W/S ou setas cima/baixo).
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Cria um vetor de movimento com base nas entradas horizontais e verticais, com y=0 para movimento no plano XZ, e normal Facilita a normalização do vetor para garantir que o movimento tenha magnitude constante.
        Vector3 movimento = new Vector3(horizontal, 0f, vertical).normalized;

        // Verifica se há movimento (vetor não é zero).
        if (movimento != Vector3.zero)
        {
            // Calcula a rotação necessária para o personagem olhar na direção do movimento.
            Quaternion novaRotacao = Quaternion.LookRotation(movimento);
            // Aplica a rotação suavemente usando Slerp, com uma velocidade de rotação ajustada por Time.deltaTime * 10f.
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 10f);
        }

        // Verifica se o personagem está no chão e se a velocidade vertical é negativa (caindo).
        if (controller.isGrounded && direcaoY.y < 0)
        {
            // Define uma pequena velocidade vertical negativa para garantir que o personagem permaneça "colado" ao chão.
            direcaoY.y = -2f;
        }

        // Verifica se o personagem está no chão e se a tecla Espaço foi pressionada no frame atual.
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Aplica a força do pulo à componente y do vetor de direção vertical.
            direcaoY.y = forcaDoPulo;
        }

        // Aplica a gravidade à componente y do movimento, acumulando a aceleração ao longo do tempo (multiplicado por Time.deltaTime).
        direcaoY.y += gravidade * Time.deltaTime;

        // Combina o movimento horizontal (baseado na entrada do jogador) com a velocidade vertical (pulo/gravidade).
        Vector3 movimentoFinal = movimento * velocidade + direcaoY;

        // Move o personagem usando o CharacterController, aplicando o movimento final ajustado pelo tempo entre frames (Time.deltaTime).
        controller.Move(movimentoFinal * Time.deltaTime);
    }
}
