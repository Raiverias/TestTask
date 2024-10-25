using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI progress;
    public TextMeshProUGUI instructions1;
    public TextMeshProUGUI instructions2;
    public GameObject completionScreen; 
    public void UpdateUI(int number) 
    {
        progress.text = "Прогресс: " + number +"/9";
        if(number == 9) 
        {
            GameComplete();
        }

    }
    void GameComplete() 
    {
        progress.gameObject.SetActive(false);
        instructions1.gameObject.SetActive(false);
        instructions2.gameObject.SetActive(false);
        completionScreen.gameObject.SetActive(true);
    }
    
}
