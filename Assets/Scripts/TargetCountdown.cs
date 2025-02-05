using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetCountdown : MonoBehaviour
{
    [SerializeField] private GameObject[] targetsNumber;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField]private TargetManager manager;
    //private int _targetsCurrentNumber;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //_targetsCurrentNumber = targetsNumber.Length;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = manager.TargetsCurrentNumber.ToString();
        // if (targetIsDead==true)
        // {
        //     targetIsDead = false;
        //     _targetsCurrentNumber--;
        //     countdownText.text = _targetsCurrentNumber.ToString();
        // }
        // else
        // {
        //     //countdownText.text = _targetsCurrentNumber.ToString();
        // }
    }

    public void SetTarget(GameObject target)
    {
        
       
    }
}