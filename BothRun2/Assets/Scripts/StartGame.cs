using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {


    void Begin()
    {
        Application.LoadLevel(0);
    }

    void Exit()
    {
        Application.Quit();
    }

}
