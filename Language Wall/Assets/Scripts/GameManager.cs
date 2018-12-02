using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    #region Public Variables
    // Form Buttons
    public Button lastNameForm;
    public Button firstNameForm;
    public Button dateForm;
    public Button dateOfBirthForm;
    public Button socialSecurityNumberForm;
    public Button employeeTelephoneNumberForm;

    [Space(10)]

    // Document Buttons
    public Button lastName;
    public Button firstName;
    public Button date;
    public Button dateOfBirth;
    public Button socialSecurityNumber;
    public Button employeeTelephoneNumber;
    public Button test;

    [Space(10)]
    //GameObjects
    public GameObject scorePanel;
    public GameObject playAgain;
    public Text scoreText;
    #endregion

    #region Private Variables
    private Button _activeButton = null;
    private bool _activeButtonOnForm = false;
    private int _score = 0;
    private int _maxScore = 6; //The max score that the player must get to win
    #endregion

    #region Built In Methods
    private void Start()
    {
        // Form Buttons
        lastNameForm.onClick.AddListener(delegate { SetActive(lastNameForm, true); });
        firstNameForm.onClick.AddListener(delegate { SetActive(firstNameForm, true); });
        dateForm.onClick.AddListener(delegate { SetActive(dateForm, true); });
        dateOfBirthForm.onClick.AddListener(delegate { SetActive(dateOfBirthForm, true); });
        socialSecurityNumberForm.onClick.AddListener(delegate { SetActive(socialSecurityNumberForm, true); });
        employeeTelephoneNumberForm.onClick.AddListener(delegate { SetActive(employeeTelephoneNumberForm, true); });

        // Document Buttons
        lastName.onClick.AddListener(delegate { SetActive(lastName, false); });
        firstName.onClick.AddListener(delegate { SetActive(firstName, false); });
        date.onClick.AddListener(delegate { SetActive(date, false); });
        dateOfBirth.onClick.AddListener(delegate { SetActive(dateOfBirth, false); });
        socialSecurityNumber.onClick.AddListener(delegate { SetActive(socialSecurityNumber, false); });
        employeeTelephoneNumber.onClick.AddListener(delegate { SetActive(employeeTelephoneNumber, false); });
        test.onClick.AddListener(delegate { SetActive(test, false); });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Detects whether or not the mouse clicked
        {
            //If the score panel thing is Active AND Score != 6 then make it disappear
            if (scorePanel.gameObject.activeSelf == true && _score != _maxScore)
            {
                scorePanel.SetActive(false);
                _score = 0; //resetting the score
            }
        }

        if(Input.GetKeyDown("escape"))
        {
            Debug.Log("I escaped. Haha");
            Application.Quit();
        }

        
    }
    #endregion

    #region Methods
    public void SetActive(Button other, bool onForm)
    {
        Debug.Log(other);
        if (_activeButton == null)
        {
            _activeButtonOnForm = onForm;
            _activeButton = other;
            _activeButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            if (_activeButtonOnForm && !onForm)
            {
                Debug.Log(other.transform.GetChild(0).GetComponent<Text>().text);
                _activeButton.transform.GetChild(0).GetComponent<Text>().text = other.transform.GetChild(0).GetComponent<Text>().text;
                _activeButton.GetComponent<Image>().color = Color.white;
                _activeButton = null;
                onForm = false;
            }
            else if (!_activeButtonOnForm && onForm)
            {
                Debug.Log(_activeButton.transform.GetChild(0).GetComponent<Text>().text);
                other.transform.GetChild(0).GetComponent<Text>().text = _activeButton.transform.GetChild(0).GetComponent<Text>().text;
                _activeButton.GetComponent<Image>().color = Color.white;
                _activeButton = null;
                onForm = false;
            }
            else
            {
                _activeButton.GetComponent<Image>().color = Color.white;
                _activeButton = other;
                _activeButton.GetComponent<Image>().color = Color.red;
            }
        }

    }
    #endregion

    /**
     * This function is called when "Next Form" is clicked in the Game Scene 
     * Goes to the next level
     */
    public void playAgain_OnClick(string mainMenu)
    {
        Application.LoadLevel(mainMenu);
    }

    /**
     * This function is called when the "Submit" button is clicked in the Game Scene
     */
    public void CalculateScore()
    {
        //Compare EACH field and if one of them matches, then the score increases by 1
        string formField = lastNameForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        string idField = lastName.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        formField = firstNameForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        idField = firstName.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        formField = dateForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        idField = date.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        formField = dateOfBirthForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        idField = dateOfBirth.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        formField = socialSecurityNumberForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        idField = socialSecurityNumber.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        formField = employeeTelephoneNumberForm.transform.GetChild(0).GetComponent<Text>().text; //This one of the values in the Form
        idField = employeeTelephoneNumber.transform.GetChild(0).GetComponent<Text>().text; //This is one of the values of the immigrant's id snippets
        if (formField.Equals(idField))
        {
            _score++;
        }

        Debug.Log("Score: " + _score);

        //Display the result window
        scorePanel.SetActive(true);
        bool win = _score == _maxScore; //Score must be 6 in order for player to win

        if (win)
        {
            scoreText.text = "Score: " + _score + "\n \"Thank you for the form.\"";
            //Set the Continue button to be active
            playAgain.SetActive(true);
        }
        else
        {
            scoreText.text = "Score: " + _score + "\n \"The form is incorrect or incomplete. Please try again\"";
        }
    }

}