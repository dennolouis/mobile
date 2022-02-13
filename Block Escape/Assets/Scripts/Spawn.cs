using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create()
    {
        Invoke("Create", 3);
        GameObject obsticle = Instantiate(obj, transform.position, Quaternion.identity);
        Destroy(obsticle, 3);
    }
}
