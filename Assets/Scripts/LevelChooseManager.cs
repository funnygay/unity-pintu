using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelChooseManager : MonoBehaviour

{
    Canvas canvas;//当前UI所在的画布
　　RectTransform rectTransform;

    /// <summary>
    /// UI和指针的位置偏移量
    /// </summary>
    Vector3 offset;

    RectTransform rt;




    void Update()
    {
       // DragRangeLimit();
    }

    void Start()
    {
        rt = GetComponent<RectTransform>();


    }




    ///// <summary>
    ///// 开始拖拽
    ///// </summary>
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Vector3 globalMousePos;

    //    //将屏幕坐标转换成世界坐标
    //    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
    //    {
    //        //计算UI和指针之间的位置偏移量
    //        offset = rt.position - globalMousePos;
    //    }
    //}

    ///// <summary>
    ///// 拖拽中
    ///// </summary>
    //public void OnDrag(PointerEventData eventData)
    //{
    //    SetDraggedPosition(eventData);
    //}

    ///// <summary>
    ///// 结束拖拽
    ///// </summary>
    //public void OnEndDrag(PointerEventData eventData)
    //{

    //}

    ///// <summary>
    ///// 更新UI的位置
    ///// </summary>
    //private void SetDraggedPosition(PointerEventData eventData)
    //{
    //    Vector3 globalMousePos;

    //    if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, null, out globalMousePos))
    //    {
    //        globalMousePos += offset;
    //        if (globalMousePos.x < -360)
    //        {
    //            globalMousePos.x = -360;
    //        }
    //        if (globalMousePos.x > 1440)
    //        {
    //            globalMousePos.x = 1440;
    //        }
    //        rt.position = new Vector3(globalMousePos.x,rt.position.y,rt.position.z);
    //        Debug.Log(globalMousePos);
    //    }
    //}


    public void GameToLevel1()
    {    
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void GameToLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void GameToLevel3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }


}
