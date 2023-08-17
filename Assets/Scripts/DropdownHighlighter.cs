using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageColorChanger : MonoBehaviour
{
    public TMP_Dropdown dropdown1;
    public TMP_Dropdown dropdown2;
    public TMP_Dropdown dropdown3;

    public Image image1;
    public Image image2;
    public Image image3;

    // You can add more images and corresponding TMP Dropdowns if needed

    void Update()
    {
        // Set the highlight color for the selected image (Dark green)
        Color highlightColor = new Color(0.0f, 0.5f, 0.0f);

        // Reset colors for all images
        ResetImageColors();

        // Highlight the image corresponding to the currently selected option of each dropdown
        HighlightSelectedImage(dropdown1, image1, highlightColor);
        HighlightSelectedImage(dropdown2, image2, highlightColor);
        HighlightSelectedImage(dropdown3, image3, highlightColor);
    }

    private void ResetImageColors()
    {
        // Reset color for all images to FD960B 
        image1.color = new Color(0.992f, 0.376f, 0.043f);
        image2.color = new Color(0.992f, 0.376f, 0.043f);
        image3.color = new Color(0.992f, 0.376f, 0.043f);
        // Add more images here if you have more
    }

    private void HighlightSelectedImage(TMP_Dropdown dropdown, Image image, Color highlightColor)
    {
        int selectedIndex = dropdown.value;
        if (image == image1 && selectedIndex == 0)
            image.color = highlightColor;
        else if (image == image2 && selectedIndex == 1)
            image.color = highlightColor;
        else if (image == image3 && selectedIndex == 2)
            image.color = highlightColor;
        // Add more dropdown-image mappings here if you have more
    }
}
