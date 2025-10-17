using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public Vector3 direccionMovimiento = new Vector3(1, 0, 0); // Hacia dónde se mueve
    public float velocidad = 2f; // Qué tan rápido se mueve
    public float distancia = 5f; // Qué tan lejos llega antes de regresar

    private Vector3 posicionInicial;
    private int direccion = 1;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Mueve el objeto
        transform.Translate(direccionMovimiento * velocidad * direccion * Time.deltaTime);

        // Si llega al límite, cambia de dirección
        if (Vector3.Distance(posicionInicial, transform.position) >= distancia)
        {
            direccion *= -1; // Invierte la dirección (de 1 a -1 y viceversa)
        }
    }
}