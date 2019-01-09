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

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    void Start()
    {
        paddleToBallVector = transform.position - paddleController.transform.position;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(xForce, yForce);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(paddleController.transform.position.x, paddleController.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }
}
