using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectController : MonoBehaviour
{
    private bool canHide;
    private bool hiding;
    public Animator animator;
    [SerializeField] private float speed = 0.5f;

    private Rigidbody2D rigidbody;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && canHide)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            renderer.sortingOrder = 0;
            hiding = true;
        }
        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            renderer.sortingOrder = 2;
            hiding = false;
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Back", false);
        animator.SetBool("Side", false);

        if (!hiding)
        {
            if (Input.GetKey(KeyCode.W)) { MoveUp(); }
            if (Input.GetKey(KeyCode.A)) { MoveLeft(); }
            if (Input.GetKey(KeyCode.S)) { MoveDown(); }
            if (Input.GetKey(KeyCode.D)) { MoveRight(); }
        }
    }

    void MoveUp()
    {
        if (gameObject.transform.position.y <= 100 - renderer.size.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
            animator.SetFloat("Speed", 1f);
            animator.SetBool("Back", true);
        }
    }

    void MoveDown()
    {
        if (gameObject.transform.position.y >= -100 + renderer.size.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);
            animator.SetFloat("Speed", 1f);
        }
    }

    void MoveRight()
    {
        if (gameObject.transform.position.x <= 100 - renderer.size.x)
        {
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            animator.SetFloat("Speed", 1f);
            renderer.flipX = false;
            animator.SetBool("Side", true);
        }
    }

    void MoveLeft()
    {
        if (gameObject.transform.position.x >= -100 + renderer.size.x)
        {
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
            animator.SetFloat("Speed", 1f);
            animator.SetBool("Side", true);
            renderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("HidingObject"))
        {
            canHide = true;
        }
        else if (collision.gameObject.name.StartsWith("SeekingObject"))
        {
            renderer.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("HidingObject"))
        {
            canHide = false;
        }
        else if (collision.gameObject.name.StartsWith("SeekingObject"))
        {
            renderer.color = Color.white;
        }
    }
}
