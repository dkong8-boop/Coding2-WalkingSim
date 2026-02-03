using System.Collections;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{

    public float fadTimeInSeconds;

    private AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(FadeAudioIn(true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeAudioOut(true));
        }
    }

    private IEnumerator FadeAudioIn(bool fadeIn)
    {
        float timer = 0;

        audio.Play();

        while(timer < fadTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(0, 1, timer / fadTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;

        }

        audio.volume = 1;
    }

    private IEnumerator FadeAudioOut(bool fadeIn)
    {
        float timer = 0;


        while (timer < fadTimeInSeconds)
        {
            audio.volume = Mathf.Lerp(1, 0, timer / fadTimeInSeconds);
            timer += Time.deltaTime;
            yield return null;

        }

        audio.volume = 0;
    }
}
