using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(-7,0);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        //savecoin
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        //savecoinEnd
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(numberOfCoins);
        coinsText.text = numberOfCoins.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
