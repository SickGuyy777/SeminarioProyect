using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("INTERACTUABLE TABLE")]
    [SerializeField] float _viewRadius;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] Canvas _interactuableCanv;
    [SerializeField] GameObject _managmentMenu;
    [SerializeField] GameObject _gameplayUI;

    CanvasController _cnvController;
    PlayerController _playerPr;

    private void Awake()
    {
        _playerPr = PlayerController.FindObjectOfType<PlayerController>();
        _cnvController = CanvasController.FindObjectOfType<CanvasController>();

        _cnvController.onManagment = false;
        _interactuableCanv.enabled = false;
        //_managmentMenu.SetActive(false);
    }

    private void Update()
    {
        CanvasInputs();
    }

    bool InFOV(Vector3 endPos)
    {
        Vector3 dir = endPos - transform.position;
        if (dir.magnitude > _viewRadius) return false;
        if (!InLOS(transform.position, endPos)) return false;
        return true;
    }

    bool InLOS (Vector3 start, Vector3 end)
    {
        Vector3 dir = end - start;
        return !Physics.Raycast(start, dir, dir.magnitude, _wallLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _viewRadius);
    }

    void CanvasInputs()
    {
        if (InFOV(_playerPr.transform.position))
        {
            _interactuableCanv.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                _cnvController.onManagment = true;
                _gameplayUI.SetActive(false);
                //_managmentMenu.SetActive(true);

                //var managmentScreen = Instantiate(Resources.Load<DecisionDialogue>(_managmentMenu.ToString()));

                ScreenManager.instance.Push(_managmentMenu.GetComponent<IScreen>());
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                _cnvController.onManagment = false;
                //_managmentMenu.SetActive(false);
                _gameplayUI.SetActive(true);
                ScreenManager.instance.Pop();
            }
        }
        else
            _interactuableCanv.enabled = false;
    }
}
