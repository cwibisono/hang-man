using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    //private string[] wordsLocal = { "ONCOM", "TEMPE", "TAHU", "AYAM GORENG", "BEBEK", "TERONG" };
    private string[] word = File.ReadAllLines(@"Assets/Food.txt");
    private string chosenWord;
    private string hiddenWord;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;   
    private int fails;
    private bool gameEnd = false;

        // Start is called before the first frame update
    void Start()
    {
            
        // for (int i = 0; i < wordsLocal.Length; i++)
        // {
        //     Debug.Log(wordsLocal[i]); 
        // }
        
        chosenWord = word[Random.Range(0, word.Length)];
        Debug.Log(chosenWord);
        
        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_";
            }
        }

        wordToFindField.text = hiddenWord;
        //Debug.Log(wordToFindField.text);

    }
    
    // Update is called once per frame
    void Update() 
    {
        if (gameEnd == false)
        {
            time += Time.deltaTime;
            timeField.text = time.ToString();
        }
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
                    //set new hidden word to everything before the i
                    //change the i to the letter pressed, and everything after the i
                    hiddenWord = hiddenWord.Substring(0, i) + pressedLetter + hiddenWord.Substring(i + 1);
                    Debug.Log(hiddenWord);
                    
                    chosenWord = chosenWord.Substring(0, i) + "_" + chosenWord.Substring(i + 1);
                    Debug.Log(chosenWord);
                    
                    i = chosenWord.IndexOf(pressedLetter);
                }

                wordToFindField.text = hiddenWord;
            }
            //add hangman body parts
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
            //case lost
            if (fails == hangMan.Length)
            {
                loseText.SetActive(true);
                gameEnd = true;
            }

            if (!hiddenWord.Contains("_"))
            {
                winText.SetActive(true);
                gameEnd = true;
            }
        }
    }
    
}


