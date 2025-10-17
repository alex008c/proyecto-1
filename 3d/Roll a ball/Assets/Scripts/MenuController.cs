using UnityEngine;
using UnityEngine.SceneManagement; // ¡Esta línea es clave para cambiar de escena!

public class MenuManager : MonoBehaviour
{
    // Esta función carga la escena del juego.
    public void IniciarJuego()
    {
        // Asegúrate de que tu escena de juego se llame "Juego".
        SceneManager.LoadScene("Juego");
    }

    // Esta función carga la escena de opciones.
    public void AbrirOpciones()
    {
        SceneManager.LoadScene("Opciones");
    }

    // Esta función vuelve al menú principal.
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}