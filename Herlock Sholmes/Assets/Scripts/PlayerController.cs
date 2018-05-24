using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public string playerNumber = "1";
    public float speed = 0.123f;

    float[] direction = new float[] { 0, 0 };
    string horizontal, vertical, action, itemSwitch;

    void Start()
    {
        horizontal = "H" + playerNumber;
        vertical = "V" + playerNumber;
    }

    void Update()
    {
        FindMovementDirection();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(new Vector3(direction[0] * speed, direction[1] * speed, 0));
    }

    void FindMovementDirection()
    {
        direction[0] = Input.GetAxisRaw(horizontal);
        direction[1] = Input.GetAxisRaw(vertical);

        LimitDiagonalSpeed();
    }

    void LimitDiagonalSpeed()
    {
        if (direction[0] != 0 && direction[1] != 0)
        {
            direction[0] *= .7071f;
            direction[1] *= .7071f;
        }
    }

}
