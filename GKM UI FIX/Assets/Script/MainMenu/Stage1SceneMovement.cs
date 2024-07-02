using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1SceneMovement : MonoBehaviour
{
    private bool doorArea = false;
    public GameObject swordActive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorArea = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorArea = false;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && doorArea && swordActive.activeSelf)
        {
            SceneManager.LoadScene("CutsceneSand");
        }
    }
}
