using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour
{

    public int speed = 10;
    float direction;

    private void Start()
    {
        direction = Mathf.Floor(Random.Range(-1, 2));
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(direction, 0, 0) * speed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        speed = -speed;
    }
}
