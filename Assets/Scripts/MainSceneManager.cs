using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public GameObject instructionUI;
    public GameObject backgroundUI;
    private bool isShow = false;
    private AudioClip clip_click;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        instructionUI.SetActive(false);
        backgroundUI.SetActive(false);
        isShow = false;
        clip_click = Resources.Load<AudioClip>("Musics/click");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameStart()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("Level0",LoadSceneMode.Single);
    }

    public void GameQuit()
    {
        audio.PlayOneShot(clip_click, 1f);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void GameInstruction()
    {
        audio.PlayOneShot(clip_click, 1f);
        isShow = !isShow;
        instructionUI.SetActive(isShow);
    }

    public void GameBackGround()
    {
        audio.PlayOneShot(clip_click, 1f);
        isShow = !isShow;
        backgroundUI.SetActive(isShow);
    }

    public void GameLevelChoose()
    {
        audio.PlayOneShot(clip_click, 1f);
        SceneManager.LoadScene("Levelchoose", LoadSceneMode.Single);
    }

}
