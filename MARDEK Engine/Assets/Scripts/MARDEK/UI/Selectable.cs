using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MARDEK.Audio;

namespace MARDEK.UI
{
    public class Selectable : MonoBehaviour
    {
        [SerializeField] UnityEvent OnSelected = new UnityEvent();
        [SerializeField] UnityEvent OnDeselected = new UnityEvent();
        [SerializeField] AudioObject selectionSFX;
        
        public virtual bool isValid()
        {
            return true;
        }
        public virtual void Select(bool playSFX = true)
        {
            OnSelected.Invoke();
            if(playSFX && selectionSFX)
                AudioManager.PlaySoundEffect(selectionSFX);
        }
        public virtual void Deselect()
        {
            OnDeselected.Invoke();
        }
    }
}