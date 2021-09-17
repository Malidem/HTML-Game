using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    public int speed;
    private GameObject background;
    private GameManager gameManager;
    private GameObject player;

    void Start()
    {
        background = GameObject.Find("Background");
        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        RectTransform rect = (RectTransform)background.transform;
        if (transform.position.x < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.Player.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
