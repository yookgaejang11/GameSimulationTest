using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Situation
{
    None,
    Pause,
    GameOver,
    Clear,
}
public class PauseUi : MonoBehaviour
{
    public Situation situation; 
    public TextMeshProUGUI text;
    public GameObject pauseUi;

    private void Awake()
    {
        situation = Situation.None;
        pauseUi.SetActive(false);
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        OpenUi();


    }

    void OpenUi()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseUi.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseUi.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void RePlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
