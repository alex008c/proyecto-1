using UnityEngine;

public class CamaraController : MonoBehaviour {

    public GameObject jugador; // Para referenciar a nuestro jugador
    private Vector3 offset; // Distancia entre la cámara y el jugador

    void Start () {
        // Calcula la diferencia de posición inicial
        offset = transform.position - jugador.transform.position;
    }

    void LateUpdate () {
        // Actualiza la posición de la cámara cada frame para seguir al jugador
        transform.position = jugador.transform.position + offset;
    }
}