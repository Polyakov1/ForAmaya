using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForImageLetter : MonoBehaviour
{
    void Start()
    {
        Image imageComponent = GetComponent<Image>();
        name = imageComponent.sprite.name;
        if(name == "7" || name == "8")
        {
            transform.localRotation = Quaternion.Euler(0,0, -90);
        }
    }
}
