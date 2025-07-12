using UnityEngine; // Importa o namespace principal da Unity, necessário para acessar classes como MonoBehaviour, CharacterController e AudioSource.

public class Sons : MonoBehaviour // Define a classe Sons, que herda de MonoBehaviour, permitindo que o script seja anexado a um GameObject na Unity.
{
    // Declara uma variável pública para armazenar a referência ao componente CharacterController, usado para verificar se o personagem está no chão.
    public CharacterController controller;
    
    // Declara uma variável privada para armazenar a referência ao componente AudioSource, usado para reproduzir sons.
    private AudioSource audioSource;

    // Método Start é chamado uma vez quando o GameObject é inicializado, antes do primeiro frame.
    void Start()
    {
        // Obtém o componente AudioSource anexado ao mesmo GameObject que este script e o armazena na variável 'audioSource'.
        audioSource = GetComponent<AudioSource>();
    }

    // Método Update é chamado a cada frame, atualizando a lógica de reprodução de som com base no movimento do personagem.
    void Update()
    {
        // Obtém os valores dos eixos de entrada horizontal (A/D ou setas esquerda/direita) e vertical (W/S ou setas cima/baixo).
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // Verifica se o personagem está se movendo, considerando um movimento significativo (maior que 0.1 em valor absoluto) em qualquer direção.
        bool estaAndando = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

        // Verifica se o personagem está no chão (usando o CharacterController) e se está se movendo.
        if (controller.isGrounded && estaAndando)
        {
            // Se o áudio não está sendo reproduzido, ajusta o tom (pitch) do som para um valor aleatório entre 0.8 e 1.3 para adicionar variação.
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = Random.Range(0.8f, 1.3f);
                // Inicia a reprodução do som configurado no componente AudioSource.
                audioSource.Play();
            }
        }
        // Se o personagem não está no chão ou não está se movendo, para o som, se ele estiver tocando.
        else
        {
            if (audioSource.isPlaying)
            {
                // Para a reprodução do som.
                audioSource.Stop();
            }
        }
    }
}
