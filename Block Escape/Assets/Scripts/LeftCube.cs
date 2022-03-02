using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCube : MonoBehaviour
{
    public float speed = 10;
    public float maxRight = 6.75f;

    bool touchingRight = false;
    bool touchingLeft = false;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move left
        if (Input.GetKey(KeyCode.A))
        {
            if (!touchingLeft && transform.position.x > -28)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
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
        if (!(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D)) && transform.position.x > -3)
        {
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        }

        //return to center from left
        if (!Input.GetKey(KeyCode.A) && transform.position.x < -0.75)
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
                if(!FindObjectOfType<RightCube>().immune)
                    Time.timeScale = 0;
                break;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingLeft = false;
        touchingRight = false;
    }
}


