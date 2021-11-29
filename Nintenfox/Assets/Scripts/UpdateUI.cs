using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour
{
    public Slider foodSlider;
    public Slider cleaninessSlider;
    public Text coinText;
    public MyGameManager gameManager;

    int nCoins;

    private void Awake()
    {
        nCoins = ((int)gameManager.player.nMonedas);
        foodSlider.value = gameManager.player.energia;
        cleaninessSlider.value = gameManager.player.limpieza;
        coinText.text = nCoins.ToString();
    }

    public void UpdateFood(int cuantity)
    {
        if (foodSlider.value + cuantity < 100 && foodSlider.value + cuantity > 0)
        {
            foodSlider.value += cuantity;
            Debug.Log("Nuevo valor de la barra de comida: " + foodSlider.value);
        } else
        {
            Debug.Log("No se puede añadir " + cuantity + " a la barra de comida (valor actual: " + foodSlider.value + ")");
        }
    }

    public void UpdateCleaniness(int cuantity)
    {
        if (cleaninessSlider.value + cuantity < 100 && cleaninessSlider.value + cuantity > 0)
        {
            cleaninessSlider.value += cuantity;
            Debug.Log("Nuevo valor de la barra de limpieza: " + cleaninessSlider.value);
        } else
        {
            Debug.Log("No se puede añadir " + cuantity + " a la barra de limpieza (valor actual: " + cleaninessSlider.value + ")");
        }
    }

    public void UpdateCoins(int cuantity)
    {
        if (nCoins + cuantity > 0)
        {
            nCoins += cuantity;

            coinText.text = nCoins.ToString();
        } else
        {
            Debug.Log("No se pueden tener menos de 0 monedas!");
        }
    }

}
