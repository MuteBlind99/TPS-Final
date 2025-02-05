using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    List<Target> _targets ;
    private int _targetsCurrentNumber=16;
    public int TargetsCurrentNumber=> _targetsCurrentNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _targets = new List<Target>(GetComponentsInChildren<Target>());
        foreach (Target oneTarget in _targets)
        {
            oneTarget.OnDestroy+=ItemDestroyed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ItemDestroyed(Target oneTarget)
    {
        _targets.Remove(oneTarget);
        _targetsCurrentNumber--;
    }
}
