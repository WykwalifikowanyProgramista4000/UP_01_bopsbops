using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject[] objects;
    public float percentChanceOfGenerating = 0.2f;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -100; i <= 100; i = i + 5)
        {
            for (int j = -100; j <= 100; j = j + 5)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (percentChanceOfGenerating >= random)
                {
                    int randomIndex = Random.Range(0, objects.Length);
                    Instantiate(objects[randomIndex], new Vector2(i, j), Quaternion.identity);
                }
            }
        }
    }
}
