using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContinueTimer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    int time = 5;
    // Start is called before the first frame update
    void Start()
    {
        timer.text = time.ToString();
        Invoker.InvokeDelayed(Decrement, 1);
    }

    public void Decrement()
    {
        if(time == 0)
        {
            return;
        }
        time--;
        timer.text = time.ToString();
        Invoker.InvokeDelayed(Decrement, 1);
    }
}
