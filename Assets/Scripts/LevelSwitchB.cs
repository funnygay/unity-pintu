using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchB : MonoBehaviour
{

    public GameObject section1;
    public GameObject buttons;

    private AudioSource audio;
    private AudioClip clip_click;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        clip_click = Resources.Load<AudioClip>("Musics/click");
        buttons.SetActive(false);
        section1.SetActive(true);
        StartCoroutine(sectionSwitch());
    }

    IEnumerator sectionSwitch()
    {
        yield return new WaitForSeconds(10f);
        section1.SetActive(false);
        buttons.SetActive(true);
    }


    public void JumpToNext()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void RePlay()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void Back()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
