using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightball2 : MonoBehaviour {
    bool playerHold;
    bool aiHold;
    bool playerthr;
    bool aithr;
    double ballSpeed;

    GameObject ballobj;
    GameObject p1_obj;
    GameObject ai1_obj;
    GameObject light_trail;

    void Awake(){
        ballobj = GameObject.FindGameObjectWithTag("sp_ball");
        p1_obj = GameObject.FindGameObjectWithTag("spp2");
        ai1_obj = GameObject.FindGameObjectWithTag("ai1");
        light_trail = GameObject.FindGameObjectWithTag("balltrail");
    }

    void Update(){
        ballSpeed = ballobj.GetComponent<Rigidbody>().velocity.magnitude;
        playerHold = p1_obj.GetComponent<player1_controllvl2>().p1_hold;
        playerthr = p1_obj.GetComponent<player1_controllvl2>().p1_throw;
        aiHold = ai1_obj.GetComponent<AINav2>().ai_hold;
        aithr = ai1_obj.GetComponent<AINav2>().ai_throw;

        if (ballSpeed > 4)
        {
            light_trail.GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            light_trail.GetComponent<TrailRenderer>().enabled = false;
        }

        if (aithr == false && playerthr == false)
        {
            GetComponent<Light>().color = Color.white;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
            light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
        }
        if (aiHold == true || aithr == true)
        {
            GetComponent<Light>().color = Color.magenta;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        }
        if (playerHold == true || playerthr == true)
        {
            GetComponent<Light>().color = Color.blue;
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
            light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
        }
    }
}
