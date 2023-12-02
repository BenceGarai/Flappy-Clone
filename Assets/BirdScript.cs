using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrenth;
    public LogicScript logic;
    public bool playerIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrenth;
        }
        if (transform.position.y < -39 ||  transform.position.y > 39)
        {
            logic.gameOver();
            playerIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        playerIsAlive = false;
    }
}
