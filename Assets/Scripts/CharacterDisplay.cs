using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Sprite[] characterSprites;
    public int characterIndex;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = characterSprites[characterIndex];
    }

    public void next()
    {
        characterIndex++;
        changeDisplay();
    }
    public void back()
    {
        characterIndex--;
        changeDisplay();
    }
    public void changeTo(int x)
    {
        characterIndex = x;
        changeDisplay();
    }

    void changeDisplay()
    {
        if (characterIndex > characterSprites.Length - 1) { characterIndex = 0; }
        if (characterIndex < 0) { characterIndex = characterSprites.Length - 1; }

        GetComponent<Image>().sprite = characterSprites[characterIndex];
    }
}
