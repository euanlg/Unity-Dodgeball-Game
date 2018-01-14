using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scorebtn : MonoBehaviour {

    public void continueBtn(string MainMenu){
        SceneManager.LoadScene(MainMenu);
    }
}
