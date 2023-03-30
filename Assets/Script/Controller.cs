using System;
using System.Collections;
using System.Collections.Generic;
using MiscUtil.Collections.Extensions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    public Text timeField;
    public Text wordToFindField;
    private float time;
    private string[] wordsLocal = { "ONCOM", "TEMPE", "TAHU", "AYAM GORENG", "BEBEK", "TERONG" };
    private string chosenWord;
    private string hiddenWord;

        // Start is called before the first frame update
    void Start()
    {
            
        // for (int i = 0; i < wordsLocal.Length; i++)
        // {
        //     Debug.Log(wordsLocal[i]); 
        // }
        
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        
        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += "  ";
            }
            else
            {
                hiddenWord += "_ ";
            }
        }

        wordToFindField.text = hiddenWord;
        //Debug.Log(wordToFindField.text);

    }
    
    // Update is called once per frame
    void Update() 
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
    }

    private void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressedLetter = e.keyCode.ToString();
            
            Debug.Log("Keydown event was triggered " + pressedLetter);
            
            if (chosenWord.Contains(pressedLetter))
            {
                int i = chosenWord.IndexOf(pressedLetter);
                while (i !=-1)
                {
                    
                }
            }
            else
            {
                
            }
        }
    }
    
}
