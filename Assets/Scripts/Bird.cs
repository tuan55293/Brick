using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    float xSpeed;
    public float minYspeed;
    public float maxYspeed;

    public DestroyVfx deadVfx;

    Rigidbody2D rb;
    bool moveLeftOnStart;

    public float XSpeed { get => xSpeed; set => xSpeed = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        XSpeed = GameManager.Ins.BirdSpeed;
        Debug.Log(xSpeed);
        RandomDirection();
        Debug.Log("hehe");
    }
    private void FixedUpdate()
    {
        rb.velocity = moveLeftOnStart ? new Vector2(-XSpeed, Random.Range(minYspeed, maxYspeed))
                                        : new Vector2(XSpeed, Random.Range(minYspeed, maxYspeed));
        if (transform.position.x > 17 || transform.position.x < -17)
        {
            Destroy(gameObject);
        }
    }
    public void RandomDirection()
    {
        moveLeftOnStart = transform.position.x > 0 ? true : false;
        if (moveLeftOnStart)
        {
            if (transform.localScale.x < 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            if (transform.localScale.x > 0) return;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    public void Die()
    {
        if(gameObject.tag == "RedBird")
        {
            GameManager.Ins.BirdKilled++;
            GameGUIManager.Ins.UpdateKillerCountingRedBird(GameManager.Ins.BirdKilled);
        }
        if (gameObject.tag == "GreenBird")
        {
            GameManager.Ins.BirdKilled2++;
            GameGUIManager.Ins.UpdateKillerCountingRedBird1(GameManager.Ins.BirdKilled2);
        }
        if (deadVfx)
        {
            Instantiate(deadVfx, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
