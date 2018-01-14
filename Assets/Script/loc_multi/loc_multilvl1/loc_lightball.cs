using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loc_lightball : MonoBehaviour {

    int whichHold = 0;
    bool p1_hold;
    bool p1_throw;
    bool p2_hold;
    bool p2_throw;
    bool p3_hold;
    bool p3_throw;
    bool p4_hold;
    bool p4_throw;
    double ballSpeed;
    GameObject p1;
    GameObject p2;
    GameObject p3;
    GameObject p4;
    GameObject light_trail;

    void Start(){
        if (local_m_player.p1Join == true){
            p1 = GameObject.FindGameObjectWithTag("p1");
        }
        if (local_m_player.p2Join == true){
            p2 = GameObject.FindGameObjectWithTag("p2");
        }
        if (local_m_player.p3Join == true){
            p3 = GameObject.FindGameObjectWithTag("p3");
        }
        if (local_m_player.p4Join == true){
            p4 = GameObject.FindGameObjectWithTag("p4");
        }
        light_trail = GameObject.FindGameObjectWithTag("balltrail");
    }

    private void Update(){
        ballSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        if (local_m_player.p1Join == true){
            p1_hold = p1.GetComponent<p1_control>().p1_hold;
            p1_throw = p1.GetComponent<p1_control>().p1_throw;
        }
        if (local_m_player.p2Join == true){
            p2_hold = p2.GetComponent<p2_control>().p2_hold;
            p2_throw = p2.GetComponent<p2_control>().p2_throw;
        }
        if (local_m_player.p3Join == true){
            p3_hold = p3.GetComponent<p3_control>().p3_hold;
            p3_throw = p3.GetComponent<p3_control>().p3_throw;
        }
        if (local_m_player.p4Join == true){
            p4_hold = p4.GetComponent<p4_control>().p4_hold;
            p4_throw = p4.GetComponent<p4_control>().p4_throw;
        }
        if (p1_hold || p1_throw){
            whichHold = 1;
        }
        if (p2_hold || p2_throw){
            whichHold = 2;
        }
        if (p3_hold || p3_throw){
            whichHold = 3;
        }
        if (p4_hold || p4_throw){
            whichHold = 4;
        }
        if (!p1_hold && !p1_throw && !p2_hold && !p2_throw && !p3_hold && !p3_throw && !p4_hold && !p4_throw){
            whichHold = 0;
        }

        if (ballSpeed > 4){
            light_trail.GetComponent<TrailRenderer>().enabled = true;
        }else{
            light_trail.GetComponent<TrailRenderer>().enabled = false;
        }

        switch (whichHold){
            case 0:
                GetComponent<Light>().color = Color.white;
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.white);
                break;
            case 1:
                GetComponent<Light>().color = Color.blue;
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.blue);
                break;
            case 2:
                GetComponent<Light>().color = Color.red;
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
                break;
            case 3:
                GetComponent<Light>().color = Color.cyan;
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);
                light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.cyan);
                break;
            case 4:
                GetComponent<Light>().color = Color.yellow;
                GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
                light_trail.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
                break;

        }
              
    }

}
