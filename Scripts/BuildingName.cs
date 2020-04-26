using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BuildingName : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<TextMeshPro>().SetText(this.gameObject.gameObject.gameObject.name);
    }
}
