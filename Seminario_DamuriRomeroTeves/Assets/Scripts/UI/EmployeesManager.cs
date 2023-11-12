using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeesManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _employeesPanels = new List<GameObject>();
    [SerializeField] List<GameObject> _prefabs = new List<GameObject>();
    [SerializeField] List<int> _prices = new List<int>();
    [SerializeField] ResourserManagment _manager;
    int _eIndex;

    private void Start()
    {
        _eIndex = 0;
    }

    public void NextEmployee()
    {
        _eIndex++;
        if (_eIndex > _employeesPanels.Count - 1) 
        {
            _eIndex = 0;
            _employeesPanels[_employeesPanels.Count - 1].gameObject.SetActive(false);
        } 
        _employeesPanels[_eIndex].gameObject.SetActive(true);
        _employeesPanels[_eIndex - 1].gameObject.SetActive(false);
    }

    public void PreviusEmployee()
    {
        _eIndex--;
        if (_eIndex < 0)
        {
            _eIndex = _employeesPanels.Count - 1;
            _employeesPanels[0].gameObject.SetActive(false);
        }

        _employeesPanels[_eIndex].gameObject.SetActive(true);
        _employeesPanels[_eIndex + 1].gameObject.SetActive(false);
    }

    public void Employ()
    {
        _manager.currentMoney -= _prices[_eIndex];
        _employeesPanels[_eIndex].gameObject.SetActive(false);
        //_prefabs[_eIndex].gameObject.SetActive(true); VER PORQUE APARECEN 2 DE 3 Y NO LOS 3 AL COMPRAR LOS 3
        _employeesPanels.Remove(_employeesPanels[_eIndex]);
        _prices.Remove(_prices[_eIndex]);
        _eIndex = 0;
        _employeesPanels[_eIndex].gameObject.SetActive(true);
    }
}
