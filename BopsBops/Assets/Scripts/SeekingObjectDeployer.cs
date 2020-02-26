using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//WOJTI - zabieram >:]

public class SeekingObjectDeployer : MonoBehaviour
{
    public GameObject seekingObject;
    private float respawnTime = 3.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        StartCoroutine(SeekingObjectWave());
    }

    private void SpawnSeeker()
    {
        GameObject gameObject = Instantiate(seekingObject) as GameObject;
        var random = Random.Range(0.0f, 1.0f);
        if (random <0.5f)
            gameObject.transform.position = new Vector2(1 * (screenBounds.x * 2 + Camera.main.transform.position.x), Random.Range(-(screenBounds.y * 4), screenBounds.y * 4) + Camera.main.transform.position.y);
        else
            gameObject.transform.position = new Vector2(-1 * (screenBounds.x * 2 + Camera.main.transform.position.x), Random.Range(-(screenBounds.y * 4), screenBounds.y * 4) + Camera.main.transform.position.y);
    }

    IEnumerator SeekingObjectWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnSeeker();
        }
    }
}
