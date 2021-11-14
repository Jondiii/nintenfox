using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    public GameObject esponja;

    private void Awake()
    {
        esponja.SetActive(false);
    }

    //private void OnGUI(){
      //  int xCenter = (Screen.width / 2);
        //int yCenter = (Screen.height / 2);
//        int width = 30;
  //      int height = 30;

    //    GUIStyle fontSize = new GUIStyle(GUI.skin.GetStyle("button"));
      //  fontSize.fontSize = 12;

        //Scene scene = SceneManager.GetActiveScene();

      //  if (scene.name == "MenuPrincipal"){
            // Show a button to allow esponja
        //    if (GUI.Button(new Rect(xCenter - width, yCenter - height, width, height), "", fontSize))
          //  {
            //    esponja.SetActive(true);
                //Visualizar las epsonja
                //SceneManager.LoadScene("Limpieza");
//            }
  //      }
    //    else{
            // Show a button to allow scene1 to be returned to.
      //      if (GUI.Button(new Rect(xCenter - width / 2, yCenter - height / 2, width, height), "Home", fontSize)){
                
                //SceneManager.LoadScene("MenuPrincipal");
      //      }
       //  }
    //}

    private void OnMouseDown()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MenuPrincipal")
        {
            // Show a button to allow esponja
            esponja.SetActive(true);
        }
    }
}
