using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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

    public float audioDuration = 15.0f;

    public float timePlayed;

    private bool redBool = false;
    private bool blueBool = false;
    private bool yellowBool = false;
    private bool greenBool = false;
    private bool orangeBool = false;
    private bool purpleBool = false;

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

    //create timers for wrist HUD tracker
    [System.NonSerialized]
    public float redTimer = 0f;
    [System.NonSerialized]
    public float blueTimer = 0f;
    [System.NonSerialized]
    public float yellowTimer = 0f;
    [System.NonSerialized]
    public float greenTimer = 0f;
    [System.NonSerialized]
    public float orangeTimer = 0f;
    [System.NonSerialized]
    public float purpleTimer = 0f;

    private bool setAudioTimeOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        musicLayerRed = GameObject.FindWithTag("RedSource").GetComponent<AudioSource>();
        musicLayerBlue = GameObject.FindWithTag("BlueSource").GetComponent<AudioSource>();
        musicLayerYellow = GameObject.FindWithTag("YellowSource").GetComponent<AudioSource>();
        musicLayerGreen = GameObject.FindWithTag("GreenSource").GetComponent<AudioSource>();
        musicLayerOrange = GameObject.FindWithTag("OrangeSource").GetComponent<AudioSource>();
        musicLayerPurple = GameObject.FindWithTag("PurpleSource").GetComponent<AudioSource>();
    }

    public void Update()
    {
        ElapsedMusicDuration();
    }

    //use the total time any part of the audio has played to sync all audio to that time
    public void ElapsedMusicDuration()
    {
        if (redBool == true || blueBool == true || yellowBool == true || greenBool == true || orangeBool == true || purpleBool == true)
        {
            if (setAudioTimeOnce == false)
            {
                setAudioTimeOnce = true;
                musicLayerRed.time = timePlayed;
                musicLayerBlue.time = timePlayed;
                musicLayerYellow.time = timePlayed;
                musicLayerGreen.time = timePlayed;
                musicLayerOrange.time = timePlayed;
                musicLayerPurple.time = timePlayed;
            }
            timePlayed += Time.deltaTime; //keep track of how long a colour has played for
        }
    }

    //when the player collids with a specific colour, play the audio for that colour
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCube"))
        {
            redCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
        if (collision.gameObject.CompareTag("BlueCube"))
        {
            blueCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
        if (collision.gameObject.CompareTag("YellowCube"))
        {
            yellowCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            greenCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
        if (collision.gameObject.CompareTag("OrangeCube"))
        {
            orangeCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
        if (collision.gameObject.CompareTag("PurpleCube"))
        {
            purpleCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
    }

    //timers passed to wristHUD to track remaining audio duration
    public IEnumerator RedTimer()
    {
        redTimer = 15.0f;
        while (redCheck == true)
        {
            redTimer -= Time.deltaTime;
            if (redTimer <= 0)
            {
                redTimer = 0f;
            }
            yield return null;
        }  
    }
    public IEnumerator BlueTimer()
    {
        blueTimer = 15.0f;
        while (blueCheck == true)
        {
            blueTimer -= Time.deltaTime;
            if (blueTimer <= 0)
            {
                blueTimer = 0f;
            }
            yield return null;
        }
    }
    public IEnumerator YellowTimer()
    {
        yellowTimer = 15.0f;
        while (yellowCheck == true)
        {
            yellowTimer -= Time.deltaTime;
            if (yellowTimer <= 0)
            {
                yellowTimer = 0f;
            }
            yield return null;
        }
    }
    public IEnumerator GreenTimer()
    {
        greenTimer = 15.0f;
        while (greenCheck == true)
        {
            greenTimer -= Time.deltaTime;
            if (greenTimer <= 0)
            {
                greenTimer = 0f;
            }
            yield return null;
        }
    }
    public IEnumerator OrangeTimer()
    {
        orangeTimer = 15.0f;
        while (orangeCheck == true)
        {
            orangeTimer -= Time.deltaTime;
            if (orangeTimer <= 0)
            {
                orangeTimer = 0f;
            }
            yield return null;
        }
    }
    public IEnumerator PurpleTimer()
    {
        purpleTimer = 15.0f;
        while (purpleCheck == true)
        {
            purpleTimer -= Time.deltaTime;
            if (purpleTimer <= 0)
            {
                purpleTimer = 0f;
            }
            yield return null;
        }
    }

    //stop the same audio from playing multiple times, control the how long each audio clip will play, and play the audio
    private IEnumerator StartStopPlayingAudio()
    {
        if (redCheck == true && redBool == false)
        {
            StartCoroutine(RedTimer());
            setAudioTimeOnce = false;
            redBool = true;
            musicLayerRed.Play();
            yield return audioDurationWait;
            musicLayerRed.Stop();
            redCheck = false;
            redBool = false;
        }
        if (blueCheck == true && blueBool == false)
        {
            StartCoroutine(BlueTimer());
            setAudioTimeOnce = false;
            blueBool = true;
            musicLayerBlue.Play();
            yield return audioDurationWait;
            musicLayerBlue.Stop();
            blueCheck = false;
            blueBool = false;
        }
        if (yellowCheck == true && yellowBool == false)
        {
            StartCoroutine(YellowTimer());
            setAudioTimeOnce = false;
            yellowBool = true;
            musicLayerYellow.Play();
            yield return audioDurationWait;
            musicLayerYellow.Stop();
            yellowCheck = false;
            yellowBool = false;
        }
        if (greenCheck == true && greenBool == false)
        {
            StartCoroutine(GreenTimer());
            setAudioTimeOnce = false;
            greenBool = true;
            musicLayerGreen.Play();
            yield return audioDurationWait;
            musicLayerGreen.Stop();
            greenCheck = false;
            greenBool = false;
        }
        if (orangeCheck == true && orangeBool == false)
        {
            StartCoroutine(OrangeTimer());
            setAudioTimeOnce = false;
            orangeBool = true;
            musicLayerOrange.Play();
            yield return audioDurationWait;
            musicLayerOrange.Stop();
            orangeCheck = false;
            orangeBool = false;
        }
        if (purpleCheck == true && purpleBool == false)
        {
            StartCoroutine(PurpleTimer());
            setAudioTimeOnce = false;
            purpleBool = true;
            musicLayerPurple.Play();
            yield return audioDurationWait;
            musicLayerPurple.Stop();
            purpleCheck = false;
            purpleBool = false;
        }
    }
    //this can be used to play all audio sources on same gameobject:
    //Audiosource.PlayOneShot();
}