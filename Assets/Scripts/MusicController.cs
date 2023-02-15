using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Linq;
using System;

public class MusicController : MonoBehaviour
{
    public AudioSource musicLayerRed;
    public AudioSource musicLayerBlue;
    public AudioSource musicLayerYellow;
    public AudioSource musicLayerGreen;
    public AudioSource musicLayerOrange;
    public AudioSource musicLayerPurple;

    [System.NonSerialized]
    public WaitForSeconds audioDurationWait = new WaitForSeconds(15.0f);

    public float longestTimePlayed;

    //these checks are passed to particle controller
    [System.NonSerialized]
    public bool redCheck = false;
    [System.NonSerialized]
    public bool blueCheck = false;
    [System.NonSerialized]
    public bool yellowCheck = false;
    [System.NonSerialized]
    public bool greenCheck = false;
    [System.NonSerialized]
    public bool orangeCheck = false;
    [System.NonSerialized]
    public bool purpleCheck = false;

    private Coroutine redAudioRoutine;
    private Coroutine blueAudioRoutine;
    private Coroutine yellowAudioRoutine;
    private Coroutine greenAudioRoutine;
    private Coroutine orangeAudioRoutine;
    private Coroutine purpleAudioRoutine;

    private Coroutine redTimerRoutine;
    private Coroutine blueTimerRoutine;
    private Coroutine yellowTimerRoutine;
    private Coroutine greenTimerRoutine;
    private Coroutine orangeTimerRoutine;
    private Coroutine purpleTimerRoutine;

    private float[] timeComparisonArray;
    private float greatestValue;

    private float redTotalTime = 0f;
    private float blueTotalTime = 0f;
    private float yellowTotalTime = 0f;
    private float greenTotalTime = 0f;
    private float orangeTotalTime = 0f;
    private float purpleTotalTime = 0f;

    private bool redTimerControl = false;
    private bool blueTimerControl = false;
    private bool yellowTimerControl = false;
    private bool greenTimerControl = false;
    private bool orangeTimerControl = false;
    private bool purpleTimerControl = false;


    // Start is called before the first frame update
    void Start()
    {
        timeComparisonArray = new float[6];
        musicLayerRed = GameObject.FindWithTag("RedSource").GetComponent<AudioSource>();
        musicLayerBlue = GameObject.FindWithTag("BlueSource").GetComponent<AudioSource>();
        musicLayerYellow = GameObject.FindWithTag("YellowSource").GetComponent<AudioSource>();
        musicLayerGreen = GameObject.FindWithTag("GreenSource").GetComponent<AudioSource>();
        musicLayerOrange = GameObject.FindWithTag("OrangeSource").GetComponent<AudioSource>();
        musicLayerPurple = GameObject.FindWithTag("PurpleSource").GetComponent<AudioSource>();
    }

    public void Update()
    {
        CheckTimesFindGreatest();
    }

    public void CheckTimesFindGreatest()
    {
        timeComparisonArray.SetValue(value: redTotalTime, index: 0);
        timeComparisonArray.SetValue(value: blueTotalTime, index: 1);
        timeComparisonArray.SetValue(value: yellowTotalTime, index: 2);
        timeComparisonArray.SetValue(value: greenTotalTime, index: 3);
        timeComparisonArray.SetValue(value: orangeTotalTime, index: 4);
        timeComparisonArray.SetValue(value: purpleTotalTime, index: 5);

        greatestValue = Mathf.Max(timeComparisonArray);
    }

    //start & stop a coroutine for each colour, it manages audio and an individual timer
    //also sync all audio to the longest a colour has played
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCube"))
        {
            musicLayerRed.time = greatestValue; //sync the audio using most played sound
            if (redAudioRoutine != null)
            {
                StopCoroutine(redAudioRoutine);
            }
            redAudioRoutine = StartCoroutine(RedStartStopAudio());
            if (redTimerRoutine != null)
            {
                StopCoroutine(redTimerRoutine);
            }
            redTimerRoutine = StartCoroutine(RedTimer());
        }
        if (collision.gameObject.CompareTag("BlueCube"))
        {
            musicLayerBlue.time = greatestValue;
            if (blueAudioRoutine != null)
            {
                StopCoroutine(blueAudioRoutine);
            }
            blueAudioRoutine = StartCoroutine(BlueStartStopAudio());
            if (blueTimerRoutine != null)
            {
                StopCoroutine(blueTimerRoutine);
            }
            blueTimerRoutine = StartCoroutine(BlueTimer());
        }
        if (collision.gameObject.CompareTag("YellowCube"))
        {
            musicLayerYellow.time = greatestValue;
            if (yellowAudioRoutine != null)
            {
                StopCoroutine(yellowAudioRoutine);
            }
            yellowAudioRoutine = StartCoroutine(YellowStartStopAudio());
            if (yellowTimerRoutine != null)
            {
                StopCoroutine(yellowTimerRoutine);
            }
            yellowTimerRoutine = StartCoroutine(YellowTimer());
        }
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            musicLayerGreen.time = greatestValue;
            if (greenAudioRoutine != null)
            {
                StopCoroutine(greenAudioRoutine);
            }
            greenAudioRoutine = StartCoroutine(GreenStartStopAudio());
            if (greenTimerRoutine != null)
            {
                StopCoroutine(greenTimerRoutine);
            }
            greenTimerRoutine = StartCoroutine(GreenTimer());
        }
        if (collision.gameObject.CompareTag("OrangeCube"))
        {
            musicLayerOrange.time = greatestValue;
            if (orangeAudioRoutine != null)
            {
                StopCoroutine(orangeAudioRoutine);
            }
            orangeAudioRoutine = StartCoroutine(OrangeStartStopAudio());
            if (orangeTimerRoutine != null)
            {
                StopCoroutine(orangeTimerRoutine);
            }
            orangeTimerRoutine = StartCoroutine(OrangeTimer());
        }
        if (collision.gameObject.CompareTag("PurpleCube"))
        {
            musicLayerPurple.time = greatestValue;
            if (purpleAudioRoutine != null)
            {
                StopCoroutine(purpleAudioRoutine);
            }
            purpleAudioRoutine = StartCoroutine(PurpleStartStopAudio());
            if (purpleTimerRoutine != null)
            {
                StopCoroutine(purpleTimerRoutine);
            }
            purpleTimerRoutine = StartCoroutine(PurpleTimer());
        }
    }

    //these coroutines manage how long the audio plays for
    //they also control when the timers start and stop
    //example: if a player touches a red tile once, then again after 5 seconds, the timer will
    //count for a total of 20 seconds (15+5)
    private IEnumerator RedStartStopAudio()
    {
        redCheck = true;
        redTimerControl = true;
        musicLayerRed.Play();
        yield return audioDurationWait;
        redCheck = false;
        redTimerControl = false;
        musicLayerRed.Stop();
    }
    private IEnumerator BlueStartStopAudio()
    {
        blueCheck = true;
        blueTimerControl = true;
        musicLayerBlue.Play();
        yield return audioDurationWait;
        blueCheck = false;
        blueTimerControl = true;
        musicLayerBlue.Stop();
    }
    private IEnumerator YellowStartStopAudio()
    {
        yellowCheck = true;
        yellowTimerControl = true;
        musicLayerYellow.Play();
        yield return audioDurationWait;
        yellowCheck = false;
        yellowTimerControl = false;
        musicLayerYellow.Stop();
    }
    private IEnumerator GreenStartStopAudio()
    {
        greenCheck = true;
        greenTimerControl = true;
        musicLayerGreen.Play();
        yield return audioDurationWait;
        greenCheck = false;
        greenTimerControl = false;
        musicLayerGreen.Stop();
    }
    private IEnumerator OrangeStartStopAudio()
    {
        orangeCheck = true;
        orangeTimerControl = true;
        musicLayerOrange.Play();
        yield return audioDurationWait;
        orangeCheck = false;
        orangeTimerControl = false;
        musicLayerOrange.Stop();
    }
    private IEnumerator PurpleStartStopAudio()
    {
        purpleCheck = true;
        purpleTimerControl = true;
        musicLayerPurple.Play();
        yield return audioDurationWait;
        purpleCheck = false;
        purpleTimerControl = false;
        musicLayerPurple.Stop();
    }

    //the following are seven timers used to track total duration audio has played for, for each colour tile
    public IEnumerator RedTimer()
    {
        while (redTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            redTotalTime++;
        }
    }
    public IEnumerator BlueTimer()
    {
        while (blueTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            blueTotalTime++;
        }
    }
    public IEnumerator YellowTimer()
    {
        while (yellowTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            yellowTotalTime++;
        }
    }
    public IEnumerator GreenTimer()
    {
        while (greenTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            greenTotalTime++;
        }
    }
    public IEnumerator OrangeTimer()
    {
        while (orangeTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            orangeTotalTime++;
        }
    }
    public IEnumerator PurpleTimer()
    {
        while (purpleTimerControl == true)
        {
            yield return new WaitForSeconds(1);
            purpleTotalTime++;
        }
    }

    //this can be used to play all audio sources on same gameobject:
    //Audiosource.PlayOneShot();
}