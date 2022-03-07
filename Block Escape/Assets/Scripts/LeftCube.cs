using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftCube : MonoBehaviour
{
    public float speed = 10;
    public float maxRight = 6.75f;

    bool touchingRight = false;
    bool touchingLeft = false;

    bool left = false, right = false;

    // Update is called once per frame
    void Update()
    {
        //move left
        if (left)
        {
            if (!touchingLeft && transform.position.x > -28)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);        
            }
        }
        else if (right)
        {
            if (!touchingRight)
            {
                if (transform.position.x > maxRight)
                {
                    transform.Translate(new Vector3(0, 0, 0));                 
                }
                else
                {
                    transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
                }
            }
        }

        //return to center from right
        if (!right && transform.position.x > -3)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        //return to center from left
        if (!left && transform.position.x < -0.75)
        {
            transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Left":
                touchingLeft = true;
                break;
            case "Right":
                touchingRight = true;
                break;
            case "Obsticle":
                if (!FindObjectOfType<RightCube>().immune)
                {
                    FindObjectOfType<Spawn>().Save();
                    Time.timeScale = 0;
                }
                break;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingLeft = false;
        touchingRight = false;
    }



    public void SetLeft(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            left = true;
        }
        if (value.canceled)
        {
            left = false;
        }
    }
    public void SetRight(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            right = true;
        }
        if (value.canceled)
        {
            right = false;
        }
    }
}


