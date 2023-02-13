using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WristHUDManager : MonoBehaviour
{
    public MusicController musicController;



    // Start is called before the first frame update
    void Start()
    {
        musicController = GameObject.FindWithTag("Player").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
