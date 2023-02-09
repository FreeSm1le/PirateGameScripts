using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEyes : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private LayerMask _layerMask;

    private void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward), out RaycastHit hit, 100, _layerMask))
        {
            PointOfInterest pointOfInterest = hit.GetComponent<PointOfInterest>();
        
            if (pointOfInterest == null)
                return;

            if (pointOfInterest.IsInvestigated == true)
                return;

            pointOfInterest.Investigate();
            string audioEventName = pointOfInterest.AudioEventName;
            string audioFolderName = pointOfInterest.AudioFolderName;
            soundEvent.Post(gameObject);
            AkSoundEngine.SetSwitch(audioFolderName, audioEventName, Player);
        }
    }
}

