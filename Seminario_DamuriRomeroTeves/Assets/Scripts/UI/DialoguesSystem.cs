using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguesSystem : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public TextMeshProUGUI passText;
    public string[] lines;
    public float textSpeed;

    protected int _index;

    private void Start()
    {
        textComp.text = string.Empty;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(textComp.text == lines[_index])
                NextLine();
            else
            {
                StopAllCoroutines();
                textComp.text = lines[_index];
            }
        }
    }

    protected void StartDialogue()
    {
        _index = 0;

        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }

        StartCoroutine(TypeLine());
    }

    protected IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    protected void NextLine()
    {
        if(_index < lines.Length - 1)
        {
            _index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
