using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private List<RectTransform> boxlist;
    private bool dragable = false;
    private bool isClick = true;

    private void Start()
    {
        boxlist = new List<RectTransform>();
        RectTransform[] list1 = GameObject.Find("target").GetComponentsInChildren<RectTransform>();
        foreach (var item in list1)
        {
            if (item.name != "target")
            {
                boxlist.Add(item);
            }
            
        }
        RectTransform[] list2 = GameObject.Find("init1").GetComponentsInChildren<RectTransform>();
        foreach (var item in list2)
        {
            if (item.name != "init1")
            {
                boxlist.Add(item);
            }
        }
        RectTransform[] list3 = GameObject.Find("init2").GetComponentsInChildren<RectTransform>();
        foreach (var item in list3)
        {
            if (item.name != "init2")
            {
                boxlist.Add(item);
            }
        }
        //随机打乱
        for (int i = 0; i < 10; i++)
        {
            int a = Random.Range(13, 24);
            int b = Random.Range(12, a);
            ImageSwitch(boxlist[a].gameObject, boxlist[b].gameObject);
            int angle = Random.Range(-1, 3);
            boxlist[a].Rotate(0, 0, angle*90f);
        }

    }

    // begin dragging
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        isClick = false;
        dragable = false;
        var rt = gameObject.GetComponent<RectTransform>();
        if (rt.gameObject.layer == 9)
        {
            dragable = true;
            SetDraggedPosition(eventData);
            int count_parent = gameObject.GetComponent<Transform>().parent.parent.childCount;
            gameObject.GetComponent<Transform>().parent.SetSiblingIndex(count_parent - 1);
        }
        
    }
    // during dragging
    public void OnDrag(PointerEventData eventData)
    {
        
        if (dragable)
        {
            SetDraggedPosition(eventData);
        }
       
    }
    // end dragging
    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragable)
        {
            // SetDraggedPosition(eventData);
            Transform target = SetFinalPosition(eventData);
            Debug.Log(target.name);
            //var rt = gameObject.GetComponent<RectTransform>();
            ImageSwitch(gameObject,target.gameObject);
            //float temp_trans = rt.eulerAngles.z;
            //string temp_tag = rt.tag;
            //Sprite temp_img = gameObject.GetComponent<Image>().sprite;
            //int temp_layer = gameObject.layer;

            //gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, target.eulerAngles.z);
            //gameObject.tag = target.tag;
            //gameObject.GetComponent<Image>().sprite = target.GetComponent<Image>().sprite;
            //gameObject.layer = target.gameObject.layer;

            //target.tag = temp_tag;
            //target.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, temp_trans);
            //target.GetComponent<Image>().sprite = temp_img;
            //target.gameObject.layer = temp_layer;
            dragable = false;
            if (WinCheck())
            {
                GameObject.Find("Main Camera").GetComponent<GameManager>().GameWin();
            }
        }

    }
    /// <summary>
    /// set position of the dragged game object
    /// </summary>
    /// <param name="eventData"></param>
    private void SetDraggedPosition(PointerEventData eventData)
    {
        var rt = gameObject.GetComponent<RectTransform>();
        // transform the screen point to world point int rectangle
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
        }
    }


    private Transform SetFinalPosition(PointerEventData eventData)
    {
        Transform target_trans = boxlist[0];
        Vector3 globalMousePos;
        float min_distance = Mathf.Infinity;
        var rt =gameObject.GetComponent<RectTransform>();
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, eventData.position, eventData.pressEventCamera, out globalMousePos);

        for (int i = 0; i < boxlist.Count; i++)
        {
            float distance= Vector3.Distance(boxlist[i].position, globalMousePos);
            if (distance < min_distance&&rt.transform.name!=boxlist[i].name)
            {
                min_distance = distance;
                target_trans = boxlist[i];
            }
        }
        return target_trans;
    }

    public void Rotate()
    {
        Debug.Log(isClick);
        if (isClick)
        {
            gameObject.GetComponent<RectTransform>().Rotate(0, 0, 90f);
            if (WinCheck())
            {
                GameObject.Find("Main Camera").GetComponent<GameManager>().GameWin();
            }
        }
        else
        {
            isClick = true;
        }
        

    }

    private bool WinCheck()
    {
        for (int i = 0; i < 12; i++)
        {
            if (boxlist[i].tag != boxlist[i].name || boxlist[i].gameObject.layer != 9 ||Mathf.Abs(boxlist[i].eulerAngles.z)>1)
            {
                Debug.Log("name:"+boxlist[i].name+"   layer:"+boxlist[i].gameObject.layer+"   angle:"+ boxlist[i].eulerAngles.z);
                return false;
            }
        }
        return true;
    }


    private void ImageSwitch(GameObject a, GameObject b)
    {
        float temp_trans = a.GetComponent<RectTransform>().eulerAngles.z;
        string temp_tag = a.tag;
        Sprite temp_img = a.GetComponent<Image>().sprite;
        int temp_layer = a.layer;
        Color temp_color = a.GetComponent<Image>().color;

        a.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, b.GetComponent<RectTransform>().eulerAngles.z);
        a.tag = b.tag;
        a.GetComponent<Image>().sprite = b.GetComponent<Image>().sprite;
        a.layer = b.layer;
        a.GetComponent<Image>().color = b.GetComponent<Image>().color;

        b.tag = temp_tag;
        b.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, temp_trans);
        b.GetComponent<Image>().sprite = temp_img;
        b.layer = temp_layer;
        b.GetComponent<Image>().color = temp_color;
    }

}