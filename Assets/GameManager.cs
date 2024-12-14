using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public InputField answerField;
    
    public Text score;
    public Text feedback;
    public Text timer;
    public int questionsAmount = 10;

    public static float currentTime = 0.0f;
    public static int currentScore = 0;
    public static int askedQuestions = 0;
    int questionType;
    private bool gameEnded = false;
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    private Question currentQuestion2;


    // Start is called before the first frame update
    void Start()
    {
        questionsAmount = QuestionsAmount.questionsAmount;
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        setQuestion();
        Debug.Log(currentQuestion.binaryArray[0]);
        answerField.ActivateInputField();

    }

    void Update()
    {
        score.text = "Score:  " + currentScore;

        if(!gameEnded){
            currentTime += Time.deltaTime;
            timer.text = "Time: " + (int)(currentTime);
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            UserAnswer();
        }

        if (Input.GetKey("escape"))
        {
            BacktoMenu();
        }
    }

    void setQuestion() {

        int randomQuestionIndex = Random.Range (1, unansweredQuestions.Count);
        // selects randomly what type of question next one is, 0 = binarynumber, 1= addition, 2= subtraction
        questionType = Random.Range(0, 3);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        if (questionType > 0) // if question is not just one binarynumber select another number
        {
            int randomQuestionIndex2 = Random.Range(1, unansweredQuestions.Count);
            currentQuestion2 = unansweredQuestions[randomQuestionIndex2];
        }

        GameObject lamp0 = GameObject.Find("Lamp0");
        GameObject lamp1 = GameObject.Find("Lamp1");
        GameObject lamp2 = GameObject.Find("Lamp2");
        GameObject lamp3 = GameObject.Find("Lamp3");
        GameObject lamp4 = GameObject.Find("Lamp4");
        GameObject lamp5 = GameObject.Find("Lamp5");
        GameObject lamp6 = GameObject.Find("Lamp6");
        GameObject lamp7 = GameObject.Find("Lamp7");
        GameObject minus = GameObject.Find("Minus");
        GameObject plus = GameObject.Find("Plus");
        GameObject lamp00 = GameObject.Find("Lamp00");
        GameObject lamp01 = GameObject.Find("Lamp01");
        GameObject lamp02 = GameObject.Find("Lamp02");
        GameObject lamp03 = GameObject.Find("Lamp03");
        GameObject lamp04 = GameObject.Find("Lamp04");
        GameObject lamp05 = GameObject.Find("Lamp05");
        GameObject lamp06 = GameObject.Find("Lamp06");
        GameObject lamp07 = GameObject.Find("Lamp07");

        if ( currentQuestion.binaryArray[8] == 1 )
            {
                lamp0.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[7] == 1 )
            {
                lamp1.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[6] == 1 )
            {
                lamp2.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[5] == 1 )
            {
                lamp3.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[4] == 1 )
            {
                lamp4.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[3] == 1 )
            {
                lamp5.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[2] == 1 )
            {
                lamp6.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if( currentQuestion.binaryArray[1] == 1 )
            {
                lamp7.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        if (questionType > 0)
        {
            minus.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            if (questionType == 1)
            {
                plus.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }

            if (currentQuestion2.binaryArray[8] == 1)
            {
                lamp00.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[7] == 1)
            {
                lamp01.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[6] == 1)
            {
                lamp02.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[5] == 1)
            {
                lamp03.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[4] == 1)
            {
                lamp04.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[3] == 1)
            {
                lamp05.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion2.binaryArray[2] == 1)
            {
                lamp06.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
            if (currentQuestion.binaryArray[1] == 1)
            {
                lamp07.GetComponent<Renderer>().material.color = new Color(255, 255, 0);
            }
        }

    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredQuestions.Remove(currentQuestion);
        unansweredQuestions.Remove(currentQuestion2);

        yield return new WaitForSeconds(2);
        if( askedQuestions < questionsAmount )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else{
            gameEnded = true;
            feedback.text = "Game Over.\nYour score is " + currentScore.ToString() + " correct out of " + questionsAmount.ToString() +" questions.\nPress ESC to quit.";
        }
        answerField.ActivateInputField();
    }

    public void UserAnswer ()
    {

        if (questionType == 0 && currentQuestion.binaryArray[0].ToString() == answerField.text )
        {
            Debug.Log("Player answered " + answerField.text );
            feedback.text += "Correct answer";
            currentScore += 1;
        }
        else if (questionType == 1 && (currentQuestion.binaryArray[0] + currentQuestion2.binaryArray[0]).ToString() == answerField.text)
        {
            Debug.Log("Player answered " + answerField.text);
            feedback.text += "Correct answer";
            currentScore += 1;
        }
        else if (questionType == 2 && (currentQuestion.binaryArray[0] - currentQuestion2.binaryArray[0]).ToString() == answerField.text)
        {
            Debug.Log("Player answered " + answerField.text);
            feedback.text += "Correct answer";
            currentScore += 1;
        }
        else
        {
            Debug.Log("Player answered " + answerField.text );
            if (questionType == 0)
            {
                feedback.text += "Wrong answer, correct answer is " + currentQuestion.binaryArray[0].ToString();
            }
            else if (questionType == 1)
            {
                feedback.text += "Wrong answer, correct answer is " + (currentQuestion.binaryArray[0] + currentQuestion2.binaryArray[0]).ToString();
            }
            else if (questionType == 2)
            {
                feedback.text += "Wrong answer, correct answer is " + (currentQuestion.binaryArray[0] - currentQuestion2.binaryArray[0]).ToString();
            }
        }
        askedQuestions += 1;
        Debug.Log(askedQuestions);
        StartCoroutine(TransitionToNextQuestion());

    }

    public void BacktoMenu()
    {
        Debug.Log("Quit");
        SceneManager.LoadScene(0);
    }

   
}
