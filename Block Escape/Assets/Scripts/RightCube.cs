using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCube : MonoBehaviour
{
    public float speed = 10;

    public float maxLeft = -6.75f;
    
    bool touchingRight = false;
    bool touchingLeft = false;
    public bool immune = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            immune = true;
            Time.timeScale = 1;
            Invoke("Resume", 1);
        }

        //move right
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            if (!touchingRight && transform.position.x < 27)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!touchingLeft)
            {
                if(transform.position.x < maxLeft)
                {
                    transform.Translate(new Vector3(0, 0, 0));
                }
                else
                {
                    transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
                }
            }
        }

        //return to center from right
        if (!(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D)) && transform.position.x > 0)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        //return to center from left
        if(!Input.GetKey(KeyCode.A) && transform.position.x < 0.75){
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
                if(!immune)
                    Time.timeScale = 0;
                break;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingLeft = false;
        touchingRight = false;
    }

    void Resume()
    {
        immune = false;
    }
}


