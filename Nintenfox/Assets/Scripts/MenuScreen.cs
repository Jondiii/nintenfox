using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScreen : MonoBehaviour
{
    public Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        AppLogic.Instance.LoadGame();
    }
}