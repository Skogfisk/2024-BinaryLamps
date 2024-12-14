using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class Options : MonoBehaviour
{

    [SerializeField] public Slider questionsSlider;
    [SerializeField] public Slider volumeSlider;
    [SerializeField] public TMP_Text questionsText;
    public float volumeSliderValue;
    public int questionsSliderValue;

    void Awake()
    {

        //volumeSlider.value = volumeSliderValue;
        //questionsSlider.value = questionsSliderValue;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeMusicVolume()
    {
        volumeSliderValue = volumeSlider.value;
        MusicManager.Instance._AudioSource1.volume = volumeSlider.value;
    }

    public void ChangeQuestions()
    {
        questionsSliderValue = Mathf.RoundToInt(questionsSlider.value);
        QuestionsAmount.questionsAmount = questionsSliderValue;
    }

    public void UpdateQuestionText()
    {
        questionsText.text = Mathf.RoundToInt(questionsSlider.value).ToString();
    }


}
