using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class mm_btn : MonoBehaviour {

    public EventSystem es;
    private GameObject storeselect;
    public bool dontDestroyOnLoad = false;


    void Start(){
        storeselect = es.firstSelectedGameObject;
    }

    void Update(){
        if (Input.GetJoystickNames().Length == 0 || Input.GetJoystickNames()[0] == ""){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            es.SetSelectedGameObject(null);
        }else{
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (es.currentSelectedGameObject != storeselect){
                if (es.currentSelectedGameObject == null){
                    es.SetSelectedGameObject(storeselect);
                }else{
                    storeselect = es.currentSelectedGameObject;
                }
            }
        }
    }


    public void startBtn(string scene){
        SceneManager.LoadScene(scene);
    }

    public void optionBtn(string scene){
        SceneManager.LoadScene(scene);
    }

    public void return_btn(string scene){
        SceneManager.LoadScene(scene);
    }

    public void exitBtn(){
        Application.Quit();
    }
}
