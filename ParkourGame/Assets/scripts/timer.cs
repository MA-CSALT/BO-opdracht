using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour


{
    // Start is called before the first frame update

    private float targetTime = 100.0f;
    public TextMeshProUGUI timerTextField;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        targetTime -= Time.deltaTime;



        timerTextField.text = UnityEngine.Mathf.Round(targetTime).ToString();

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }



    }

    void timerEnded()
    {
        Debug.Log("stop timer");
    }
}
