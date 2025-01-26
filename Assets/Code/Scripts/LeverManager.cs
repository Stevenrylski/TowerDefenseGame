using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] private Slider healthBar; // Referenz zur Health Bar

    private void Awake() {
        main = this;
    }

    private void Start() {
        currency = startingCurrency;
        UpdateHealthBar();
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
        UpdateHealthBar();

        // Informiere den EnemySpawner, dass ein Feind verarbeitet wurde
        EnemySpawner.onEnemyDestroy.Invoke();

        if (lives <= 0) {
            GameOver();
        }
    }

    private void UpdateHealthBar() {
        if (healthBar != null) {
            healthBar.value = (float)lives / 10f; // Leben in den Bereich 0 bis 1 umrechnen
        }
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