using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
   
    public GameObject[] options;
    public Text QuestionTxt;
    public GameObject QuizCanvas;
    public GameObject ChronometreCanvas;

    public List<QuestionAndAnswer> QnA;
    public int currentQuestions;
    public bool End=false;
   
    
    

    void Start(){
        generateQuestion();
    }

    void GameOver(){
        End = true;
        QuizCanvas.SetActive(false);
        ChronometreCanvas.SetActive(true);
    }

    public void correct(){
       
        QnA.RemoveAt(currentQuestions);
        generateQuestion();

    }
    public void wrong(){
        QuestionTxt.text = QnA[currentQuestions].Question;
    }

    void SetAnswers(){

        for(int i=0; i<options.Length; i++){
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestions].Answers[i];
            
            if(QnA[currentQuestions].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
            
        }
    }


    void generateQuestion(){
        print(QnA.Count);
        if(QnA.Count > 0){

        currentQuestions = Random.Range(0,QnA.Count);
        
        QuestionTxt.text = QnA[currentQuestions].Question;
        
        SetAnswers();

        }
        else{
            
            Debug.Log("Out of Questions");
            GameOver();
        }

    }

    public void Close(){
        QuizCanvas.SetActive(false);
    }

    
}
