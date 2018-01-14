using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p4_control : MonoBehaviour {

    public bool p4_hold = false;
    public bool p4_throw = false;
    bool p1_hold;
    bool p1_throw;
    bool p2_hold;
    bool p2_throw;
    bool p3_hold;
    bool p3_throw;
    bool chargeCheck = false;
    float chargeshot = 0;
    float speedmove;
    private int speed = 800;
    private float ballspeed;
    private float balldistance;
    Rigidbody rbody;
    Vector3 lookPos;
    GameObject ball;
    GameObject p4_holdobj;
    GameObject p1;
    GameObject p2;
    GameObject p3;

    void Start(){
        rbody = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("loc_ball");
        p4_holdobj = GameObject.FindGameObjectWithTag("p4_holdobj");
        if (local_m_player.p1Join == true){
            p1 = GameObject.FindGameObjectWithTag("p1");
        }
        if (local_m_player.p2Join == true){
            p2 = GameObject.FindGameObjectWithTag("p2");
        }
        if (local_m_player.p3Join == true){
            p3 = GameObject.FindGameObjectWithTag("p3");
        }
    }

    void Movement(){
        Vector3 playerDirection = Vector3.right * Input.GetAxis("joy4_Rhorizontal") + Vector3.forward * -Input.GetAxis("joy4_Rvertical");
        if (playerDirection.sqrMagnitude > 0.0f){
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }

    }

    void ResetCharge(){
        p4_hold = false;
        chargeCheck = false;
        chargeshot = 0;
    }

    void ChargeShot(){
        if (chargeshot <= 1){
            p4_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (2000 * Time.deltaTime);
            ResetCharge();
        }
        else if (chargeshot > 1 && chargeshot <= 2){
            p4_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (3000 * Time.deltaTime);
            ResetCharge();
        }
        else if (chargeshot > 2 && chargeshot <= 3){
            p4_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (4000 * Time.deltaTime);
            ResetCharge();
        }else{
            chargeshot = 0;
        }
    }

    void BallPickThrow(){
        if (p3_hold == true){
            if (Input.GetAxis("joy4_Rt") != 0){
                chargeshot += Time.deltaTime;
                chargeCheck = true;
            }
            if (Input.GetAxis("joy4_Rt") == 0 && chargeCheck == true){
                ChargeShot();
            }
        }

        if (p4_hold == false){
            if (balldistance <= 2 && ballspeed < 5){
                if (Input.GetButton("joy4_a")){
                    p4_hold = true;
                }
            }
        }

        if (p4_hold == true){
            ball.transform.position = p4_holdobj.transform.position;
            ball.transform.rotation = transform.rotation;
        }
    }
    void p4mvmt(){
        float horizontal = Input.GetAxis("joy4_Lhorizontal");
        float vertical = Input.GetAxis("joy4_Lvertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rbody.AddForce(movement * speed / Time.deltaTime);
    }
    private void Update()
    {
        if (speedmove != 0)
        {
            GetComponent<Animator>().speed = speedmove * 0.1f;
            GetComponent<Animator>().Play("Runp");
        }
        else
        {
            GetComponent<Animator>().Play("Idelp");
        }
    }

    void FixedUpdate(){
        speedmove = GetComponent<Rigidbody>().velocity.magnitude;
        p4mvmt();
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

        balldistance = Vector3.Distance(transform.position, ball.transform.position);
        ballspeed = ball.GetComponent<Rigidbody>().velocity.magnitude;
        if (ballspeed < 5 && p4_hold == false){
            p4_throw = false;
        }
        Movement();
        if (!p1_hold && !p1_throw && !p2_hold && !p2_throw && !p3_hold && !p3_throw && !p4_hold && !p4_throw){
            BallPickThrow();
        }
        if (p4_hold){
            BallPickThrow();
        }

    }
}