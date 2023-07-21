using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FireballScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gm;
    public Transform pointA, pointB;
    public bool moveUp;
    public float currentSpeed;
    private float ay, by;
    private float timer;
    public GameObject fireball;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        ay = pointA.transform.position.y;
        by = pointB.transform.position.y;

    }

    void Update()
    {
        if (moveUp == true)
        {
            transform.position += new Vector3(0, currentSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, currentSpeed * Time.deltaTime, 0);
        }
        if (transform.position.y <= by)
        {
            moveUp = true;
        }
        if (transform.position.y >= ay)
        {
            moveUp = false;
        }
        rb.velocity = Vector2.left * (currentSpeed + gm.SpeedMultiplier);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }
}
