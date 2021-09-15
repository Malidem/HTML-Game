using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject eventSystem;
    private GameManager gameManager;

    void Start()
    {
        gameManager = eventSystem.GetComponent<GameManager>();
    }

    public void StartButton()
    {
        gameManager.canMove = true;
        gameManager.SpawnEnemies();
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
