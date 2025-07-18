using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Transform popupText;
    public Transform popupTextParent;

    public Text hitAmountText;
    public int hitAmount;

    private void Start()
    {
        hitAmount = PlayerPrefs.GetInt("HitAmount");
        hitAmountText.text = $"击杀红豆: {hitAmount}";
    }

    public void HitRedBean()
    {
        // play sound
        audioSource.PlayOneShot(audioClip);

        // kill + 1
        Instantiate(popupText, popupTextParent);

        // save
        hitAmountText.text = $"击杀红豆:{++hitAmount}";

    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("HitAmount", hitAmount);
    }
}
