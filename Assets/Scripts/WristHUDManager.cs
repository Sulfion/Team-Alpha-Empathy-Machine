using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WristHUDManager : MonoBehaviour
{

    public TextMeshProUGUI _text;
    
    private static float redSecondsLeft;
    private static float blueSecondsLeft;
    private static float yellowSecondsLeft;
    private static float greenSecondsLeft;
    private static float orangeSecondsLeft;
    private static float purpleSecondsLeft;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        
    }

    private void Update()
    {
        GetSecondsLeftFromTimers();
        UpdateWristText();
    }

    public void GetSecondsLeftFromTimers()
    {
        redSecondsLeft = TimerManager.redSecondsLeft;
        blueSecondsLeft = TimerManager.blueSecondsLeft;
        yellowSecondsLeft = TimerManager.yellowSecondsLeft;
        greenSecondsLeft = TimerManager.greenSecondsLeft;
        orangeSecondsLeft = TimerManager.orangeSecondsLeft;
        purpleSecondsLeft = TimerManager.purpleSecondsLeft;
    }


    //this starts/updates the wrist HUD timers each time there is a collision
    private void UpdateWristText()
    {
        if (this._text.CompareTag("RedTimer"))
        {
            _text.text = redSecondsLeft.ToString("f0");
        }
        if (this._text.CompareTag("BlueTimer"))
        {
            _text.text = blueSecondsLeft.ToString("f0");
        }
        if (this._text.CompareTag("YellowTimer"))
        {
            _text.text = yellowSecondsLeft.ToString("f0");
        }
        if (this._text.CompareTag("GreenTimer"))
        {
            _text.text = greenSecondsLeft.ToString("f0");
        }
        if (this._text.CompareTag("OrangeTimer"))
        {
            _text.text = orangeSecondsLeft.ToString("f0");
        }
        if (this._text.CompareTag("PurpleTimer"))
        {
            _text.text = purpleSecondsLeft.ToString("f0");
        }
    }
}
