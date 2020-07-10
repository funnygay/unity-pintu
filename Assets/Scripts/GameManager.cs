using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject settingUI;
    private AudioClip clip_click;
    //private AudioClip win;
    //private AudioClip fail;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        clip_click = Resources.Load<AudioClip>("Musics/click");
        //win = Resources.Load<AudioClip>("Musics/win");
        //fail = Resources.Load<AudioClip>("Musics/fail");
        audio = GetComponent<AudioSource>();
        Scene scene = SceneManager.GetActiveScene();
        PlayerPrefs.SetString("currentLevel",scene.name);
    }

    private void OnEnable()
    {
        settingUI.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    public void GameWin()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1")
        {
            SceneManager.LoadScene("Level1To2", LoadSceneMode.Single);
        }
        else if(scene.name == "Level2")
        {
            SceneManager.LoadScene("Level2To3", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("FinalWin", LoadSceneMode.Single);
        }
        
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Fail", LoadSceneMode.Single);

    }

    public void GameSetting()
    {
        audio.PlayOneShot(clip_click, 1f);
        settingUI.SetActive(true);
        GamePause();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GameContinue()
    { 
        Time.timeScale = 1;
        audio.PlayOneShot(clip_click, 1f);
        settingUI.SetActive(false);
    }

    public void GameReStart()
    {
        GameContinue();
        StartCoroutine(Reload());
    }

    IEnumerator  Reload()
    {
        yield return new WaitForSeconds(0.5f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
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


    public void GameToMainmenu()
    {
        GameContinue();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void GameToLevelChoose()
    {
        GameContinue();
        SceneManager.LoadScene("Levelchoose", LoadSceneMode.Single);
    }

    public void GameToLevel0()
    {
        GameContinue();
        SceneManager.LoadScene("Level0", LoadSceneMode.Single);
    }

    public void GameToLevel1()
    {
        GameContinue();
        SceneManager.LoadScene("Level1",LoadSceneMode.Single);
    }

    public void GameToLevel2()
    {
        GameContinue();
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void GameToLevel3()
    {
        GameContinue();
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }
}
