using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExampleController : MonoBehaviour
{
    public AirtableManager airtableManager;

    [Header("Questions")]
    public Slider question1Slider;
    public Slider question2Slider;
    public Slider question3Slider;
    public Slider question4Slider;
    public Slider question5Slider;

    public TMP_Text question1Value;
    public TMP_Text question2Value;
    public TMP_Text question3Value;
    public TMP_Text question4Value;
    public TMP_Text question5Value;

    public TMP_Text question1Level;
    public TMP_Text question2Level;
    public TMP_Text question3Level;
    public TMP_Text question4Level;
    public TMP_Text question5Level;

    public string question1;
    public string question2;
    public string question3;
    public string question4;
    public string question5;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        question1Value.text = question1Slider.value.ToString();
        question2Value.text = question2Slider.value.ToString();
        question3Value.text = question3Slider.value.ToString();
        question4Value.text = question4Slider.value.ToString();
        question5Value.text = question5Slider.value.ToString();
    }

    public void SaveResultsToAirtable()
    {
        airtableManager.question1result = question1Slider.value.ToString();
        airtableManager.question2result = question2Slider.value.ToString();
        airtableManager.question3result = question3Slider.value.ToString();
        airtableManager.question4result = question4Slider.value.ToString();
        airtableManager.question5result = question5Slider.value.ToString();

        airtableManager.CreateRecord();
    }
}
