using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p3_control : MonoBehaviour {

    public bool p3_hold = false;
    public bool p3_throw = false;
    bool p1_hold;
    bool p1_throw;
    bool p2_hold;
    bool p2_throw;
    bool p4_hold;
    bool p4_throw;
    bool chargeCheck = false;
    float chargeshot = 0;
    float speedmove;
    private int speed = 800;
    private float ballspeed;
    private float balldistance;
    Rigidbody rbody;
    Vector3 lookPos;
    GameObject ball;
    GameObject p3_holdobj;
    GameObject p1;
    GameObject p2;
    GameObject p4;

    void Start(){
        rbody = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("loc_ball");
        p3_holdobj = GameObject.FindGameObjectWithTag("p3_holdobj");
        if (local_m_player.p1Join == true){
            p1 = GameObject.FindGameObjectWithTag("p1");
        }
        if (local_m_player.p2Join == true){
            p2 = GameObject.FindGameObjectWithTag("p2");
        }
        if (local_m_player.p4Join == true){
            p4 = GameObject.FindGameObjectWithTag("p4");
        }
    }

    void Movement(){
        Vector3 playerDirection = Vector3.right * Input.GetAxis("joy3_Rhorizontal") + Vector3.forward * -Input.GetAxis("joy3_Rvertical");
        if (playerDirection.sqrMagnitude > 0.0f){
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }

    }

    void ResetCharge(){
        p3_hold = false;
        chargeCheck = false;
        chargeshot = 0;
    }

    void ChargeShot(){
        if (chargeshot <= 1){
            p3_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (2000 * Time.deltaTime);
            ResetCharge();
        }
        else if (chargeshot > 1 && chargeshot <= 2){
            p3_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (3000 * Time.deltaTime);
            ResetCharge();
        }
        else if (chargeshot > 2 && chargeshot <= 3){
            p3_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (4000 * Time.deltaTime);
            ResetCharge();
        }else{
            chargeshot = 0;
        }
    }

    void BallPickThrow(){
        if (p3_hold == true){
            if (Input.GetAxis("joy3_Rt") != 0){
                chargeshot += Time.deltaTime;
                chargeCheck = true;
            }
            if (Input.GetAxis("joy3_Rt") == 0 && chargeCheck == true){
                ChargeShot();
            }
        }

        if (p3_hold == false){
            if (balldistance <= 2 && ballspeed < 5){
                if (Input.GetButton("joy3_a")){
                    p3_hold = true;
                }
            }
        }

        if (p3_hold == true){
            ball.transform.position = p3_holdobj.transform.position;
            ball.transform.rotation = transform.rotation;
        }
    }
    void p3mvmt(){
        float horizontal = Input.GetAxis("joy3_Lhorizontal");
        float vertical = Input.GetAxis("joy3_Lvertical");

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
        p3mvmt();
        if (local_m_player.p1Join == true){
            p1_hold = p1.GetComponent<p1_control>().p1_hold;
            p1_throw = p1.GetComponent<p1_control>().p1_throw;
        }
        if (local_m_player.p2Join == true){
            p2_hold = p2.GetComponent<p2_control>().p2_hold;
            p2_throw = p2.GetComponent<p2_control>().p2_throw;
        }
        if (local_m_player.p4Join == true){
            p4_hold = p4.GetComponent<p4_control>().p4_hold;
            p4_throw = p4.GetComponent<p4_control>().p4_throw;
        }

        balldistance = Vector3.Distance(transform.position, ball.transform.position);
        ballspeed = ball.GetComponent<Rigidbody>().velocity.magnitude;
        if (ballspeed < 5 && p3_hold == false){
            p3_throw = false;
        }
        Movement();
        if (!p1_hold && !p1_throw && !p2_hold && !p2_throw && !p3_hold && !p3_throw && !p4_hold && !p4_throw){
            BallPickThrow();
        }
        if (p3_hold){
            BallPickThrow();
        }
    }
}