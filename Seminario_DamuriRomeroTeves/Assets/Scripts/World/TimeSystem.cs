using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    [Header("NPCs")]
    [SerializeField] GameObject _mafiaBoss;

    public TMP_Text hourText;
    public TMP_Text dayText;
    public TMP_Text weekDayText;
    public TMP_Text monthText;
    public TMP_Text yearText;

    public int currentHour;
    public int currentDay;
    //public int currentMonth;
    //public int currentYear;

    string[] _daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    string currentDayOfWeek = "Monday";

    private void Start()
    {
        if (currentDay == 0) currentDay = 1;
    }

    private void Update()
    {
        TextCallFunction();

        WorldTime();

        switch (currentDayOfWeek)
        {
            case "Monday":
                Debug.Log("es lunes");
                break;
            case "Tuesday":
                Debug.Log("es martes");
                break;
            case "Wednesday":
                Debug.Log("es miercoles");
                break;
            case "Thursday":
                Debug.Log("es jueves");
                break;
            case "Friday":
                Debug.Log("es viernes");
                break;
            case "Saturday":
                Debug.Log("es sabado");
                break;
            case "Sunday":
                Debug.Log("es domingo");
                break;
        }
    }

    void TextCallFunction()
    {
        hourText.text = "Hour: " + currentHour;
        dayText.text = "Day: " + currentDay;
        weekDayText.text = "Day of the week: " + _daysOfWeek[currentDay % 7];
    }

    void WorldTime()
    {
        if (currentHour >= 24)
        {
            currentDay++;
            currentHour = 0;
            currentDayOfWeek = _daysOfWeek[currentDay % 7];
        }
    }

    public void ChangeHour() 
    {
        currentHour++;
    }
    public void ChangeDay()
    {
        currentDay++;
        currentHour = 7;
        currentDayOfWeek = _daysOfWeek[currentDay % 7];
    }
}
