using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    public Transform ball;
    public Transform player;
    public Transform ai;
    public float smooth = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Update(){
        Vector3 pos =  (player.position + ai.position + ball.position)/3 ;
        pos.y = transform.position.y;
        pos.z = transform.position.z-0f;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
    }
}
