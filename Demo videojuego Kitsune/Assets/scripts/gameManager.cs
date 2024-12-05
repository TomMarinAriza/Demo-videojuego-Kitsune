using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
     public static gameManager Instance;
    public TextMeshProUGUI pointsText;
    private int _points;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (pointsText == null)
        {
            pointsText = GameObject.Find("puntuation").GetComponent<TextMeshProUGUI>();
            if (pointsText == null)
            {
                Debug.LogError("El objeto de texto no se encontró en la escena.");
            }
        }
    }



    

    public void AddPoints(int value)
    {
        _points += value;
        Debug.Log("Puntos: " + _points);
        UpdatePoints();
    }

    private void UpdatePoints()
    {
    Debug.Log($"_points: {_points}");
    if (pointsText != null)
    {
        pointsText.text = "Puntuacion : " + _points.ToString();
        Debug.Log("Texto actualizado correctamente.");
    }
    else
    {
        Debug.LogError("pointsText es null. No se pudo actualizar el texto.");
    }
    }

}
