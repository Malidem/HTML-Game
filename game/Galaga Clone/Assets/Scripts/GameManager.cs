using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject enemyType1;
    public GameObject background;
    public GameObject canvas;
    public GameObject dummy;

    [HideInInspector]
    public bool gameStarted;
    [HideInInspector]
    public List<GameObject> Enemies = new List<GameObject>();
    [HideInInspector]
    public bool gameOver;

    private int waveAmount = 2;

    public void SpawnEnemies()
    {
        for (int i = 0; i < waveAmount; i++)
        {
            RectTransform rect = (RectTransform)background.transform;
            int num = Random.Range(1, 4);
            if (num == 1)
            {
                Enemies.Add(Instantiate(enemyType1, new Vector2(rect.rect.width + 25, Random.Range(0, rect.rect.height)), transform.rotation, canvas.transform));
            }
            else if (num == 2)
            {
                Enemies.Add(Instantiate(enemyType1, new Vector2(Random.Range((rect.rect.width / 3) * 2, rect.rect.width + 25), rect.rect.height + 25), transform.rotation, canvas.transform));
            }
            else if (num == 3)
            {
                Enemies.Add(Instantiate(enemyType1, new Vector2(Random.Range((rect.rect.width / 3) * 2, rect.rect.width + 25), -25), transform.rotation, canvas.transform));
            }
        }
    }

    void Update()
    {
        if (gameStarted && gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                }
                else
                {
                    Time.timeScale = 0;
                    pauseMenu.SetActive(true);
                }
            }

            if (Enemies.Count <= 0)
            {
                if (waveAmount >= 5)
                {
                    waveAmount += Random.Range(1, 6);
                }
                else
                {
                    waveAmount++;
                }
                SpawnEnemies();
            }
        }
    }
}
