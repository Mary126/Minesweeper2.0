using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtnManager : MonoBehaviour
{
    public UnityEngine.UI.Button buttn;
    void TaskOnClick()
    {
        SceneManager.LoadScene("MenuScene");

    }
    private void Awake()
    {
        buttn.onClick.AddListener(TaskOnClick);
    }
}
