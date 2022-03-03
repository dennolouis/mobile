using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Spawn : MonoBehaviour
{

    public GameObject[] obj;
    public float speed = 2;
    public float rate = 0.4f;

    public TextMeshProUGUI scoreUI;

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Create();
        scoreUI = FindObjectOfType<TextMeshProUGUI>();
    }


    void Create()
    {
        Invoke("Create", speed);
        GameObject obsticle = Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        score++;
        scoreUI.text = "Score: " + score.ToString();
        if(speed > 0.8)
            speed -= rate * Time.deltaTime;
        Destroy(obsticle, speed + 1);
    }

    public int GetScore()
    {
        return score;
    }

    public void temp(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            print("started");
        }
        if (value.canceled)
        {
            print("ended");
        }
    }
}
