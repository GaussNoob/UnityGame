using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    [SerializeField] private float velocidade = 9.5f;
    [SerializeField] private float gravidade = -9.81f;
    [SerializeField] private float forcaDoPulo = 5f;

    private CharacterController controller;
    private Vector3 direcaoY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(horizontal, 0f, vertical).normalized;

    
        if (movimento != Vector3.zero)
        {
            Quaternion novaRotacao = Quaternion.LookRotation(movimento);
            transform.rotation = Quaternion.Slerp(transform.rotation, novaRotacao, Time.deltaTime * 10f);
        }

        if (controller.isGrounded && direcaoY.y < 0)
        {
            direcaoY.y = -2f;
        }

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            direcaoY.y = forcaDoPulo;
        }

        direcaoY.y += gravidade * Time.deltaTime;

        Vector3 movimentoFinal = movimento * velocidade + direcaoY;

        controller.Move(movimentoFinal * Time.deltaTime);
    }
}