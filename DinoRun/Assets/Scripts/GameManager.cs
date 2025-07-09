using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float gameSpeed = 5f;
    [SerializeField]
    private float speedIncrease = 0.15f;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float score = 0;
    [SerializeField] private GameObject scoreTextObject;
    [SerializeField] private GameObject gameStartMess;
    [SerializeField] private GameObject gameOverMess;
    private bool isGameOver = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

        HandleStartGameInput();

        if (!isGameOver)
        {
            UpdateGmaeSpeed();
            UpdateScore();
        }
    }
    private void UpdateGmaeSpeed()
    {
        gameSpeed += Time.deltaTime * speedIncrease;
    }
    public void UpdateScore()
    {
        score += Time.deltaTime * 10;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);
    }
    private void StartGame()
    {
        Time.timeScale = 0;
        scoreTextObject.SetActive(false);
        gameStartMess.SetActive(true);
        gameOverMess.SetActive(false);
    }
    private void HandleStartGameInput()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1;
            scoreTextObject.SetActive(true);
            gameStartMess.SetActive(false);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverMess.SetActive(true);
        Time.timeScale = 0;
        StartCoroutine(ReLoadScene());
    }
    private IEnumerator ReLoadScene()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
