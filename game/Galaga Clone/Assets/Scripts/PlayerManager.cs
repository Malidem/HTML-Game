using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int speed = 500;
    public float horizontalInput;
    public float verticalInput;
    public GameObject background;
    public GameObject bullet;
    public GameObject canvas;
    public GameObject eventSystem;
    public GameObject health;
    public GameObject HUD;

    private GameManager gameManager;
    private List<GameObject> allHealth = new List<GameObject>();

    void Start()
    {
        gameManager = eventSystem.GetComponent<GameManager>();
        AddHealth(3);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (gameManager.gameStarted)
        {
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
            transform.Translate(Vector3.up * Time.deltaTime * verticalInput * speed); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, transform.rotation, canvas.transform);
        }

        RectTransform rect = (RectTransform)background.transform;
        RectTransform rect2 = (RectTransform)transform;
        float sizeX = rect2.rect.width / 2;
        float sizeY = rect2.rect.height / 2;

        if ((transform.position.x + sizeX) > (rect.rect.width / 2))
        {
            transform.position = new Vector2(((rect.rect.width / 2) - sizeX), transform.position.y);
        }

        if ((transform.position.y + sizeY) > rect.rect.height)
        {
            transform.position = new Vector2(transform.position.x, (rect.rect.height - sizeY));
        }

        if ((transform.position.x - sizeX) < 0)
        {
            transform.position = new Vector2((0 + sizeX), transform.position.y);
        }

        if ((transform.position.y - sizeY) < 0)
        {
            transform.position = new Vector2(transform.position.x, (0 + sizeY));
        }
    }

    public void RemoveHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject obj = allHealth[allHealth.Count];
            allHealth.Remove(obj);
            Destroy(obj);
        }
    }

    public void AddHealth(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            allHealth.Add(Instantiate(health, new Vector2(0, 0), HUD.transform.rotation, HUD.GetComponentsInChildren<Transform>()[1]));
        }
    }
}
