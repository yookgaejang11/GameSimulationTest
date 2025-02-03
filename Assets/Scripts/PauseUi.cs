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
    public Player player;
    public Bullet Bullet;
    public bool pauseActive;
    public GameObject ResumeBtn;
    public Situation situation; 
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI Hp;
    public TextMeshProUGUI Speed;
    public TextMeshProUGUI AtkSpeed;
    public TextMeshProUGUI Enemies;
    public TextMeshProUGUI Citizens;
    public GameObject pauseUi;

    private void Awake()
    {
        pauseActive = false;
        situation = Situation.None;
        pauseUi.SetActive(false);
        ;
    }
    private void Update()
    {
        Hp.text = "Hp " + player.Hp;
        Speed.text = "Speed " + player.speed;
        AtkSpeed.text = "AtkSpeed " + Bullet.speed;
        Enemies.text = "Enemies Left " + GameManager.Instance.enemys.Length;
        Citizens.text = "Citizens Left " + GameManager.Instance.citizens.Length;
        if(pauseActive && mainText == null)
        {
            mainText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        }
        OpenUi();
        if(situation == Situation.Pause )
        {
            ResumeBtn.SetActive(true);
        }
        else
        {
            ResumeBtn.SetActive(false);
        }


       if(pauseActive)
        {
            switch (situation)
            {
                case Situation.None:
                    mainText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
                    mainText.text = "None";
                    break;
                case Situation.Pause:
                    mainText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
                    mainText.text = "Pause";
                    break;
                case Situation.GameOver:
                    mainText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
                    mainText.text = "GameOver";
                    break;
                case Situation.Clear:
                    mainText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
                    mainText.text = "Clear";
                    break;
            }
        }

    }

   

    

    void OpenUi()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            situation = Situation.Pause;
            Time.timeScale = 0;
            pauseActive = true;
            pauseUi.SetActive(true);
        }
    }

    public void Resume()
    {
        situation = Situation.None;
        Time.timeScale = 1.0f;
        pauseUi.SetActive(false);
        pauseActive = false;
        
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
