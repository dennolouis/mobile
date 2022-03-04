using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{

    public GameObject[] obj;
    public float speed = 2;
    public float rate = 0.4f;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI bestUI;

    int score = 0;
    int best = 100;

    private void Awake()
    {
        bestUI.text = "Best: " + best.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    void Init()
    {
        Invoke("Init", speed);
        
        CreateObsticle();
        HandleScore();
        HandleSpeed();
    }

    public int GetScore()
    {
        return score;
    }

    void HandleScore()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
        if (score > best)
        {
            best = score;
            bestUI.text = "Best: " + best.ToString();
        }
    
    }

    void CreateObsticle()
    {
        GameObject obsticle = Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
        Destroy(obsticle, speed + 1);
    }

    void HandleSpeed()
    {
        if (speed > 0.8)
            speed -= rate * Time.deltaTime;
    }
}
