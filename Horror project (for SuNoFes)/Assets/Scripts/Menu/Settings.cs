using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Slider slider;

    private float mouseSensetivity = 400;

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.FindObjectOfType<Slider>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SensetivityChange()
    {
        mouseSensetivity = slider.value;
    }

    public float getMouseSensetivity()
    {
        return mouseSensetivity;
    }
}
