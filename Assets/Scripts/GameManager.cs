using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemys;
    public GameObject[] citizens;
    public PauseUi uiManager;
    public Player player;
    private static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    { 
        
    }

    private void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        citizens = GameObject.FindGameObjectsWithTag("Citizen");

        if (enemys.Length == 0 && citizens.Length == 0)
        {
            uiManager.situation = Situation.Clear;
            
            uiManager.pauseUi.SetActive(true);
            uiManager.pauseActive = true;
        }

        if (player.Hp <= 0)
        {
            uiManager.situation = Situation.GameOver;
            uiManager.pauseUi.SetActive(true);
            uiManager.pauseActive = true;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
