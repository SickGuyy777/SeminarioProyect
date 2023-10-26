using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    [Header("NPCs")]
    [SerializeField] GameObject _mafiaBoss;
    [SerializeField] LightManager numday;
    public TMP_Text hourText;
    public TMP_Text minuteText;
    public TMP_Text dayText;
    public TMP_Text weekDayText;
    public TMP_Text monthText;
    public TMP_Text yearText;
    public TMP_Text AmPm;
    public int multipltime;
    public float currentHour;
    public int currentDay;
    //public int currentMonth;
    //public int currentYear;

    public float CurrentMinutes;
    private float seconds;
    string[] _daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    public string currentDayOfWeek = "Monday";

    private void Start()
    {
        if (currentDay == 0) currentDay = 1;
    }

    private void Update()
    {
        TextCallFunction();
        WorldTime();
        seconds += multipltime * Time.deltaTime;
        if (seconds>59)
        {
            seconds = 0;
            CurrentMinutes++;
        }
    }

    void TextCallFunction()
    {
        hourText.text = currentHour.ToString("00");
        minuteText.text = CurrentMinutes.ToString("00");
        dayText.text = "Day: " + currentDay;
        weekDayText.text = "Day of the week: " + _daysOfWeek[currentDay % 7];
    }

    void WorldTime()
    {
        if (currentHour >= 24f)
        {
            currentDay++;
            currentHour = 0;
            currentDayOfWeek = _daysOfWeek[currentDay % 7];
        }
        if(CurrentMinutes>=60f)
        {
            currentHour++;
            CurrentMinutes = 0;
        }

        if(currentHour>=0 && currentHour<12)
        {
            AmPm.text = "am";
        }
        else if(currentHour>=12 && currentHour<=24)
        {
            AmPm.text = "pm";
        }
    }

    public void ChangeHour() 
    {
        currentHour++;
        numday.timeday += 3600;
    }
    public void ChangeDay()
    {
        currentDay++;
        numday.timeday = 25200;
        currentHour = 7;
        currentDayOfWeek = _daysOfWeek[currentDay % 7];
    }
}
