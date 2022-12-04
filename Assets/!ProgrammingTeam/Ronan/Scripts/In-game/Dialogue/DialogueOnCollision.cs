using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOnCollision : MonoBehaviour
{
    public GameObject textUI;
    [TextArea(3, 10)]
    public string[] dialogueList;
    public AudioSource audioSource; //get empty audio source from player
    private AudioSource currentAudio;

    void Start()
    {
        textUI.SetActive(false);
        currentAudio = audioSource;
    }

    void Update()
    {
        if (currentAudio.isPlaying)
        {
            textUI.SetActive(true);
        }
        else
        {
            textUI.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "startingDialogueArea")
        {
            audioSource = other.gameObject.GetComponent<AudioSource>();
            textUI.GetComponent<Text>().text = dialogueList[0];
            StartCoroutine("StartingDialogue");
            other.GetComponent<Collider>().enabled = false; //disable collider from triggering again
        }
        if (other.gameObject.name == "dialogueRepeatable")
        {
            audioSource = other.gameObject.GetComponent<AudioSource>();
            playAudio();
            textUI.GetComponent<Text>().text = dialogueList[5];
        }

        for (int i = 1; i < dialogueList.Length; i++)
        {
            if(other.gameObject.name == "dialogue" + i)
            {
                audioSource = other.gameObject.GetComponent<AudioSource>();
                playAudio();
                textUI.GetComponent<Text>().text = dialogueList[i];
                other.GetComponent<Collider>().enabled = false;
            }
        }
    }

    void playAudio()
    {
        if (!currentAudio.isPlaying)
        {
            currentAudio = audioSource;
            currentAudio.Play();
        }
        if (currentAudio.isPlaying) //replace old audio with new audio to stop overlapping
        {
            currentAudio.Stop();
            currentAudio = audioSource;
            currentAudio.Play();
        }
    }
    IEnumerator StartingDialogue()
    {
        yield return new WaitForSeconds(1.5f);
        playAudio();
    }
}
