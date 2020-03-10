using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /*Config params*/
    [SerializeField] float wideUnits = 16f;
    [SerializeField] float maxXPos = 14f;
    [SerializeField] float minXPos = 0f;

    Rigidbody2D rb;


    private void Start() {
        GetComponents();
        SetInitalPosition();
    }


    private void FixedUpdate() {
        MovePaddle();
    }


    private void GetComponents() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void SetInitalPosition() {
        float xUnitsPosition = Utils.getMousePositionInUnits(wideUnits).x;
        rb.MovePosition(new Vector2(xUnitsPosition, transform.position.y));
    } 


    private void MovePaddle() {
        float xDelta = Input.GetAxis("Mouse X");
        float xPos = Mathf.Clamp(transform.position.x + xDelta, minXPos, maxXPos);
        rb.MovePosition(new Vector2(xPos, transform.position.y));
        
        /*Solução do Curso*/
        // (utils)rb.MovePosition(new Vector2(getMousePositionInUnits().x, transform.position.y));
    }
}
