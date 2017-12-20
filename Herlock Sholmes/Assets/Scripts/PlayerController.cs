using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Controls")]
    [Space]
    public KeyCode upKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode downKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;
    [Space]
    public KeyCode switchItemKey = KeyCode.LeftControl;
    public KeyCode actionKey = KeyCode.LeftShift;

    [Header("Player Properties")]
    [Space]
    public float speed = 0.123f;

    Rigidbody2D rb;
    float[] direction = new float[] { 0, 0 };

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MovementDirection();
    }


    void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        transform.Translate(new Vector3(direction[0] * speed, direction[1] * speed, 0));
    }


    private void MovementDirection()
    {
        direction = new float[] { 0, 0 };

        if(Input.GetKey(actionKey) == false)
        {
            if (Input.GetKey(upKey))
            {
                direction[1]++;
            }

            if (Input.GetKey(downKey))
            {
                direction[1]--;
            }

            if (Input.GetKey(rightKey))
            {
                direction[0]++;
            }

            if (Input.GetKey(leftKey))
            {
                direction[0]--;
            }

            LimitDiagonalSpeed();
        }
    }


    private void LimitDiagonalSpeed()
    {
        if (direction[0] != 0 && direction[1] != 0)
        {
            direction[0] *= .7071f;
            direction[1] *= .7071f;
        }
    }

}
