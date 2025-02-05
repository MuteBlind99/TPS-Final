using TMPro;
using UnityEngine;

public class TargetCountdown : Target
{
    [SerializeField] private GameObject[] targetsNumber;
    [SerializeField] private TextMeshProUGUI countdownText;

    private int _targetsCurrentNumber=16;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Awake()
    // {
    //     _targetsCurrentNumber = targetsNumber.Length;
    // }

    // Update is called once per frame
    void Update()
    {
        if (targetIsDead==true)
        {
            targetIsDead = false;
            _targetsCurrentNumber--;
            countdownText.text = _targetsCurrentNumber.ToString();
        }
        else
        {
            countdownText.text = _targetsCurrentNumber.ToString();
        }
    }
}