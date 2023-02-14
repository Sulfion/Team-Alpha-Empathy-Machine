using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WristHUDManager : MonoBehaviour
{
    public MusicController musicController;

    private TextMeshProUGUI _text;


    // Start is called before the first frame update
    void Start()
    {
        musicController = GameObject.FindWithTag("Player").GetComponent<MusicController>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        UpdateWristText();
    }

    //this starts/updates the wrist HUD timers each time there is a collision
    private void UpdateWristText()
    {
        if (this._text.CompareTag("RedTimer"))
        {
            _text.text = musicController.redTimer.ToString("f0");
        }
        if (this._text.CompareTag("BlueTimer"))
        {
            _text.text = musicController.blueTimer.ToString("f0");
        }
        if (this._text.CompareTag("YellowTimer"))
        {
            _text.text = musicController.yellowTimer.ToString("f0");
        }
        if (this._text.CompareTag("GreenTimer"))
        {
            _text.text = musicController.greenTimer.ToString("f0");
        }
        if (this._text.CompareTag("OrangeTimer"))
        {
            _text.text = musicController.orangeTimer.ToString("f0");
        }
        if (this._text.CompareTag("PurpleTimer"))
        {
            _text.text = musicController.purpleTimer.ToString("f0");
        }
    }
}
