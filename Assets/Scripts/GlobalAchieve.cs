using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Achievement
{
    public string id;
    public string title;
    public string description;
    public Sprite achImage;
    public bool active;
    public int code;

    public virtual bool checkAchieved()
    {
        return this.active;
    }
    public void SetActive(bool active)
    {
        this.active = active;
    }
}

[System.Serializable]
public class CollectionAchievement : Achievement
{    
    public int counter;
    public int goal;
    public override bool checkAchieved()
    {
        if(counter >= goal)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class GlobalAchieve : MonoBehaviour
{
    // General Variables
    public GameObject achNote;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //Achievement 01 Specific
    public GameObject achImage;
    public static int ach01Count;
    public int ach01Trigger = 3;
    public int ach01Code = 0;

    public int ach02Code = 0;
    public Achievement[] achievements;
    public CollectionAchievement[] collectionAchievements;
    public static bool ach02Trigger = false;


    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Awake()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        foreach(Achievement a in achievements){
            a.code = PlayerPrefs.GetInt(a.id);
            if(a.code != 1 && a.active == true)
            {
                StartCoroutine(TriggerAchievement(a));
            }
        }

        foreach(CollectionAchievement a in collectionAchievements){
            a.code = PlayerPrefs.GetInt(a.id);
            if(a.code != 1 && a.counter >= a.goal)
            {
                StartCoroutine(TriggerAchievement(a));
            }
        }
    }

    public Achievement findAchievementById(string id)
    {
        return Array.Find(achievements, a => a.id == id);
    }

    public CollectionAchievement findCollectionAchievementById(string id)
    {
        return Array.Find(collectionAchievements, a => a.id == id);
    }

    public void increaseCollectionAchievementById(string id)
    {
        CollectionAchievement a = findCollectionAchievementById(id);
        a.counter += 1;
    }

    IEnumerator TriggerAchievement(Achievement ach)
    {
        achActive = true;
        ach.code = 1;
        //achSound.Play();
        achImage.SetActive(true);
        achTitle.GetComponent<Text>().text = ach.title;
        achDesc.GetComponent<Text>().text = ach.description;
        achImage.GetComponent<Image>().sprite = ach.achImage;
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);
        //resetting UI
        achNote.SetActive(false);
        achImage.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
    }
}
