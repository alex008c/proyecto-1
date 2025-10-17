using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController : MonoBehaviour
{
    // VARIABLES PÚBLICAS
    public float velocidad;
    public Text textoContador;
    public Text textoGanar;
    public AudioClip sonidoCubo;
    public AudioClip sonidoAnillo; // Sonido para el anillo

    // VARIABLES PRIVADAS
    private Rigidbody rb;
    private int contador;
    private AudioSource audioSourceJugador;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSourceJugador = GetComponent<AudioSource>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();
            audioSourceJugador.PlayOneShot(sonidoCubo);
        }
        else if (other.gameObject.CompareTag("Anillo"))
        {
            other.gameObject.SetActive(false);
            audioSourceJugador.PlayOneShot(sonidoAnillo); // Reproduce el sonido del anillo
            GameObject.Find("AudioManager").GetComponent<AudioSource>().Stop();
        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            textoGanar.text = "¡Ganaste!";
            Invoke("VolverAlMenu", 10f); // Llama para volver al menú
        }
    }

    void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}