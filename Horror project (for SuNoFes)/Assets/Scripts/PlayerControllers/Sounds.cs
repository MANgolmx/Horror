using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource source;
    private PlayerMovementController playerMovContr;

    private float Timer;

    public List<AudioClip> roadWalking;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        playerMovContr = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovContr.movingSpeed.x + playerMovContr.movingSpeed.z > 0.08)
            tryToFoot(1.3f);
        else if (playerMovContr.movingSpeed != Vector3.zero && playerMovContr.movingSpeed.x + playerMovContr.movingSpeed.z < 0.04)
            tryToFoot(0.7f);
        else if (playerMovContr.movingSpeed != Vector3.zero)
            tryToFoot();

        Timer -= Time.deltaTime;   
    }

    void tryToFoot(float speed = 1.0f)
    {
        if (Timer <= 0)
        {
            AudioClip clip = roadWalking[Random.Range(0, roadWalking.Count)];
            source.PlayOneShot(clip);
            Timer = clip.length / speed;
        }
    }
}
