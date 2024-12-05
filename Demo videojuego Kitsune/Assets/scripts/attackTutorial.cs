using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class attackTutorial : MonoBehaviour
{
    public TextMeshProUGUI attackText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            attackText.text = "Preciona 'E' para atacar";
        }
    }
}
