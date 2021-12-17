using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarComida : MonoBehaviour
{

    public MyGameManager gameManager;
    public Button button;
    public int coste;

    private void Awake()
    {
        Button bComprar = button.GetComponent<Button>();
        bComprar.onClick.AddListener(TaskOnClick);
    }

    private void Update()
    {
        if (gameManager.player.nMonedas < coste)
        {
            button.interactable = false;
        } else
        {
            button.interactable = true;
        }
    }

    void TaskOnClick()
    {
        gameManager.player.nMonedas -= coste;
        gameManager.SaveGame();
    }
}
