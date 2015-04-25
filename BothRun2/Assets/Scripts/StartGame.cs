using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {


    void Begin()
    {
        Application.LoadLevel(1);
    }

    void Exit()
    {
        Application.Quit();
    }

}
