using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SoloDialogo : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float textSpeed;
    public int maxDialog;
    private int _index;
    private bool finalDialogue;

    private void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComp.text == lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[_index];
            }
        }

        if (finalDialogue && Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        _index = 0;
        finalDialogue = false;

        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }

        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else if (_index == maxDialog)
        {
            // Activar finalDialogue cuando se alcanza el último diálogo
            finalDialogue = true;
        }
    }
}
