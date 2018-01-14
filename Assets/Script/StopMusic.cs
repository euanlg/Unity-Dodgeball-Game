using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {
    void Awake(){
        Destroy(GameObject.FindGameObjectWithTag("Music"));
    }
}
