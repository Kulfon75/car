using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    private float timer = 0;
    private float bestTime = 9999;
    private bool started = false;

    public Text current;
    public Text best;

    private void Start()
    {
        current = GameObject.Find("TimeCurrent").GetComponent<Text>();
        best = GameObject.Find("TimeBest").GetComponent<Text>();
    }
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
