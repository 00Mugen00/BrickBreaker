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

    void Start()
    {
        
    }

    void Update()
    {
        float mousePositionInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(transform.position.x, transform.position.y);
        paddlePosition.x = Mathf.Clamp(mousePositionInUnits, minX, maxX);
        transform.position = paddlePosition;
    }
}
