using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    public TMP_Text hourText;
    public TMP_Text dayText;
    public TMP_Text monthText;
    public TMP_Text yearText;

    public int currentHour;
    public int currentDay;
    //public int currentMonth;
    //public int currentYear;

    private void Start()
    {
        if (currentDay == 0) currentDay = 1;
    }

    private void Update()
    {
        TextCallFunction();

        WorldTime();
    }

    void TextCallFunction()
    {
        hourText.text = "Hour: " + currentHour;
        dayText.text = "Day: " + currentDay;
    }

    void WorldTime()
    {
        if (currentHour >= 24)
        {
            currentDay++;
            currentHour = 0;
        }
    }

    public void ChangeHour() { currentHour++; }
    public void ChangeDay()
    {
        currentDay++;
        currentHour = 7;
    }
}
