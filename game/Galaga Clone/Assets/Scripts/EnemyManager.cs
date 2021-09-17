using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject bullets;
    float rotate = 25;
    float speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        canvas = GameObject.Find("Canvas");
        float y = canvas.transform.position.y;
        if (transform.position.y < y)
        {
            transform.rotation = Quaternion.Euler(0, 0, -rotate);
        }
        if (transform.position.y > y) 
        {
            transform.rotation = Quaternion.Euler(0, 0, rotate);
        }
        StartCoroutine(SpawnBullets());
    }

    public IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(bullets, transform.position, transform.rotation, canvas.transform);
    }

    void Update()
    {
        //Vector2 direction = player.transform.position - transform.position;
        //float angle = Vector2.Angle(direction, transform.forward);
        //print("angle: " + angle);
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }
}
