using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hitpoint : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI textMesh = null;
    void Start()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void changeLife(int value)
    {
        this.textMesh.text = "HP: " + value.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
