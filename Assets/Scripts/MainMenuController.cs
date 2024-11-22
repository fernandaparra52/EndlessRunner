using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class MainMenuController : MonoBehaviour
{
    // Método para cargar la escena de inicio
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Reemplaza "MainMenu" por el nombre de tu escena de inicio
    }

    // Método para cargar la escena del juego
    public void LoadGameScene()
    {
        SceneManager.LoadScene("SampleScene");  // Reemplaza "GameScene" por el nombre de tu escena de juego
    }
}
