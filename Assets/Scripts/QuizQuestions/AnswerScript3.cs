using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript3 : MonoBehaviour
{
    public bool isCorrect = false;
    
    public QuizManager3 quizManager;

    

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
