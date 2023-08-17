using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class AnimationLayerController : MonoBehaviour
{
    public Animator animator;
    public TMP_Dropdown animationDropdown;
    public TMP_Dropdown secondDropdown; // Reference to the second TMP dropdown
    public GameObject panelObject; // Reference to the Canvas panel GameObject
    public GameObject[] arModels; // Array of 3D models corresponding to animal options in the second dropdown

    private int currentLayerIndex = 0;
    private int lastAnimationDropdownIndex = 0; // Store the last selected index of the animationDropdown
    private GameObject activeARModel; // Reference to the currently active AR model
    private Dictionary<int, int> layerToModelIndex; // Dictionary to map animation layer indices to AR model indices

    private Dictionary<string, int> secondDropdownToLayerIndex; // Dictionary to map second dropdown options to animation layer indices
    private Dictionary<string, GameObject> secondDropdownToARModel; // Dictionary to map second dropdown options to AR models

    private void Start()
    {
        layerToModelIndex = new Dictionary<int, int>();

        // Populate the dictionary based on the array indices
        for (int i = 0; i < Mathf.Min(animator.layerCount, arModels.Length); i++)
        {
            layerToModelIndex[i] = i;
        }

        // Set the initial animation layer
        SetAnimationLayer(0);
        panelObject.SetActive(true);

        // Initialize the dictionaries
        InitializeDictionaries();

        // Add a listener to the TMP dropdown's onValueChanged event
        animationDropdown.onValueChanged.AddListener(OnAnimationDropdownChanged);

        // Add a listener to the second TMP dropdown's onValueChanged event
        secondDropdown.onValueChanged.AddListener(OnSecondDropdownChanged);

        // Update the panel text with the initial value from the first dropdown
        UpdatePanelText(animationDropdown.options[currentLayerIndex].text);

        // Disable all AR models at the start
        foreach (GameObject model in arModels)
        {
            model.SetActive(false);
        }
        arModels[0].SetActive(true);
        activeARModel = arModels[0];
    }

    private void InitializeDictionaries()
    {
        // Initialize the secondDropdownToLayerIndex dictionary
        secondDropdownToLayerIndex = new Dictionary<string, int>
        {
            { "Tiger", 0 }, // Map "Tiger" to the second layer (index 1)
            { "Lion", 1 }, // Map "Lion" to the third layer (index 2)
            { "Dog", 2 }, // Map "Dog" to the fourth layer (index 3)
            { "Bear", 3 },
            { "Crocodile", 4 },
            { "Deer", 5 },
            { "Monkey", 6 },
            { "Turtle", 7 },
            { "Hello", 8 },
            { "Bye", 9 },
            { "Thank you", 10 },
            { "A", 11 },
            { "B", 12 },
            { "C", 13 },
            { "D", 14 },
            { "E", 15 },
            { "F", 16 },
            { "G", 17 },
            { "H", 18 },
            { "I", 19 },
            { "J", 20 },
            { "K", 21 },
            { "L", 22 },
            { "M", 23 },
            { "N", 24 },
            { "O", 25 },
            { "P", 26 },
            { "Q", 27 },
            { "R", 28 },
            { "S", 29 },
            { "T", 30 },
            { "U", 31 },
            { "V", 32 },
            { "W", 33 },
            { "X", 34 },
            { "Y", 35 },
            { "Z", 36 },
            { "Camel", 37 },
            { "Cow", 38 },
            { "Giraffe", 39 },
            { "Cat", 40 },
            { "Donkey", 41 },
            { "Ox", 42 },
            { "Horse", 43 },
            { "Rabbit", 44 },
            { "Rat", 45 },

            // Add mappings for other animal options as needed
        };

        // Initialize the secondDropdownToARModel dictionary
        secondDropdownToARModel = new Dictionary<string, GameObject>
        {
            { "Tiger", arModels[0] }, // Map "Tiger" to the first AR model
            { "Lion", arModels[1] }, // Map "Lion" to the second AR model
            { "Dog", arModels[2] }, // Map "Dog" to the third AR model
            { "Bear", arModels[3] },
            { "Crocodile", arModels[4] },
            { "Deer", arModels[5] },
            { "Monkey", arModels[6] },
            { "Turtle", arModels[7] },
            { "Camel", arModels[8] },
            { "Cow", arModels[9] },
            { "Giraffe", arModels[10] },
            { "Cat", arModels[11] },
            { "Donkey", arModels[12] },
            { "Ox", arModels[13] },
            { "Horse", arModels[14] },
            { "Rabbit",arModels[15] },
            { "Rat", arModels[16] },
            // Add mappings for other animal options as needed
        };
    }

    private void OnAnimationDropdownChanged(int newIndex)
    {
        // Update the panel text with the selected value from the first TMP dropdown if the second dropdown is not active
        if (!secondDropdown.isActiveAndEnabled)
        {
            UpdatePanelText(animationDropdown.options[newIndex].text);
        }

        // Set the last selected index for the animationDropdown
        lastAnimationDropdownIndex = newIndex;
    }

   private void OnSecondDropdownChanged(int newIndex)
    {
        // Get the selected value from the second TMP dropdown
        string selectedOption = secondDropdown.options[newIndex].text;

        // Update the animation layer based on the selected value from the second TMP dropdown
        if (secondDropdownToLayerIndex.TryGetValue(selectedOption, out int layerIndex))
        {
            SetAnimationLayer(layerIndex);
        }

        // Update the panel text with the selected value from the second TMP dropdown
        UpdatePanelText(selectedOption);

        // Deactivate all AR models initially
        foreach (GameObject model in arModels)
        {
            model.SetActive(false);
        }

        // Activate the corresponding AR model if available
        if (secondDropdownToARModel.TryGetValue(selectedOption, out GameObject arModel))
        {
            if (arModel != null)
            {
                // Activate the corresponding AR model
                arModel.SetActive(true);
                activeARModel = arModel;
            }
        }
    }

    private void SetAnimationLayer(int layerIndex)
    {
        if (layerIndex < animator.layerCount)
        {
            // Disable the previous layer
            animator.SetLayerWeight(currentLayerIndex, 0f);

            // Enable the new selected layer
            animator.SetLayerWeight(layerIndex, 1f);

            currentLayerIndex = layerIndex;
        }
    }

    private void UpdatePanelText(string newText)
    {
        // Assuming panelObject is the parent of the TextMeshProUGUI component
        TextMeshProUGUI panelText = panelObject.GetComponentInChildren<TextMeshProUGUI>();
        if (panelText != null)
        {
            panelText.text = "ISL SIGN FOR :  " + newText;
        }
    }
}
