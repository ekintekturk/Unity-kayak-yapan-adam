using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crash : MonoBehaviour
{
    [SerializeField] float loadDelay =0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
      
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
         hasCrashed = true;
         FindObjectOfType<PlayerController>().DisableControls();
         crashEffect.Play();
         GetComponent<AudioSource>().PlayOneShot(crashSFX);
        Invoke("ReloadScene", loadDelay);
        }
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
