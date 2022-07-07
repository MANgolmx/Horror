using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApartmentScreamer : MonoBehaviour
{
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
            light.gameObject.SetActive(false);
            apartment.SetActive(true);
            StartCoroutine(Disappearance());
        }
    }

    IEnumerator Disappearance()
    {
        yield return new WaitForSeconds(7);
        apartment.SetActive(false);
    }
}
