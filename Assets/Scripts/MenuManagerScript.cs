using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    public GameObject p1Selector;
    public GameObject p2Selector;
    public int p1CharacterNum;
    public int p2CharacterNum;
    void Awake()
    {
        if (!GameObject.Find("MenuManager").Equals(gameObject)) { Destroy(gameObject); }
        if (SceneManager.GetActiveScene().name.Equals("Menu")) { DontDestroyOnLoad(gameObject); }
    }

    IEnumerator OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            p1Selector = GameObject.Find("P #1 Display"); p2Selector = GameObject.Find("P #2 Display");

            yield return new WaitForSeconds(0.1f);
            p1Selector.GetComponent<CharacterDisplay>().changeTo(p1CharacterNum);
            p2Selector.GetComponent<CharacterDisplay>().changeTo(p2CharacterNum);
        }
        
    }

    public void StartPressed()
    {
        p1CharacterNum = p1Selector.GetComponent<CharacterDisplay>().characterIndex;
        p2CharacterNum = p2Selector.GetComponent<CharacterDisplay>().characterIndex;
    }
}
