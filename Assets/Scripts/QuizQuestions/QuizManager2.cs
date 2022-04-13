using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager2 : MonoBehaviour
{
    public List<QuestionAndAnswer2> QnA;
    public GameObject[] options;
    public int currentQuestions;

    public Text QuestionTxt;
    public GameObject QuizCanvas;
    public GameObject ChronometreCanvas;
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
            options[i].GetComponent<AnswerScript2>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestions].Answers[i];
            
            if(QnA[currentQuestions].CorrectAnswer == i+1){
                options[i].GetComponent<AnswerScript2>().isCorrect = true;
            }
            
        }
        
    }


    void generateQuestion(){
       
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
