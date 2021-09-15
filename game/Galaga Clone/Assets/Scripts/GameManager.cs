using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject enemyType1;
    public GameObject background;
    public GameObject canvas;
    public GameObject dummy;

    [HideInInspector]
    public bool canMove;

    private int num = 10;

    void Start()
    {

    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < num; i++)
        {
            Vector2 pos = GenerateSpawnPos();
            if (WillEnemyCollide(pos))
            {
                Instantiate(enemyType1, pos, transform.rotation, canvas.transform);
            }
            //else
            //{
            //    num++;
            //}
        }
    }

    Vector2 GenerateSpawnPos()
    {
        RectTransform rect = (RectTransform)background.transform;
        return new Vector2(Random.Range((rect.rect.width / 2), rect.rect.width),
                Random.Range(0, rect.rect.height));
    }

    bool WillEnemyCollide(Vector2 pos)
    {
        GameObject instance = Instantiate(dummy, pos, transform.rotation, canvas.transform);
        Collider2D[] colliding = {};

        instance.AddComponent<BoxCollider2D>();
        instance.GetComponent<BoxCollider2D>().size = enemyType1.GetComponent<BoxCollider2D>().size;
        instance.GetComponent<BoxCollider2D>().offset = enemyType1.GetComponent<BoxCollider2D>().offset;
        instance.GetComponent<BoxCollider2D>().OverlapCollider(new ContactFilter2D().NoFilter(), colliding);
        Destroy(instance);
        if (colliding.Length > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void Update()
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
    }
}
