using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public float levelTimer = 5 * 60f;
    public Image securityBar;

    private float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        maxTime = levelTimer;
    }

    // Update is called once per frame
    void Update()
    {
        levelTimer -= Time.deltaTime;
        securityBar.fillAmount = levelTimer / maxTime;
    }
}
