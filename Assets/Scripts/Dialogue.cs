using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [System.Serializable]
    public struct nameSentence
    {
        public bool isNPC; // NPC name
        [TextArea]
        public string sentence;
    }


    public string npcName;
    public nameSentence[] nameSentences;

    
}

