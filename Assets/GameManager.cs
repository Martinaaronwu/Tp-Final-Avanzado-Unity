using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // solo si usás TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    public void AddPoint()
    {
        score++;
        UpdateUI();
    }

    void UpdateUI()
    {
        scoreText.text = "Puntaje: " + score;
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
