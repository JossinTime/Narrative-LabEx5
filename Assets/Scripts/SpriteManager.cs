using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SpriteManager : MonoBehaviour
{
    public GameObject journalSprite;
    public Animator animator;
    private void Start()
    {
        journalSprite.SetActive(false);
    }

    [YarnCommand("disable_journal_sprite")]
    public void DisableJournalSprite()
    {
        if (journalSprite != null)
        {
            journalSprite.SetActive(false);
        }
    }

    [YarnCommand("enable_journal_sprite")]
    public void EnableJournalSprite()
    {
        if (journalSprite != null)
        {
            journalSprite.SetActive(true);
        }
    }

    

}
