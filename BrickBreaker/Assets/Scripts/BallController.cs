using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField]
    PaddleController paddleController;
    [SerializeField]
    float xForce = 2f;
    [SerializeField]
    float yForce = 15f;
    [SerializeField]
    float randomFactor = 0.5f;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    Rigidbody2D rigidbody2D;

    void Start()
    {
        paddleToBallVector = transform.position - paddleController.transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            rigidbody2D.velocity = new Vector2(xForce, yForce);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddleController.transform.position.x, paddleController.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            rigidbody2D.velocity += velocityTweak;
        }
    }
}
