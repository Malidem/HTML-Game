using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullets : MonoBehaviour
{
    public int speed;
    private GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        background =  GameObject.Find("Background");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        RectTransform rect = (RectTransform)background.transform;
        if (transform.position.x > rect.rect.width)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collid with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
