using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed = 100;
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
            transform.Rotate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
        }

        //move right
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
    }
}
