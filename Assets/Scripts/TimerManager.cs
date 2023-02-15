using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [System.NonSerialized]
    public int redSecondsLeft;
    [System.NonSerialized]
    public int blueSecondsLeft;
    [System.NonSerialized]
    public int yellowSecondsLeft;
    [System.NonSerialized]
    public int greenSecondsLeft;
    [System.NonSerialized]
    public int orangeSecondsLeft;
    [System.NonSerialized]
    public int purpleSecondsLeft;

    //each coroutine has a unique ID and must be stored in order to be stopped
    private Coroutine redTimerRoutine;
    private Coroutine blueTimerRoutine;
    private Coroutine yellowTimerRoutine;
    private Coroutine greenTimerRoutine;
    private Coroutine orangeTimerRoutine;
    private Coroutine purpleTimerRoutine;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(redSecondsLeft.ToString("f0") + " this is TimerManager red timer");
    }

    //check if another routine for the colour has been started
    //if it has, stop that routine
    //then start a new routine and store its ID
    public void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("RedCube"))
        {
            if (redTimerRoutine != null)
            {
                StopCoroutine(redTimerRoutine);
            }
            redTimerRoutine = StartCoroutine(RedTimer());
        }
        if (this.gameObject.CompareTag("BlueCube"))
        {
            if (blueTimerRoutine != null)
            {
                StopCoroutine(blueTimerRoutine);
            }
            blueTimerRoutine = StartCoroutine(BlueTimer());
        }
        if (this.gameObject.CompareTag("YellowCube"))
        {
            if (yellowTimerRoutine != null)
            {
                StopCoroutine(yellowTimerRoutine);
            }
            yellowTimerRoutine = StartCoroutine(YellowTimer());
        }
        if (this.gameObject.CompareTag("GreenCube"))
        {
            if (greenTimerRoutine != null)
            {
                StopCoroutine(greenTimerRoutine);
            }
            greenTimerRoutine = StartCoroutine(GreenTimer());
        }
        if (this.gameObject.CompareTag("OrangeCube"))
        {
            if (orangeTimerRoutine != null)
            {
                StopCoroutine(orangeTimerRoutine);
            }
            orangeTimerRoutine = StartCoroutine(OrangeTimer());
        }
        if (this.gameObject.CompareTag("PurpleCube"))
        {
            if (purpleTimerRoutine != null)
            {
                StopCoroutine(purpleTimerRoutine);
            }
            purpleTimerRoutine = StartCoroutine(PurpleTimer());
        }
    }

    //the following seven routines are used to manage a separate timer for each colour
    //having them together led to erroneous behavior
    public IEnumerator RedTimer()
    {
        redSecondsLeft = 15;
        while (redSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            redSecondsLeft--;
        }
    }
    public IEnumerator BlueTimer()
    {
        blueSecondsLeft = 15;
        while (blueSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            blueSecondsLeft--;
        }
    }
    public IEnumerator YellowTimer()
    {
        yellowSecondsLeft = 15;
        while (yellowSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            yellowSecondsLeft--;
        }
    }
    public IEnumerator GreenTimer()
    {
        greenSecondsLeft = 15;
        while (greenSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            greenSecondsLeft--;
        }
    }
    public IEnumerator OrangeTimer()
    {
        orangeSecondsLeft = 15;
        while (orangeSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            orangeSecondsLeft--;
        }
    }
    public IEnumerator PurpleTimer()
    {
        purpleSecondsLeft = 15;
        while (purpleSecondsLeft > 0)
        {
            yield return new WaitForSeconds(1);
            purpleSecondsLeft--;
        }
    }
}
