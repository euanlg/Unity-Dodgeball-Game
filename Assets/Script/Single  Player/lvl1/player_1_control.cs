using UnityEngine;
using System.Collections;

public class player_1_control : MonoBehaviour {

    public bool p1_hold = false;
    public bool p1_throw = false;
    bool ai_hold;
    bool ai_throw;
    bool chargeCheck = false;
    bool contCheck = false;
    float chargeshot = 0;
    private int speed = 800;
    private float ballspeed;
    private float balldistance;
    float speedmove;
    Rigidbody rbody;
    Vector3 lookPos;
    GameObject ball;
    GameObject p1_holdobj;
    GameObject ai;


   void Awake(){
        ball = GameObject.FindGameObjectWithTag("sp_ball");
        balldistance = Vector3.Distance(transform.position, ball.transform.position);
        if (balldistance <= 2) { P1BallPickThrow(); }
    }
    void Start(){
        rbody = GetComponent<Rigidbody>();
        p1_holdobj = GameObject.FindGameObjectWithTag("p1_holdobj");
        ai = GameObject.FindGameObjectWithTag("ai1");
       
    }

    void P1Movement(){
        if (Input.GetJoystickNames().Length >= 1){
            contCheck = true;
            Vector3 playerDirection = Vector3.right * Input.GetAxis("joy1_Rhorizontal") + Vector3.forward * -Input.GetAxis("joy1_Rvertical");
            if (playerDirection.sqrMagnitude > 0.0f){
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }else{
            contCheck = false;
        }

        if (Input.GetJoystickNames().Length == 0 || Input.GetJoystickNames()[0] == ""){
            contCheck = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhit;
            if (Physics.Raycast(ray, out rhit, 100)){
                lookPos = rhit.point;
            }
            Vector3 lookDir = lookPos - transform.position;
            lookDir.y = 0;
            transform.LookAt(transform.position + lookDir, Vector3.up);
        }
    }

    void ResetCharge() {
        p1_hold = false;
        chargeCheck = false;
        chargeshot = 0;
    }

    void ChargeShot(){
        if (chargeshot <= 1){
            GetComponent<Animator>().Play("Throw");
            p1_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (20);
            ResetCharge();
        }
        else if (chargeshot > 1 && chargeshot <= 2) {
            GetComponent<Animator>().Play("Throw");
            p1_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (30);
            ResetCharge();
        }
        else if (chargeshot > 2 && chargeshot <= 3){
            GetComponent<Animator>().Play("Throw");
            p1_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (40);
            ResetCharge();
        }else {
            GetComponent<Animator>().Play("Throw");
            chargeshot = 0;
        }
    }

    void P1BallPickThrow(){
        if (p1_hold == true){
            if (contCheck == true && Input.GetAxis("joy1_Rt") != 0) {
                chargeshot += Time.deltaTime;
                chargeCheck = true;
            }
            else if (contCheck == false && Input.GetMouseButtonDown(0)) {
                chargeshot += Time.deltaTime;
                chargeCheck = true;
            }
            if (Input.GetAxis("joy1_Rt") == 0 && chargeCheck == true && contCheck == true) {
                ChargeShot();
            }
            else if (Input.GetMouseButtonUp(0) && chargeCheck == true && contCheck == false){
                ChargeShot();
            }
        }

        if(p1_hold == false && ai_hold == false && ai_throw == false){
            if(balldistance <= 2 && ballspeed < 5) { 
                if (Input.GetButton("joy1_a") || Input.GetKeyDown("e")|| Input.GetMouseButtonDown(1)){
                    p1_hold = true;
                }
            }
        }

        if (p1_hold == true){
            ball.transform.position = p1_holdobj.transform.position;
            ball.transform.rotation = transform.rotation;
        }
    }
    void Update(){
        if (speedmove != 0){
            GetComponent<Animator>().speed = speedmove *0.1f;
            GetComponent<Animator>().Play("Runp");
        }else{
            GetComponent<Animator>().Play("Idelp");
        }
        if (balldistance <= 2){ P1BallPickThrow(); }
        
    }


    void FixedUpdate(){
        speedmove = GetComponent<Rigidbody>().velocity.magnitude;
        mvment();
        ai_hold = ai.GetComponent<AINav>().ai_hold;
        ai_throw = ai.GetComponent<AINav>().ai_throw;
        balldistance = Vector3.Distance(transform.position, ball.transform.position);
        ballspeed = ball.GetComponent<Rigidbody>().velocity.magnitude;
        if (ballspeed < 5 && p1_hold == false || ai_hold== true || ai_throw ==true){
            p1_throw = false;
        }
        P1Movement();
       
    }


    void mvment(){
        float horizontal = Input.GetAxis("joy1_Lhorizontal");
        float vertical = Input.GetAxis("joy1_Lvertical");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rbody.AddForce(movement * speed / Time.deltaTime);
    }
}
