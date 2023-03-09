using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMusicTimer : MonoBehaviour
{

    public GameObject[] redCubes;
    public GameObject[] blueCubes;
    public GameObject[] yellowCubes;
    public GameObject[] greenCubes;
    public GameObject[] orangeCubes;
    public GameObject[] purpleCubes;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StopCubeTimer();
        RemoveCubeAfterTime();

        redCubes = GameObject.FindGameObjectsWithTag("RedCube"); //store all cubes in their own arrays
        blueCubes = GameObject.FindGameObjectsWithTag("BlueCube");
        yellowCubes = GameObject.FindGameObjectsWithTag("YellowCube");
        greenCubes = GameObject.FindGameObjectsWithTag("GreenCube");
        orangeCubes = GameObject.FindGameObjectsWithTag("OrangeCube");
        purpleCubes = GameObject.FindGameObjectsWithTag("PurpleCube");
    }

    public void StopCubeTimer()
    {
        timer += Time.deltaTime;
    }

    //after a certain amount of time, disable a cube by colour
    public void RemoveCubeAfterTime()
    {
        if (timer > 5f)
        {
            for(int i = 0; i < redCubes.Length; i++)
            {
                redCubes[i].gameObject.SetActive(false);
            }
        }
        if (timer > 10f)
        {
            for (int i = 0; i < blueCubes.Length; i++)
            {
                blueCubes[i].gameObject.SetActive(false);
            }
        }
        if (timer > 15f)
        {
            for (int i = 0; i < yellowCubes.Length; i++)
            {
                yellowCubes[i].gameObject.SetActive(false);
            }
        }
        if (timer > 20f)
        {
            for (int i = 0; i < greenCubes.Length; i++)
            {
                greenCubes[i].gameObject.SetActive(false);
            }
        }
        if (timer > 25f)
        {
            for (int i = 0; i < orangeCubes.Length; i++)
            {
                orangeCubes[i].gameObject.SetActive(false);
            }
        }
        if (timer > 30f)
        {
            for (int i = 0; i < purpleCubes.Length; i++)
            {
                purpleCubes[i].gameObject.SetActive(false);
            }
        }
    }
}
