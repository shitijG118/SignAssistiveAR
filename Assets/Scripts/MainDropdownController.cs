using UnityEngine;
using TMPro;

public class MainTMPDropdownController : MonoBehaviour
{
    public GameObject nestedTMPDropdown1;
    public GameObject nestedTMPDropdown2;
    public GameObject nestedTMPDropdown3;

    public TMP_Dropdown mainTMPDropdown;

    public void OnMainDropdownValueChanged(int index)
    {
        switch (index)
        {
            case 0: // "Nested 1" option is selected
                ShowNestedTMPDropdown1();
                HideNestedTMPDropdown2();
                HideNestedTMPDropdown3();
                break;
            case 1: // "Nested 2" option is selected
                HideNestedTMPDropdown1();
                ShowNestedTMPDropdown2();
                HideNestedTMPDropdown3();
                break;
            case 2: // "Nested 3" option is selected
                HideNestedTMPDropdown1();
                HideNestedTMPDropdown2();
                ShowNestedTMPDropdown3();
                break;
        }
    }

    private void ShowNestedTMPDropdown1()
    {
        nestedTMPDropdown1.SetActive(true);
    }

    private void HideNestedTMPDropdown1()
    {
        nestedTMPDropdown1.SetActive(false);
    }

    private void ShowNestedTMPDropdown2()
    {
        nestedTMPDropdown2.SetActive(true);
    }

    private void HideNestedTMPDropdown2()
    {
        nestedTMPDropdown2.SetActive(false);
    }

    private void ShowNestedTMPDropdown3()
    {
        nestedTMPDropdown3.SetActive(true);
    }

    private void HideNestedTMPDropdown3()
    {
        nestedTMPDropdown3.SetActive(false);
    }
}
