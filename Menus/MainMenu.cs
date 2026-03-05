using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This script is used to manage the main menu of the game.
    // It can be extended to include buttons and other UI elements.
    public void InicioJuegoBtn(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}