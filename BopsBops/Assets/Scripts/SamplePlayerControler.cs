using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerControler : MonoBehaviour
{
    [SerializeField] private float speed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { MoveUp(); }
        if (Input.GetKey(KeyCode.A)) { MoveLeft(); }
        if (Input.GetKey(KeyCode.S)) { MoveDown(); }
        if (Input.GetKey(KeyCode.D)) { MoveRight(); }
        {
            
        }
    }

    void MoveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }

    void MoveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
    }

    void MoveRight()
    {
        transform.position = new Vector2(transform.position.x + speed, transform.position.y);
    }

    void MoveLeft()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }

}
