using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public Text timeField;
    public Text wordToFindField;
    private float time;
    private string[] wordsLocal = { "ONCOM", "TEMPE", "TAHU", "AYAM", "BEBEK", "TERONG" };
    private string chosenWord;
    private string hiddenWord;

        // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Amount of items inside of wordsLocal is " + wordsLocal.Length);
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        wordToFindField.text = chosenWord;
        Debug.Log(wordToFindField.text);

    }

    // Update is called once per frame
    void Update() 
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
    }
}
