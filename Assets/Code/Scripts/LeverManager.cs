using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager main;

    public Transform startPoint;
    public Transform[] path;

    public int currency;
    public int lives = 5; // Startleben
    [SerializeField] private int startingCurrency = 100;

    [Header("UI References")]
    [SerializeField] private GameObject gameOverScreen; // Canvas für Game Over
    [SerializeField] private TMPro.TextMeshProUGUI livesText; // UI für Leben

    private void Awake() {
        main = this;
    }

    private void Start() {
        currency = startingCurrency;
        UpdateLivesUI();
    }

    public void IncreaseCurrency(int amount) {
        currency += amount;
    }

    public bool SpendCurrency(int amount) {
        if (amount <= currency) {
            currency -= amount;
            return true;
        } else {
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }

    public void LoseLife() {
        if (lives <= 0) return;

        lives--;
        UpdateLivesUI();

        if (lives <= 0) {
            GameOver();
        }
    }

    private void UpdateLivesUI() {
        if (livesText != null)
            livesText.text = "Lives: " + lives.ToString();
    }

    private void GameOver() {
        Debug.Log("Game Over");
        Time.timeScale = 0f; // Spiel pausieren
        if (gameOverScreen != null)
            gameOverScreen.SetActive(true); // Game Over Screen anzeigen
    }

    public void RestartLevel() {
        Time.timeScale = 1f; // Zeit zurücksetzen
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Szene neu laden
    }
}
