using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonsControllers : MonoBehaviour
{
    public float mouseSensetivity;

    public GameObject menu;
    public GameObject settings;
    public GameObject loadingScreen;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayClick()
    {
        menu.SetActive(false);
        loadingScreen.SetActive(true);
        SceneManager.LoadScene("GameScene");
    }

    public void onSettingsClick()
    {
        menu.SetActive(false);
        settings.SetActive(true);
    }
        
    public void onSaveClick()
    {
        menu.SetActive(true);
        settings.SetActive(false);

        mouseSensetivity = settings.GetComponent<Settings>().getMouseSensetivity();
    }
}
