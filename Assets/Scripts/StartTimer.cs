using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    float timer = 0;
    float bestTime;
    bool started = false;

    public Text current;
    public Text best;

    void Update()
    {
        if(started)
        {
            timer += Time.deltaTime;
            current.text = timer.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(started == false)
            {
                started = true;
            }
            else
            {
                if (bestTime > timer)
                {
                    bestTime = timer;
                    best.text = bestTime.ToString();
                }
                timer = 0;
            }
        }
    }
}
