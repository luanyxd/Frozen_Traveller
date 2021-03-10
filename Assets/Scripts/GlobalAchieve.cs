using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAchieve : MonoBehaviour
{
    // General Variables
    public GameObject achNote;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //Achievement 01 Specific
    public GameObject ach01Image;
    public static int ach01Count;
    public int ach01Trigger = 3;
    public int ach01Code = 0;

    public int ach02Code = 0;
    public static bool ach02Trigger = false;

    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
    
    // Update is called once per frame
    void Update()
    {
        ach01Code = PlayerPrefs.GetInt("Ach01");
        ach02Code = PlayerPrefs.GetInt("Ach02");
        if (ach01Count == ach01Trigger && ach01Code != 1)
        {
            Debug.Log("Ach01 Triggered!" + ach01Count);
            StartCoroutine(Trigger01Ach());
        }
        if (ach02Code != 1 && ach02Trigger == true)
        {
            Debug.Log("Ach02 Triggered!");
            StartCoroutine(Trigger02Ach());
        }
    }

    IEnumerator Trigger01Ach()
    {
        Debug.Log("Hello trigger: " + ach01Count);
        achActive = true;
        ach01Code = 1;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        
        
        Debug.Log("Hello trigger: " + ach01Count);

        //achSound.Play();
        ach01Image.SetActive(true);

        achTitle.GetComponent<Text>().text = "COLLECTION!";
        achDesc.GetComponent<Text>().text = "Created a collection based achievement!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        //resetting UI
        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Code = 1;
        PlayerPrefs.SetInt("Ach02", ach02Code);

        //achSound.Play();
        ach01Image.SetActive(true);

        achTitle.GetComponent<Text>().text = "LEVEL COMPLETE!";
        achDesc.GetComponent<Text>().text = "Created a level completed based achievement!";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        //resetting UI
        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
