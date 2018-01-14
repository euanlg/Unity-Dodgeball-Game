﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    GameObject[] musicObject;

    void Start(){
        musicObject = GameObject.FindGameObjectsWithTag("Music");
        if (musicObject.Length == 1){
            GetComponent<AudioSource>().Play();
        }else{
            for (int i = 1; i < musicObject.Length; i++){
                Destroy(musicObject[i]);
            }
        }
    }

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
}
