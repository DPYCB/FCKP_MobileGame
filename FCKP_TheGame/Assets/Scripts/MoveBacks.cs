using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBacks : MonoBehaviour
{
    public GameObject backgroundFirst;
    public GameObject backgroundSecond;
    public float moveHeight;
    // Start is called before the first frame update
    void LateUpdate()
    {
        checkBackgrounds();
        swapBackgrounds();
    }

    private void checkBackgrounds()
    {
        if (backgroundFirst.transform.position.y > backgroundSecond.transform.position.y)
        {
            GameObject temp = backgroundSecond;
            backgroundSecond = backgroundFirst;
            backgroundFirst = temp;
        }
    }

    private void swapBackgrounds()
    {
        float cameraVerticalPos = Camera.main.transform.position.y;
        if (cameraVerticalPos >= backgroundSecond.transform.position.y)
        {
            backgroundFirst.transform.Translate(0, moveHeight, 0);
        }
    }
}
