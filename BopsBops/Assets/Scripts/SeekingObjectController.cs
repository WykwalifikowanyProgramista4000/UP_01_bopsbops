using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingObjectController : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    private Rigidbody2D rigidbody;
    private bool moving;
    private int direction;

    Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        var renderer = GetComponent<SpriteRenderer>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        if (gameObject.transform.position.x - Camera.main.transform.position.x > 0)
        {
            direction = -1;
            renderer.color = Color.green;
        }
        else if (gameObject.transform.position.x - Camera.main.transform.position.x < 0)
        {
            direction = 1;
            renderer.color = Color.yellow;
            gameObject.transform.Rotate(0, 0, 180);
        }

        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = new Vector2(transform.position.x + (speed * direction), transform.position.y);
        }

        if (Math.Abs(gameObject.transform.position.x - Camera.main.transform.position.x) > 30 || Math.Abs(gameObject.transform.position.y - Camera.main.transform.position.y) > 30)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("PlayerObject"))
            moving = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("PlayerObject"))
            moving = true;
    }
}
