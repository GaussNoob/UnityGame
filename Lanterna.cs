using UnityEngine;

public class Luz : MonoBehaviour
{
    private Light Lanterna;
    private bool Ligado = false;

    void Start()
    {
        Lanterna = GetComponent<Light>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ligado = !Ligado;
            Lanterna.enabled = Ligado;
        }
    }
}
