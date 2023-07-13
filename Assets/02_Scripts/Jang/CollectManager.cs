using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Collection
{
    collect1,
    collect2,
    collect3
}

public class CollectManager : MonoBehaviour
{
    public static CollectManager instance;

    public PlayerMovement playerMove;
    public GameObject panel, handLight, gameUI;
    public Image panelImage;
    public PlayableDirector playerDirector;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI coll1Text;
    [SerializeField] private TextMeshProUGUI coll2Text;
    [SerializeField] private TextMeshProUGUI coll3Text;
    [Header("Value")]
    [SerializeField] private int collect1Max;
    [SerializeField] private int collect2Max;
    [SerializeField] private int collect3Max;
    [SerializeField] private int collectLength;
    private int coll1, coll2, coll3;
    public int maxLength;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        AllCollect();
    }

    private void AllCollect()
    {
        if (maxLength >= collectLength)
        {
            //������ũ��Ʈ enable ���ֱ�
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            handLight.SetActive(false);
            gameUI.SetActive(false);
            panel.SetActive(true);
            playerMove.enabled = false;

            playerDirector.Play();

            if (playerDirector.time >= playerDirector.duration - 1.5f)
            {
                panelImage.DOFade(1, 1).OnComplete(() => {
                    SceneManager.LoadScene("BackinUI");
                });
            }
        }
    }

    public void CollectionLight()
    {
        GameObject[] collects = GameObject.FindGameObjectsWithTag("Collection");
        foreach (GameObject collect in collects)
        {
            collect.GetComponent<Collider>().transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
    }

    public void OnColl(Collection col)
    {
        switch (col)
        {
            case Collection.collect1:
                coll1++;
                coll1Text.text = $"Collect1 {coll1}/{collect1Max}";
                if (coll1 < collect1Max)
                    maxLength++;
                break;
            case Collection.collect2:
                coll2++;
                coll2Text.text = $"Collect2 {coll2}/{collect2Max}";
                if (coll2 < collect2Max)
                    maxLength++;
                break;
            case Collection.collect3:
                coll3++;
                coll3Text.text = $"Collect3 {coll3}/{collect3Max}";
                if (coll3 < collect3Max)
                    maxLength++;
                break;
        }
    }
}
