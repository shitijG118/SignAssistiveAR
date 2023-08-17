using UnityEngine;
using TMPro;
using System.Collections.Generic; // Add this line to include the List<> class.

public class TMPDropdownController : MonoBehaviour
{
    public TMP_Dropdown firstDropdown;
    public TMP_Dropdown secondDropdown;

    private void Start()
    {
        // Add a listener to the TMP Dropdown value change event
        firstDropdown.onValueChanged.AddListener(OnFirstDropdownValueChanged);

        // Populate the first dropdown with initial options
        firstDropdown.AddOptions(new List<string> { "Animals", "Greetings", "Alphabets" });

        // Manually call the value change method to populate the second dropdown initially
        OnFirstDropdownValueChanged(0);
    }

    public void OnFirstDropdownValueChanged(int value)
    {
        // Get the selected value of the first dropdown
        string selectedOption = firstDropdown.options[firstDropdown.value].text;

        // Clear the options of the second dropdown
        secondDropdown.ClearOptions();

        // Add options to the second dropdown based on the selected option from the first dropdown
        switch (selectedOption)
        {
            case "Animals":
                // Add options for Option A
                secondDropdown.AddOptions(new List<string> { "Tiger", "Lion", "Dog", "Bear", "Crocodile", "Deer", "Monkey", "Turtle","Camel","Cow","Giraffe","Cat","Donkey","Ox","Horse","Rabbit","Rat" });
                break;
            case "Greetings":
                // Add options for Option B
                secondDropdown.AddOptions(new List<string> { "Hello", "Bye", "Thank you" });
                break;
            case "Alphabets":
                // Add options for Option C
                secondDropdown.AddOptions(new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"});
                break;
        }

        // Refresh the TMP Dropdown to update its options
        secondDropdown.RefreshShownValue();
    }
}
