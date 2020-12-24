using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menu;
    public GameObject gameover;
    public Text score;
    public Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.health <= 0 || movement.house <= 0)
        {
            gameover.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            score.text = "Score: " + movement.score.ToString();
            highscore.text = "Highscore: " + movement.highscore.ToString();
            

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }
    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("Player").GetComponent<movement>().enabled = false;
        GameObject.Find("kojos").GetComponent<LowerAnimator>().enabled = false;
    }
    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.Find("Player").GetComponent<movement>().enabled = true;
        GameObject.Find("kojos").GetComponent<LowerAnimator>().enabled = true;

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {

        SceneManager.LoadScene(1);
    }
}
