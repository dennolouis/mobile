using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCube : MonoBehaviour
{
    public float speed = 10;
    float target = 8.75f;
    float curr;
    float y, z;

    bool touchingRight = false;
    bool touchingLeft = false;


    // Start is called before the first frame update
    void Start()
    {
        curr = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            if (!touchingRight)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!touchingLeft)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
        }

        //curr = Mathf.MoveTowards(curr, target, speed * Time.deltaTime);
        //transform.position = new Vector3(curr, y, z);

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
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingLeft = false;
        touchingRight = false;
    }
}


