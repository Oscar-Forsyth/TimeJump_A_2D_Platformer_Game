using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerDialog : MonoBehaviour{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject player;

    public GameObject spareButton;
    public GameObject killButton;
    private string KILL_TEXT = "You killed him, on a hunch. What a shame";
    private string SPARE_TEXT = "The future remains the same. Try harder";

    private bool played = false;
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!played)
        {
            StartCoroutine(Type());
            played = true;
            LevelManager.instance.setCanMove(false);
        }

        
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            
        }
        if (killButton != null && spareButton != null )
        {
            if (textDisplay.text == sentences[0])
            {
                continueButton.SetActive(false);
                killButton.SetActive(true);
                spareButton.SetActive(true);
            }
                
        }

    }
    public void kill()
    {
        sentences[index+1] += KILL_TEXT;
        Finish();

    }
    public void spare()
    {
        sentences[index+1] += SPARE_TEXT;
        Finish();
    }
    private void Finish()
    {
        NextSentence();
        killButton.SetActive(false);
        spareButton.SetActive(false);
        continueButton.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);
     
     

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false); 
            LevelManager.instance.setCanMove(true);
        }
    }
}
