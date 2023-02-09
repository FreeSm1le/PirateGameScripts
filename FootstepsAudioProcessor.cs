using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class WwiseFootsteps : MonoBehaviour
{
    [SerializeField] private gameObject _footLeft;  // это объект левой ноги. перетаскиваем в компонент
    [SerializeField] private gameObject _footRight; // объект правой ноги
    [SerializeField] private AK.Wwise.Event _footevent; // выбираем ивент Wwise
    [SerializeField] private LayerMask _lm;

    private vThirdPersonInput _tpInput;
    private vThirdPersonController _tpController;

    private void Start()
    {
        _tpInput = GetComponent<vThirdPersonInput>();
        _tpController = GetComponent<vThirdPersonController>();
    }

    private void PlayFootstep(string side) // функция проверки поверхности для  нужного геймобъекта, вызывается из аниматора
    {
        if (tpInput.cc.inputMagnitude < 0.1)
            return;

        GameObject footObject = null;
        
        if (side == AudioGlobalTextVariables.Left) // если вызвали функцию с аргументом Left
        {
            footObject = footLeft;
        }
        else if (side == AudioGlobalTextVariables.Right) // то же самое для правой ноги
        {
            footObject = footRight;
        }

        if (Physics.Raycast(footObject.transform.position, Vector3.down, out RaycastHit hit, 0.6f, _lm)) // запускаем рейкаст из объекта нужной ноги вниз
        {
            AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Surface, hit.collider.tag, footObject);  // выставляем свитч нужной свитч-группы в положение такое же как тэг поверхности,  на которую наступила нога, применяем свитч для нужной ноги

            if (_tpController.isSprinting)
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Running, footObject);
            }
            else 
            {
                AkSoundEngine.SetSwitch(AudioGlobalTextVariables.Locomotion, AudioGlobalTextVariables.Walking, footObject);
            }
 
            _footevent.Post(footObject); // запускаем ивент для из нужной ноги
        }
    }
}
