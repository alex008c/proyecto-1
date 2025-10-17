using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorController_nivel_2_3 : MonoBehaviour
{
    // VARIABLES PÚBLICAS
    public float velocidad;
    public Text textoContador;
    public Text textoGanar;
    public Text textoTimer;
    public AudioClip sonidoCubo;
    public AudioClip sonidoAnillo;

    // VARIABLES PRIVADAS
    private Rigidbody rb;
    private int contador;
    private AudioSource audioSourceJugador;
    private float tiempoRestante = 60f;
    private bool juegoTerminado = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSourceJugador = GetComponent<AudioSource>();
        contador = 0;
        setTextoContador();
        textoGanar.text = "";
    }

    void Update()
    {
        if (!juegoTerminado && tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            textoTimer.text = "Tiempo: " + Mathf.FloorToInt(tiempoRestante).ToString();
        }
        else if (!juegoTerminado && tiempoRestante <= 0)
        {
            juegoTerminado = true;
            rb.isKinematic = true;
            textoGanar.text = "¡Perdiste! Presiona 'R' para reintentar.";
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetearJuego();
        }
    }

    void FixedUpdate()
    {
        if (!juegoTerminado)
        {
            float movimientoH = Input.GetAxis("Horizontal");
            float movimientoV = Input.GetAxis("Vertical");
            Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
            rb.AddForce(movimiento * velocidad);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (juegoTerminado) return;

        if (other.gameObject.CompareTag("Coleccionable") || other.gameObject.CompareTag("Anillo"))
        {
            // Unificamos la lógica para ambos coleccionables
            other.gameObject.SetActive(false);
            contador = contador + 1;
            setTextoContador();

            if (other.gameObject.CompareTag("Coleccionable"))
            {
                audioSourceJugador.PlayOneShot(sonidoCubo);
            }
            else // Si es un Anillo
            {
                audioSourceJugador.PlayOneShot(sonidoAnillo);
                GameObject.Find("AudioManager").GetComponent<AudioSource>().Stop();
            }
        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador.ToString();
        // --- AQUÍ ESTÁ LA CORRECCIÓN ---
        // Cambia el 10 por el número de objetos que tengas
        if (contador >= 10)
        {
            juegoTerminado = true;
            textoGanar.text = "¡Ganaste! Presiona 'R' para jugar de nuevo.";
            // Carga la escena del laberinto
            SceneManager.LoadScene("NivelObstaculo");
        }
    }

    void ResetearJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}