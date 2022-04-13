using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript2 : MonoBehaviour
{
    public bool isCorrect = false;
    
    public QuizManager2 quizManager;

    

    public void Answer(){
    
        if(isCorrect){
            Debug.Log("Correct Answer");
            quizManager.correct();
          
             
        }

        else{
            Debug.Log("Wrong Answer");
            quizManager.wrong();
            
        }
    }

}
