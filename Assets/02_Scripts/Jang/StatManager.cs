using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatManager : MonoBehaviour
{
    public static StatManager instance;

    private PlayerMovement playerMovement;

    [Header("Stat")]
    [SerializeField] private TextMeshProUGUI willPowerText;
    public int willPower = 100;

    void Awake()
    {
        instance = this;

        playerMovement = FindObjectOfType<PlayerMovement>();
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

        }
    }
}
