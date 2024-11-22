using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    
    public static GameManager inst;
    public int score = 0; // Puntaje actual
    public int scoreToUnlockWorld2 = 500; // Puntaje necesario para desbloquear World2
    public int scoreToUnlockWorld3 = 1000; // Puntaje necesario para desbloquear World3
    public int lives = 3; // Número inicial de vidas

    public Text livesText; // UI para mostrar las vidas
    public Text scoreText; // UI para mostrar el puntaje
    public GameObject gameOverScreen; // Pantalla de Game Over
    public Text gameOverScoreText; // UI para mostrar el puntaje final en Game Over

    //[SerializeField] Text scoreText;

    [SerializeField] PlayerMovement playerMovement;

  

    private void Awake()
    {
        //inst = this;
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateLivesUI();
        UpdateScoreUI();
    }
    // Llamar cuando el jugador pierda una vida
    public void LoseLife()
    {
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Actualizar el UI de vidas
    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    // Incrementar puntaje y actualizar la UI
    public void IncrementScore(int points)
    {
        score += points;
        UpdateScoreUI();
         // Incrementar la velocidad del jugador
        if (playerMovement != null)
        {
            scoreText.text = "SCORE: " + score;
            playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }
         // Verifica si el puntaje alcanza los límites para desbloquear mundos
        CheckForWorldUnlock();
    }
 
    // Actualizar la UI del puntaje
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    // Método para Game Over
    private void GameOver()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Activa la pantalla de Game Over
        }

        if (gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + score; // Muestra el puntaje final
        }

        Time.timeScale = 0f; // Detiene el juego
    }

    // Reiniciar el juego
    public void RestartGame()
    {
        Time.timeScale = 1f;  // Restaura el tiempo para el reinicio

        // Reinicia las variables a sus valores iniciales
        lives = 3;
        score = 0;
        UpdateLivesUI();
        UpdateScoreUI();

        // Recarga la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void CheckForWorldUnlock()
    {
        // Si el puntaje alcanza el valor necesario, cambia la escena
        if (score >= scoreToUnlockWorld2 && SceneManager.GetActiveScene().name != "World2")
        {
            // Cargar World2 cuando se haya alcanzado el puntaje para ello
            SceneManager.LoadScene("World2");
        }
        else if (score >= scoreToUnlockWorld3 && SceneManager.GetActiveScene().name != "World3")
        {
            // Cargar World3 cuando se haya alcanzado el puntaje para ello
            SceneManager.LoadScene("World3");
        }
    }
    
    private void Update()
    {

    }
}

