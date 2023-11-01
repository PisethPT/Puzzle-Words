using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public AudioSource background_sound;
    private void Start()
    {
        background_sound.Play();
    }

    public void player_scenc()
    {
        SceneManager.LoadScene("Press Words");
    }
    public void quit()
    {
        Application.Quit();
    }
}
