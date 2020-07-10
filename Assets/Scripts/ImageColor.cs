using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageColor : MonoBehaviour
{
    private Image image;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 4f)
        {
            image.color = new Color(timer / 4, timer / 4, timer / 4,1 );
        }

    }
}
