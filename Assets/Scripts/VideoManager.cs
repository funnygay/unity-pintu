using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public GameObject note;
    public GameObject note3;

    void Start()
    {
        note.SetActive(false);
        note3.SetActive(false);
        StartCoroutine(note_show());
    }

   

    IEnumerator note_show()
    {
        note.SetActive(true);
        yield return new WaitForSeconds(15.0f);
        StartCoroutine(note_show3());
       
    }


    IEnumerator note_show3()
    {
        note3.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);

    }




}
