using UnityEngine; // Importa o namespace principal da Unity, necessário para acessar classes como MonoBehaviour e Light.

public class Luz : MonoBehaviour // Define a classe Luz, que herda de MonoBehaviour, permitindo que o script seja anexado a um GameObject na Unity.
{
    // Declara uma variável privada para armazenar a referência ao componente Light, que controla a lanterna.
    private Light Lanterna;
    
    // Declara uma variável privada para rastrear o estado da lanterna (ligada ou desligada), inicializada como desligada (false).
    private bool Ligado = false;

    // Método Start é chamado uma vez quando o GameObject é inicializado, antes do primeiro frame.
    void Start()
    {
        // Obtém o componente Light anexado ao mesmo GameObject que este script e o armazena na variável 'Lanterna'.
        Lanterna = GetComponent<Light>();
    }

    // Método Update é chamado a cada frame, verificando continuamente as entradas do jogador.
    void Update()
    {
        // Verifica se a tecla 'F' foi pressionada no frame atual.
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Inverte o estado da lanterna (de ligado para desligado, ou vice-versa).
            Ligado = !Ligado;
            
            // Habilita ou desabilita o componente Light com base no estado da variável 'Ligado'.
            Lanterna.enabled = Ligado;
        }
    }
}
