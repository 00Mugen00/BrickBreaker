using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    [SerializeField]
    float screenWidthInUnits = 19f;
    [SerializeField]
    float minX = 1f;
    [SerializeField]
    float maxX = 18f;

    GameManager gameManager;
    BallController ballController;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ballController = FindObjectOfType<BallController>();
    }

    void Update()
    {
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
    }

    private float GetXPos()
    {
        if (gameManager.IsAutoPlayEnabled())
        {
            return ballController.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
