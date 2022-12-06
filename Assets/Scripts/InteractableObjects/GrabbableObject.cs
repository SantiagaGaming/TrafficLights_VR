using AosSdk.Core.Interaction;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace AosSdk.Examples
{

    public class GrabbableObject : BaseObject, IGrabbable
    {
        public UnityAction<string> OnObjectGrabbedIn;
        public UnityAction<string> OnObjectGrabbedOut;

        [SerializeField] private Transform _ugrabPos;
        [field: SerializeField] public GrabType GrabType { get; set; }
        [field: SerializeField] public Transform GrabAnchor { get; set; }
        public bool IsGrabbable { get; set; } = true;
        public bool IsGrabbed { get; set; }
        public void OnGrabbed(InteractHand interactHand)
        {
            OnObjectGrabbedIn?.Invoke(objectName);
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = false;
            if (outlineObjects == null)
                return;
                foreach (var outline in outlineObjects)
                {
                outline.OutlineWidth = 0;
                }
        }
        public void OnUnGrabbed(InteractHand interactHand)
        {
            OnObjectGrabbedOut?.Invoke(objectName);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = _ugrabPos.position;
            transform.rotation = _ugrabPos.rotation;
            GetComponent<Collider>().isTrigger = true;
        }
    }
}