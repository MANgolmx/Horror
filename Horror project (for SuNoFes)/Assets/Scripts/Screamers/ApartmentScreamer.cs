using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentScreamer : MonoBehaviour
{
    public AudioSource lamp;

    public AudioClip lamp_broken;
    public AudioClip lamp_switching;

    public new Light light;
    public GameObject apartment;

    bool isHappened;

    // Start is called before the first frame update
    void Start()
    {
        isHappened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isHappened && other.CompareTag("Player"))
        {
            isHappened = true;
            StartCoroutine(Appearence());
        }
    }

    IEnumerator Disappearance()
    {
        lamp.PlayOneShot(lamp_switching);
        yield return new WaitForSeconds(7);
        light.gameObject.SetActive(true);
        apartment.SetActive(false);
    }

    IEnumerator Appearence()
    {
        lamp.PlayOneShot(lamp_broken);
        yield return new WaitForSeconds(1.5f);
        light.GetComponent<Light>().gameObject.SetActive(false);
        apartment.SetActive(true);
        StartCoroutine(Disappearance());
    }
}
