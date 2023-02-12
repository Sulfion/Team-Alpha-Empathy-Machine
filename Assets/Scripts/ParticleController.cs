using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSys;
    public MusicController musicController;

    public ParticleSystem redParticles;

    //private bool redParticleCheck = false;
    //private bool blueParticleCheck = false;
    //private bool yellowParticleCheck = false;
    //private bool greenParticleCheck = false;
    //private bool orangeParticleCheck = false;
    //private bool purpleParticleCheck = false;
    //private bool brownParticleCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        redParticles = GameObject.FindWithTag("RedParticle").GetComponent<ParticleSystem>();

        musicController = GameObject.FindWithTag("Player").GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.CompareTag("RedCube"))
        {
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartStopParticles());
        }
    }


    //stop particle system for 10 seconds
    public IEnumerator StartStopParticles()
    {
        redParticles.Stop();
        yield return new WaitForSeconds(10);
        redParticles.Play();
    }
}
