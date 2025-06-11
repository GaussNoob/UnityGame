using UnityEngine;

public class Sons : MonoBehaviour
{
    public CharacterController controller;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool estaAndando = Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f;

        if (controller.isGrounded && estaAndando)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.pitch = Random.Range(0.8f, 1.3f);
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}