using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W Pressed");
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("A Pressed");
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            print("S Pressed");
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            print("D Pressed");
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space Pressed");
        }
    }
}
