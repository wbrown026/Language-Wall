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
    #endregion

    #region Private Variables
    private Button _activeButton = null;
    private bool _activeButtonOnForm = false;
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
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
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
}
