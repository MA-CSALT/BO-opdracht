using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour


{
    // Start is called before the first frame update

    public float targetTime = 0.0f;
    public TextMeshProUGUI timerTextField;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        targetTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(targetTime / 60);

        int seconds = Mathf.FloorToInt(targetTime % 60);



        timerTextField.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (targetTime <= 100.0f)
        {
            timerEnded();
        }



    }

    void timerEnded()
    {
        Debug.Log("stop timer");
    }


}
