using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            EnemyMovement childEnemyMovement = child.GetComponent<EnemyMovement>();
            childEnemyMovement.EnableGoomba();
            childEnemyMovement.GameRestart();

            // todo: consider reseting the enemyisdead trigger
        }
    }
}
