using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;

public class jumpTutorial : MonoBehaviour
{
    public TextMeshProUGUI jumpText;
   private void OnTriggerEnter2D(Collider2D other) {
         if(other.gameObject.tag == "Player")
         {
              jumpText.text = "Preciona espacio para saltar";
         }
   }
}
