using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public string playerNumber = "1";
    public float speed = 0.123f;
    public GameObject hitbox;

    private float[] direction = new float[] { 0, 0 };
    private string horizontal, vertical, action, itemSwitch;


    void Start()
    {
        horizontal = "Horizontal" + playerNumber;
        vertical = "Vertical" + playerNumber;
        action = "ActionButton" + playerNumber;
        itemSwitch = "ItemSwitch" + playerNumber;
    }


    void Update()
    {
        FindMovementDirection();

        if (ActionKeyDown() && (Mathf.Abs(direction[0]) == 1 ^ Mathf.Abs(direction[1]) == 1))
        {
            ActivateHitbox();
        }
        else
        {
            hitbox.SetActive(false);
        }
    }


    void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        if (ActionKeyDown() == false)
        {
            transform.Translate(new Vector3(direction[0] * speed, direction[1] * speed, 0));
        }
    }


    private void ActivateHitbox()
    {
        hitbox.SetActive(true);

        Vector3 offsetPosition = new Vector3(direction[0], direction[1], transform.position.z);
        Vector3 position = offsetPosition + transform.position;

        hitbox.transform.position = position;
    }

    
    private bool ActionKeyDown()
    {
        if (Input.GetButton(action))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void FindMovementDirection()
    {
        direction[0] = Input.GetAxis(horizontal);
        direction[1] = Input.GetAxis(vertical);

        LimitDiagonalSpeed();
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
