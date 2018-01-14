using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AINav2 : MonoBehaviour {

    public bool ai_hold = false;
    public bool ai_throw = false;
    bool pl1_hold;
    bool pl1_throw;
    public Transform[] points;
    private UnityEngine.AI.NavMeshAgent agent;
    private int destPoint = 0;
    private float ballspeed;
    private float balldistance;
    float speed;
    bool waitComplete = false;
    GameObject ball;
    GameObject player;
    GameObject ai_holdobj;

    //agent.updateRotation = false; - use when targeting the player

    private void Awake(){
        ai_hold = false;
        ai_throw = false;
    }

    void Start(){
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        GotoNextPoint();
        ball = GameObject.FindGameObjectWithTag("sp_ball");
        player = GameObject.FindGameObjectWithTag("spp2");
        ai_holdobj = GameObject.FindGameObjectWithTag("ai1_holdobj");
    }

    void LookAtPlayer(){
        agent.updateRotation = false;
        GotoNextPoint();
        agent.transform.LookAt(player.transform.position);

        StartCoroutine(wait_for_throw());
        if (waitComplete == true){
            StopAllCoroutines();
            ai_throw = true;
            ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * (Random.Range(1550, 1950) * Time.deltaTime);
            agent.updateRotation = true;
            ai_hold = false;
            waitComplete = false;
        }
    }

    void AiHoldBall(){
        ball.transform.position = ai_holdobj.transform.position;
        ball.transform.rotation = transform.rotation;
        ai_hold = true;
    }

    void GotoNextPoint(){
        if (points.Length == 0){
            return;
        }
        agent.destination = points[destPoint].position;
        test_waypoint();
    }

    void test_waypoint(){
        if (agent.destination != points[destPoint].position){
            destPoint = Random.Range(0, points.Length);
        }else{
            return;
        }
    }

    private void Update(){
        if (speed != 0)
        {
            GetComponent<Animator>().speed = (speed * 1.50f);
            GetComponent<Animator>().Play("RUN");
        }
       

        if (ballspeed < 5 && ai_hold == false && balldistance > 2){
            ai_throw = false;
        }
    }

    void FixedUpdate(){
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        balldistance = Vector3.Distance(transform.position, ball.transform.position);
        ballspeed = ball.GetComponent<Rigidbody>().velocity.magnitude;
        pl1_hold = player.GetComponent<player1_controllvl2>().p1_hold;
        pl1_throw = player.GetComponent<player1_controllvl2>().p1_throw;

        if (ball.transform.position.x > 0 || pl1_throw == true || pl1_hold == true){
            if (agent.remainingDistance <= 0.2){
                GotoNextPoint();
            }else{
                test_waypoint();
            }
        }

        if (ai_throw == true){
            agent.updateRotation = false;
            agent.transform.LookAt(player.transform.position);
        }else{
            agent.updateRotation = true;
        }

        if (ai_hold == true){
            agent.updateRotation = false;
            agent.transform.LookAt(player.transform.position);
            ball.transform.position = ai_holdobj.transform.position;
            ball.transform.rotation = transform.rotation;
            LookAtPlayer();
        }

        if (ball.transform.position.x <= 0.2 && pl1_hold == false && pl1_throw == false && ai_hold == false && ai_throw == false){
            agent.destination = ball.transform.position;
            if (balldistance < 2){
                AiHoldBall();
            }
        }
    }

    IEnumerator wait_for_throw(){
        int wait_time = Random.Range(30, 70);
        agent.transform.LookAt(player.transform.position);
        yield return new WaitForSeconds(wait_time * Time.deltaTime);
        waitComplete = true;
    }
}
