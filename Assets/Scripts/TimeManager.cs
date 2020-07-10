using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //填写你需要的时间，按秒计算，如120秒，就是2：00;
    public float CountDownTime;
    private float GameTime;
    private float timer = 0;
    public Text GameCountTimeText;
    // Start is called before the first frame update
    void Start()
    {
        GameTime = CountDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        float M = (int)(GameTime / 60);
        float S = GameTime % 60;
        timer += Time.deltaTime;
        if (timer >= 1f&&GameTime>=0)
        {
            timer = 0;
            GameTime--;
            GameCountTimeText.text = string.Format("{00:00}", M )+ "：" + string.Format("{00:00}", S);
        }
        if (GameTime < 0)
        {
            gameObject.GetComponent<GameManager>().GameOver();
        }

    }

}
