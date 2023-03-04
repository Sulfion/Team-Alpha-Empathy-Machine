//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;

//public class WristHUDManager : TimerManager
//{

//    public TextMeshProUGUI _text;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _text = GetComponent<TextMeshProUGUI>();
//    }

//    void Update()
//    {
//        //UpdateWristText();
//        Debug.Log(redSecondsLeft.ToString("f0") + " this is the HUD red timer");
//    }


//    //this starts/updates the wrist HUD timers each time there is a collision
//    private void UpdateWristText()
//    {
//        if (this._text.CompareTag("RedTimer"))
//        {
//            //_text.text = redSecondsLeft.ToString("f0");
//        }
//        if (this._text.CompareTag("BlueTimer"))
//        {
//            //_text.text = blueSecondsLeft.ToString("f0");
//        }
//        if (this._text.CompareTag("YellowTimer"))
//        {
//            //_text.text = yellowSecondsLeft.ToString("f0");
//        }
//        if (this._text.CompareTag("GreenTimer"))
//        {
//            //_text.text = greenSecondsLeft.ToString("f0");
//        }
//        if (this._text.CompareTag("OrangeTimer"))
//        {
//            //_text.text = orangeSecondsLeft.ToString("f0");
//        }
//        if (this._text.CompareTag("PurpleTimer"))
//        {
//            //_text.text = purpleSecondsLeft.ToString("f0");
//        }
//    }
//}
