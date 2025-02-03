using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemyResponse;
    void Start()
    {
        foreach (GameObject enemys in enemyResponse)
        {
            Instantiate(enemy, enemys.transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
