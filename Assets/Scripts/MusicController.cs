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

    public float timePlayed;

    //private bool redBool = false;
    //private bool blueBool = false;
    //private bool yellowBool = false;
    //private bool greenBool = false;
    //private bool orangeBool = false;
    //private bool purpleBool = false;

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

    //private bool setAudioTimeOnce = false;

    private Coroutine redAudioRoutine;
    private Coroutine blueAudioRoutine;
    private Coroutine yellowAudioRoutine;
    private Coroutine greenAudioRoutine;
    private Coroutine orangeAudioRoutine;
    private Coroutine purpleAudioRoutine;

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
        //ElapsedMusicDuration();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCube"))
        {
            if (redAudioRoutine != null)
            {
                StopCoroutine(redAudioRoutine);
            }
            redAudioRoutine = StartCoroutine(RedStartStopAudio());
        }
        if (collision.gameObject.CompareTag("BlueCube"))
        {
            if (blueAudioRoutine != null)
            {
                StopCoroutine(blueAudioRoutine);
            }
            blueAudioRoutine = StartCoroutine(BlueStartStopAudio());
        }
        if (collision.gameObject.CompareTag("YellowCube"))
        {
            if (yellowAudioRoutine != null)
            {
                StopCoroutine(yellowAudioRoutine);
            }
            yellowAudioRoutine = StartCoroutine(YellowStartStopAudio());
        }
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            if (greenAudioRoutine != null)
            {
                StopCoroutine(greenAudioRoutine);
            }
            greenAudioRoutine = StartCoroutine(GreenStartStopAudio());
        }
        if (collision.gameObject.CompareTag("OrangeCube"))
        {
            if (orangeAudioRoutine != null)
            {
                StopCoroutine(orangeAudioRoutine);
            }
            orangeAudioRoutine = StartCoroutine(OrangeStartStopAudio());
        }
        if (collision.gameObject.CompareTag("PurpleCube"))
        {
            if (purpleAudioRoutine != null)
            {
                StopCoroutine(purpleAudioRoutine);
            }
            purpleAudioRoutine = StartCoroutine(PurpleStartStopAudio());
        }
    }

    private IEnumerator RedStartStopAudio()
    {
        musicLayerRed.Play();
        yield return audioDurationWait;
        musicLayerRed.Stop();
    }
    private IEnumerator BlueStartStopAudio()
    {
        musicLayerBlue.Play();
        yield return audioDurationWait;
        musicLayerBlue.Stop();
    }
    private IEnumerator YellowStartStopAudio()
    {
        musicLayerYellow.Play();
        yield return audioDurationWait;
        musicLayerYellow.Stop();
    }
    private IEnumerator GreenStartStopAudio()
    {
        musicLayerGreen.Play();
        yield return audioDurationWait;
        musicLayerGreen.Stop();
    }
    private IEnumerator OrangeStartStopAudio()
    {
        musicLayerOrange.Play();
        yield return audioDurationWait;
        musicLayerOrange.Stop();
    }
    private IEnumerator PurpleStartStopAudio()
    {
        musicLayerPurple.Play();
        yield return audioDurationWait;
        musicLayerPurple.Stop();
    }

    ////when the player collids with a specific colour, play the audio for that colour
    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("RedCube"))
    //    {
    //        redCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //    if (collision.gameObject.CompareTag("BlueCube"))
    //    {
    //        blueCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //    if (collision.gameObject.CompareTag("YellowCube"))
    //    {
    //        yellowCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //    if (collision.gameObject.CompareTag("GreenCube"))
    //    {
    //        greenCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //    if (collision.gameObject.CompareTag("OrangeCube"))
    //    {
    //        orangeCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //    if (collision.gameObject.CompareTag("PurpleCube"))
    //    {
    //        purpleCheck = true;
    //        StartCoroutine(StartStopPlayingAudio());
    //    }
    //}

    ////stop the same audio from playing multiple times, control the how long each audio clip will play, and play the audio
    //private IEnumerator StartStopPlayingAudio()
    //{
    //    setAudioTimeOnce = false;
    //    if (redCheck == true && redBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        redBool = true;
    //        musicLayerRed.Play();
    //        yield return audioDurationWait;
    //        musicLayerRed.Stop();
    //        redCheck = false;
    //        redBool = false;
    //    }
    //    if (blueCheck == true && blueBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        blueBool = true;
    //        musicLayerBlue.Play();
    //        yield return audioDurationWait;
    //        musicLayerBlue.Stop();
    //        blueCheck = false;
    //        blueBool = false;
    //    }
    //    if (yellowCheck == true && yellowBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        yellowBool = true;
    //        musicLayerYellow.Play();
    //        yield return audioDurationWait;
    //        musicLayerYellow.Stop();
    //        yellowCheck = false;
    //        yellowBool = false;
    //    }
    //    if (greenCheck == true && greenBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        greenBool = true;
    //        musicLayerGreen.Play();
    //        yield return audioDurationWait;
    //        musicLayerGreen.Stop();
    //        greenCheck = false;
    //        greenBool = false;
    //    }
    //    if (orangeCheck == true && orangeBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        orangeBool = true;
    //        musicLayerOrange.Play();
    //        yield return audioDurationWait;
    //        musicLayerOrange.Stop();
    //        orangeCheck = false;
    //        orangeBool = false;
    //    }
    //    if (purpleCheck == true && purpleBool == false)
    //    {
    //        setAudioTimeOnce = false;
    //        purpleBool = true;
    //        musicLayerPurple.Play();
    //        yield return audioDurationWait;
    //        musicLayerPurple.Stop();
    //        purpleCheck = false;
    //        purpleBool = false;
    //    }
    //}
    ////this can be used to play all audio sources on same gameobject:
    ////Audiosource.PlayOneShot();


    ////use the total time any part of the audio has played to sync all audio to that time
    //public void ElapsedMusicDuration()
    //{
    //    if (redBool == true || blueBool == true || yellowBool == true || greenBool == true || orangeBool == true || purpleBool == true)
    //    {
    //        if (setAudioTimeOnce == false)
    //        {
    //            setAudioTimeOnce = true;
    //            musicLayerRed.time = timePlayed;
    //            musicLayerBlue.time = timePlayed;
    //            musicLayerYellow.time = timePlayed;
    //            musicLayerGreen.time = timePlayed;
    //            musicLayerOrange.time = timePlayed;
    //            musicLayerPurple.time = timePlayed;
    //        }
    //        timePlayed += Time.deltaTime; //keep track of how long a colour has played for
    //    }
    //}
}