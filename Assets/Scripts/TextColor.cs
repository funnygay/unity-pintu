using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{
    private Text text;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.color *= new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 160f)
        {
            text.color +=  new Color(0, 0, 0, timer / 160);
        }

    }
}
