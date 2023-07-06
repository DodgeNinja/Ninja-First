using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;

    private PlayerMovement playerMovement;

    private Ending ending;

    [Header("Stat")]
    [SerializeField] private TextMeshProUGUI willPowerText;
    public int willPower = 100;

    void Awake()
    {
        instance = this;

        playerMovement = FindObjectOfType<PlayerMovement>();
        ending = FindObjectOfType<Ending>();
    }

    void Update()
    {
        willPowerText.text = $"WillPower : {willPower}";
        GameOver();
    }

    public void PlayerBoost(float value, float time)
    {
        playerMovement.boostSpeed = value;
        playerMovement.boostTime = time;
        playerMovement.time = 0;
    }

    void GameOver()
    {
        if (willPower <= 0)
        {

            ending.End();
        }
    }
}
