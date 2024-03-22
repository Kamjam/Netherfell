using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMouseHover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){

    }

    void OnMouseEnter(){
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit() {

    }
}
