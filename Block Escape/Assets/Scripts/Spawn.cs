using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject[] obj;
    public float speed = 2;
    public float rate = 0.4f;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }


    void Create()
    {
        Invoke("Create", speed);
        GameObject obsticle = Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        score++;
        if(speed > 0.8)
            speed -= rate * Time.deltaTime;
        Destroy(obsticle, speed + 1);
    }

    public int GetScore()
    {
        return score;
    }
}
