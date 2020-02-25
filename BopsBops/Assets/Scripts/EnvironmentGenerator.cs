using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public GameObject[] objects;
    public float percentChangeOfGenerating = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (percentChangeOfGenerating >= random)
        {
            int randomIndex = Random.Range(0, objects.Length);
            Instantiate(objects[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
