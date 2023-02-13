using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public MusicController musicController;

    public GameObject[] redCubeObjects;
    public GameObject[] blueCubeObjects;
    public GameObject[] yellowCubeObjects;
    public GameObject[] greenCubeObjects;
    public GameObject[] orangeCubeObjects;
    public GameObject[] purpleCubeObjects;
    public GameObject[] brownCubeObjects;

    public ParticleSystem[] particleSysRed;
    public ParticleSystem[] particleSysBlue;
    public ParticleSystem[] particleSysYellow;
    public ParticleSystem[] particleSysGreen;
    public ParticleSystem[] particleSysOrange;
    public ParticleSystem[] particleSysPurple;
    public ParticleSystem[] particleSysBrown;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindGameObjectsAfterInstantiated());
    }

    //this waits until all objects are instantiated before checking them, otherwise some objects will be missed
    public IEnumerator FindGameObjectsAfterInstantiated()
    {
        yield return new WaitForSeconds(6.0f);

        musicController = GameObject.FindWithTag("Player").GetComponent<MusicController>();

        redCubeObjects = GameObject.FindGameObjectsWithTag("RedCube");
        blueCubeObjects = GameObject.FindGameObjectsWithTag("BlueCube");
        yellowCubeObjects = GameObject.FindGameObjectsWithTag("YellowCube");
        greenCubeObjects = GameObject.FindGameObjectsWithTag("GreenCube");
        orangeCubeObjects = GameObject.FindGameObjectsWithTag("OrangeCube");
        purpleCubeObjects = GameObject.FindGameObjectsWithTag("PurpleCube");
        brownCubeObjects = GameObject.FindGameObjectsWithTag("BrownCube");

        particleSysRed = new ParticleSystem[redCubeObjects.Length];
        particleSysBlue = new ParticleSystem[blueCubeObjects.Length];
        particleSysYellow = new ParticleSystem[yellowCubeObjects.Length];
        particleSysGreen = new ParticleSystem[greenCubeObjects.Length];
        particleSysOrange = new ParticleSystem[orangeCubeObjects.Length];
        particleSysPurple = new ParticleSystem[purpleCubeObjects.Length];
        particleSysBrown = new ParticleSystem[brownCubeObjects.Length];

        GetParticleSystems();
    }

    //get all particle systems on all coloured cubes and assign them to appropriate array
    public void GetParticleSystems()
    {
        for (int i = 0; i < redCubeObjects.Length; i++)
        {
            particleSysRed[i] = redCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < blueCubeObjects.Length; i++)
        {
            particleSysBlue[i] = blueCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < yellowCubeObjects.Length; i++)
        {
            particleSysYellow[i] = yellowCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < greenCubeObjects.Length; i++)
        {
            particleSysGreen[i] = greenCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < orangeCubeObjects.Length; i++)
        {
            particleSysOrange[i] = orangeCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < purpleCubeObjects.Length; i++)
        {
            particleSysPurple[i] = purpleCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
        for (int i = 0; i < brownCubeObjects.Length; i++)
        {
            particleSysBrown[i] = brownCubeObjects[i].GetComponentInChildren<ParticleSystem>();
        }
    }

    //check which cube has collided with and run disable method for that colour of cube
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.tag == "RedCube")
            {
                foreach (GameObject gameObjects in redCubeObjects)
                {
                    StartCoroutine(StartStopRedParticles());
                }
            }
            if (this.gameObject.tag == "BlueCube")
            {
                foreach (GameObject gameObjects in blueCubeObjects)
                {
                    StartCoroutine(StartStopBlueParticles());
                }
            }
            if (this.gameObject.tag == "YellowCube")
            {
                foreach (GameObject gameObjects in yellowCubeObjects)
                {
                    StartCoroutine(StartStopYellowParticles());
                }
            }
            if (this.gameObject.tag == "GreenCube")
            {
                foreach (GameObject gameObjects in greenCubeObjects)
                {
                    StartCoroutine(StartStopGreenParticles());
                }
            }
            if (this.gameObject.tag == "OrangeCube")
            {
                foreach (GameObject gameObjects in orangeCubeObjects)
                {
                    StartCoroutine(StartStopOrangeParticles());
                }
            }
            if (this.gameObject.tag == "PurpleCube")
            {
                foreach (GameObject gameObjects in purpleCubeObjects)
                {
                    StartCoroutine(StartStopPurpleParticles());
                }
            }
            if (this.gameObject.tag == "BrownCube")
            {
                foreach (GameObject gameObjects in brownCubeObjects)
                {
                    StartCoroutine(StartStopBrownParticles());
                }
            }
        }
    }


    //the following seven coroutines stop/restart the assigned colours particles
    //they are divided separately as having them all together led to erroneous behavior
    public IEnumerator StartStopRedParticles()
    {
        if (musicController.redCheck == true)
        {
            for (int i = 0; i < particleSysRed.Length; i++)
            {
                particleSysRed[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysRed.Length; i++)
            {
                particleSysRed[i].Play();
            }
        }
    }

    public IEnumerator StartStopBlueParticles()
    {
        if (musicController.blueCheck == true)
        {
            for (int i = 0; i < particleSysBlue.Length; i++)
            {
                particleSysBlue[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysBlue.Length; i++)
            {
                particleSysBlue[i].Play();
            }
        }
    }

    public IEnumerator StartStopYellowParticles()
    {
        if (musicController.yellowCheck == true)
        {
            for (int i = 0; i < particleSysYellow.Length; i++)
            {
                particleSysYellow[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysYellow.Length; i++)
            {
                particleSysYellow[i].Play();
            }
        }
    }

    public IEnumerator StartStopGreenParticles()
    {
        if (musicController.greenCheck == true)
        {
            for (int i = 0; i < particleSysGreen.Length; i++)
            {
                particleSysGreen[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysGreen.Length; i++)
            {
                particleSysGreen[i].Play();
            }
        }
    }

    public IEnumerator StartStopOrangeParticles()
    {
        if (musicController.orangeCheck == true)
        {
            for (int i = 0; i < particleSysOrange.Length; i++)
            {
                particleSysOrange[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysOrange.Length; i++)
            {
                particleSysOrange[i].Play();
            }
        }
    }

    public IEnumerator StartStopPurpleParticles()
    {
        if (musicController.purpleCheck == true)
        {
            for (int i = 0; i < particleSysPurple.Length; i++)
            {
                particleSysPurple[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysPurple.Length; i++)
            {
                particleSysPurple[i].Play();
            }
        }
    }

    public IEnumerator StartStopBrownParticles()
    {
        if (musicController.brownCheck == true)
        {
            for (int i = 0; i < particleSysBrown.Length; i++)
            {
                particleSysBrown[i].Stop();
            }
            yield return new WaitForSeconds(musicController.audioDuration);
            for (int i = 0; i < particleSysBrown.Length; i++)
            {
                particleSysBrown[i].Play();
            }
        }
    }
}
