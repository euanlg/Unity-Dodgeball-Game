using UnityEngine;
using System.Collections;

public class controller_detect : MonoBehaviour{

    public int xb_controller = 0;
    public int ps4_controller = 0;

    void Update(){

        string[] control_names = Input.GetJoystickNames();

        if (control_names.Length >0){
            for (int i = 0; i < control_names.Length; i++){
                if (control_names[i].Length == 33){
                    xb_controller = i;
                    print("array pos:"+xb_controller + "| xbox controller connected");
                }
            }
        } 
    }

}
