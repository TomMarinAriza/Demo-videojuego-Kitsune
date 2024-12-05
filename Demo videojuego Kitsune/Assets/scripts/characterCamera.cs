using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCamera : MonoBehaviour
{
   [SerializeField] GameObject _player;
    
    void Update()
    {
        transform.position = _player.transform.position + new Vector3(0, 1f, -10);
    }
}
