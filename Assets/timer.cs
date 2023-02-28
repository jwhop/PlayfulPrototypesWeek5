using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class timer : MonoBehaviour
{
    public float targetTime = 10.0f;
    private string minutesString, secondsString;
    public bool HasEnded;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] GameObject endText;
    public bool StartTimer = false;
    public static timer Instance { get; private set; }
    private void Start()
    {
        minutesString = "";
        secondsString = "";
        Instance = this;
        HasEnded = false;
        time = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {

        if(!HasEnded && StartTimer) targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f && !HasEnded)
        {
            timerEnded();
        }

        float seconds = Mathf.RoundToInt(targetTime);

        secondsString = seconds.ToString();
        time.text = secondsString;
        //print("seconds is" + secondsString);

    }

    void timerEnded()
    {
        HasEnded = true;
        endText.SetActive(true);
    }
}
