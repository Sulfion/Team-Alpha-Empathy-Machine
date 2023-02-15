using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WristHUDManager : MonoBehaviour
{

    public TextMeshProUGUI _text;

    public GameObject redTimeManager;
    //public TimerManager timerManager;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        //timerManager = GetComponent<TimerManager>(); //the variables here aren't being updated, it is staying at 0
    }

    private void Update()
    {
        UpdateWristText();
        //Debug.Log(timerManager.redTimer.ToString("f0") + " this is wristHUD red timer");
    }

    //this starts/updates the wrist HUD timers each time there is a collision
    private void UpdateWristText()
    {
        if (this._text.CompareTag("RedTimer"))
        {
            //_text.text = timerManager.redTimer.ToString("f0");
        }
        if (this._text.CompareTag("BlueTimer"))
        {
            //_text.text = timerManager.blueTimer.ToString("f0");
        }
        if (this._text.CompareTag("YellowTimer"))
        {
            //_text.text = timerManager.yellowTimer.ToString("f0");
        }
        if (this._text.CompareTag("GreenTimer"))
        {
            //_text.text = timerManager.greenTimer.ToString("f0");
        }
        if (this._text.CompareTag("OrangeTimer"))
        {
            //_text.text = timerManager.orangeTimer.ToString("f0");
        }
        if (this._text.CompareTag("PurpleTimer"))
        {
            //_text.text = timerManager.purpleTimer.ToString("f0");
        }
    }
}
