using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicLayerRed;
    public AudioSource musicLayerBlue;
    public AudioSource musicLayerYellow;
    public AudioSource musicLayerGreen;
    public AudioSource musicLayerOrange;
    public AudioSource musicLayerPurple;
    public AudioSource musicLayerBrown;

    public float audioDuration = 10.0f;

    public bool redBool = false;
    public bool blueBool = false;
    public bool yellowBool = false;
    public bool greenBool = false;
    public bool orangeBool = false;
    public bool purpleBool = false;
    public bool brownBool = false;

    public bool redCheck = false;
    public bool blueCheck = false;
    public bool yellowCheck = false;
    public bool greenCheck = false;
    public bool orangeCheck = false;
    public bool purpleCheck = false;
    public bool brownCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        musicLayerRed = GetComponent<AudioSource>();
        musicLayerBlue = GetComponent<AudioSource>();
        musicLayerYellow = GetComponent<AudioSource>();
        musicLayerGreen = GetComponent<AudioSource>();
        musicLayerOrange = GetComponent<AudioSource>();
        musicLayerPurple = GetComponent<AudioSource>();
        musicLayerBrown = GetComponent<AudioSource>();
    }

    public void Update()
    {
        //Debug.Log(redBool);
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
        if (collision.gameObject.CompareTag("BrownCube"))
        {
            brownCheck = true;
            StartCoroutine(StartStopPlayingAudio());
        }
    }

    //stop the same audio from playing multiple times, control the how long each audio clip will play, and play the audio
    private IEnumerator StartStopPlayingAudio()
    {
        if (redCheck == true && redBool == false)
        {
            redBool = true;
            musicLayerRed.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerRed.Stop();
            redCheck = false;
            redBool = false;
        }
        if (blueCheck == true && blueBool == false)
        {
            blueBool = true;
            musicLayerBlue.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerBlue.Stop();
            blueCheck = false;
            blueBool = false;
        }
        if (yellowCheck == true && yellowBool == false)
        {
            yellowBool = true;
            musicLayerYellow.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerYellow.Stop();
            yellowCheck = false;
            yellowBool = false;
        }
        if (greenCheck == true && greenBool == false)
        {
            greenBool = true;
            musicLayerGreen.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerGreen.Stop();
            greenCheck = false;
            greenBool = false;
        }
        if (orangeCheck == true && orangeBool == false)
        {
            orangeBool = true;
            musicLayerOrange.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerOrange.Stop();
            orangeCheck = false;
            orangeBool = false;
        }
        if (purpleCheck == true && purpleBool == false)
        {
            purpleBool = true;
            musicLayerPurple.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerPurple.Stop();
            purpleCheck = false;
            purpleBool = false;
        }
        if (brownCheck == true && brownBool == false)
        {
            brownBool = true;
            musicLayerBrown.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerBrown.Stop();
            brownCheck = false;
            brownBool = false;
        }
    }

    //this can be used to play all audio sources on same gameobject with:
    //Audiosource.PlayOneShot();
}