using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    public int speed;
    private GameObject background;

    void Start()
    {
        background =  GameObject.Find("Background");
    }

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        RectTransform rect = (RectTransform)background.transform;
        if (transform.position.x > rect.rect.width)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
