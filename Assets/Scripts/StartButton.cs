using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject p1Selector;
    public GameObject p2Selector;
    public int p1CharacterNum;
    public int p2CharacterNum;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu")) { DontDestroyOnLoad(gameObject); }
    }
    public void StartPressed()
    {
        p1CharacterNum = p1Selector.GetComponent<CharacterDisplay>().characterIndex;
        p2CharacterNum = p2Selector.GetComponent<CharacterDisplay>().characterIndex;
        SceneManager.LoadScene("Level-1");
    }
}
