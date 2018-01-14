using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMenuMusic : MonoBehaviour {

    void Awake(){
        Destroy(GameObject.FindGameObjectWithTag("MenuMusic"));
    }
}
