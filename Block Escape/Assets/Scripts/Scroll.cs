using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float speed = 5;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);

        if(transform.position.y > 9999999999999999999)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
