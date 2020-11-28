using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollBar;
    float ScrollPos = 0;
    float[] pos;  

    // Update is called once per frame
    void Update()
    {
        pos = new float[Camera.main.transform.childCount];
        float distance = 1f / (pos.Length - 1);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (Input.GetMouseButton (0))
        {
            ScrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (ScrollPos < pos[i] + (distance/2) && ScrollPos > pos[i] - (distance/2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (ScrollPos < pos[i] + (distance / 2) && ScrollPos > pos[i] - (distance / 2))
            {
                Camera.main.transform.GetChild(i).localScale = Vector2.Lerp(Camera.main.transform.GetChild(i).localScale, Camera.main.WorldToScreenPoint(new Vector2(1f, 1f)), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        Camera.main.transform.GetChild(a).localScale = Vector2.Lerp(Camera.main.transform.GetChild(a).localScale, Camera.main.WorldToScreenPoint(new Vector2(0.8f, 0.8f)), 0.1f);
                    }
                }
            }
        }
    }
}
