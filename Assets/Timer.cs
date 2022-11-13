using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public TextMeshProUGUI timerText;
    //        TextMeshProUGUI timerText;

    public float currentTime;
    // public bool countDown;

    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();


    public bool playing;
    public bool speechEnd;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {


        playing = true;
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.Tenths, "00:0");
        timeFormats.Add(TimerFormats.Hunds, "00:00");
    }

    // Update is called once per frame
    void Update()
    {

        if (playing == true)
        {
            currentTime = currentTime += Time.deltaTime;

            string minutes = Mathf.Floor((currentTime % 3600) / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");

            timerText.text = minutes + ":" + seconds;

            //    setTimerText();
            //        timerText.text = currentTime.ToString();
        }
    }

    private void setTimerText()
    {
        timerText.text = hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }


    public void ClickPlay()
    {
        playing = true;
    }

    public void ClickStop()
    {
        playing = false;
        //speechEnd = true;
        anim.SetBool("speechEnd", true);
    }
}

public enum TimerFormats
{
    Whole,
    Tenths,
    Hunds
}
