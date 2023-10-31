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
    public GameObject[] daysMoth;
    public int multipltime;
    public float currentHour;
    public int currentDay;
    public int currentMonth;
    //public int currentYear;
    public GameObject DayNow;
    public List<Transform> posday;
    public int listSize;
    public float CurrentMinutes;
    private float seconds;
    string[] _daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    string[] _MonthOfYear = { "January", "February", "March", "April", "May", "June,", "July" , "August" , "September" , "October" , "November" , "December" }; //esto va a salir en el calendario
    public string currentDayOfWeek = "Monday";
    public string currentMonthOfYear = "January";

    private void Start()
    {
        if (currentDay == 0) currentDay = 1;
        daysMoth[0].SetActive(false);
        daysMoth[1].SetActive(true);
        daysMoth[2].SetActive(false);
        daysMoth[3].SetActive(false);
        daysMoth[4].SetActive(false);
        daysMoth[5].SetActive(false);
        daysMoth[6].SetActive(false);
        daysMoth[7].SetActive(false);
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


            if (currentDay >= listSize)
            {
                currentDay = 0;  // Reinicia el índice al llegar al máximo de la lista
            }

            DayNow.transform.position = posday[currentDay+1].position;
        
    }

    void TextCallFunction()
    {
        hourText.text = currentHour.ToString("00");
        minuteText.text = CurrentMinutes.ToString("00");
        dayText.text = "Day: " + currentDay;
        weekDayText.text = "Day of the week: " + _daysOfWeek[currentDay % 7];
        monthText.text = _MonthOfYear[currentMonth % 12];//cosas del mes aun no funka
    }

    void WorldTime()
    {
        # region horas
        if (currentHour >= 24f)
        {
            currentDay++;
            currentHour = 0;
            currentDayOfWeek = _daysOfWeek[currentDay % 7];
        }
        if (CurrentMinutes>=60f)
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
        #endregion
        #region mes
        switch (currentMonth)
        {
            case 0:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(true);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 1:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(true);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 2:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(true);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 3:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(true);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 4:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(true);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 5:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(true);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 6:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(true);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 7:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(true);
                    break;
                }
            case 8:
                {
                    daysMoth[0].SetActive(true);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 9:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(true);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 10:
                {
                    daysMoth[0].SetActive(false);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(true);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
            case 11:
                {
                    daysMoth[0].SetActive(true);
                    daysMoth[1].SetActive(false);
                    daysMoth[2].SetActive(false);
                    daysMoth[3].SetActive(false);
                    daysMoth[4].SetActive(false);
                    daysMoth[5].SetActive(false);
                    daysMoth[6].SetActive(false);
                    daysMoth[7].SetActive(false);
                    break;
                }
        }
        if (currentDay>31 && currentMonth==0)//enero
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 28 && currentMonth == 1)//febrero
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 30 && currentMonth == 2)//marzo
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 3)//abril
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 4)//mayo
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 29 && currentMonth == 5)//junio
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 6)//julio
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 7)//agosto
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 8)//septiembre
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 9)//octubre
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 30 && currentMonth == 10)//noviembre
        {
            currentMonth++;
            currentDay = 1;
        }
        else if (currentDay > 31 && currentMonth == 11)//diciembre
        {
            currentMonth=0;
            currentDay = 1;
        }
        #endregion
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
        CurrentMinutes = 0;
        currentDayOfWeek = _daysOfWeek[currentDay % 7];
    }
}
