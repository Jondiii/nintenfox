using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SalirTienda : MonoBehaviour
{
	public Button yourButton;
	
	void Awake()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}
	void TaskOnClick()
	{
		SceneManager.LoadScene(1);
	}
}
