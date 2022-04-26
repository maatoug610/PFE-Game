﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    
    public QuizManager quizManager;

    

    public void Answer(){
    
        if(isCorrect){
            Debug.Log("Correct Answer");
            quizManager.correct();
            //this.GetComponent<Image>().color = Color.green;
        }

        else{
            Debug.Log("Wrong Answer");
            //this.GetComponent<Image>().color = Color.red;
            quizManager.wrong();
            
        }
    }

    

}
