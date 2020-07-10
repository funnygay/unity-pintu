using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseManager : MonoBehaviour
{

    public Image image;
    public GameObject section1;
    public GameObject buttons;
    private float timer = 0;
    private AudioSource audio;
    private AudioClip clip_click;
    private AudioClip walk;
    private AudioClip kill;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        clip_click = Resources.Load<AudioClip>("Musics/click");
        walk= Resources.Load<AudioClip>("Musics/walk");
        kill = Resources.Load<AudioClip>("Musics/kill");
        buttons.SetActive(false);
        section1.SetActive(true);
        audio.PlayOneShot(walk, 1f);
        StartCoroutine(sectionSwitch());
        image.color = new Color(0, 0, 0, 0);
    }

    IEnumerator sectionSwitch()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(sectionSwitch2());
    }

    IEnumerator sectionSwitch2()
    {
        yield return new WaitForSeconds(2f);
        audio.PlayOneShot(kill, 1f);
        StartCoroutine(sectionSwitch3());
    }
    IEnumerator sectionSwitch3()
    {
        yield return new WaitForSeconds(4f);
       
        buttons.SetActive(true);
        timer = 0;
        image.color = new Color(0, 0, 0, 0);
    }


    public void Back()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void RePlay()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"), LoadSceneMode.Single);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer <2f)
        {
            image.color = new Color(0, 0, 0, (timer / 4));
        }
    }

}
