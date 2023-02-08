using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicLayerOne;

    public float audioDuration = 10.0f;
    public bool redBool = false;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<AudioSource>().clip = musicLayerOne;
        musicLayerOne = GetComponent<AudioSource>();
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
            StartCoroutine(StartStopPlayingAudio());
        }
    }

    //stop the same audio from playing multiple times, control the how long each audio clip will play, and play the audio
    private IEnumerator StartStopPlayingAudio()
    {
        if (redBool == false)
        {
            redBool = true;
            musicLayerOne.Play();
            yield return new WaitForSeconds(audioDuration);
            musicLayerOne.Stop();
            redBool = false;
        }
    }

    //this can be used to play all audio sources on same gameobject with:
    //Audiosource.PlayOneShot();
}