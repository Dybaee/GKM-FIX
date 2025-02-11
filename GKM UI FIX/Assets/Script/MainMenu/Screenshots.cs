using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshots : MonoBehaviour
{
    [SerializeField]
    private string path;
    private string fileName;
    [SerializeField]
    [Range(1, 5)]
    private int size = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Udh Gw Screenshots");
            fileName = "screenshot ";
            fileName += System.Guid.NewGuid().ToString() + ".png";

            ScreenCapture.CaptureScreenshot(path + fileName, size);
        }
    }
}
