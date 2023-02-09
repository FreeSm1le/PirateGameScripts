using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    [SerializeField] private string _audioEventName;
    [SerializeField] private string _audioFolderName;
    [SerializeField] private bool _isInvestigated;
    public bool IsInvestigated => _isInvestigated;

    public Investigate()
    {
        IsInvestigated = true;
    }
}

