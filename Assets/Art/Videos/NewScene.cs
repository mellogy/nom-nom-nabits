using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public int scenetoload;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(scenetoload);   
    }
}
