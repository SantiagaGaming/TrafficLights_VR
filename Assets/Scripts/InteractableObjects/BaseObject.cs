using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using AosSdk.ThirdParty.QuickOutline.Scripts;
using System.Collections.ObjectModel;

public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    public UnityAction<string,Transform> OnObjectHoveredIn;
    public UnityAction<string> OnObjectHoveredOut;
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string objectName;
    public string HelperName() => objectName;

    protected Collider Collider;
    private void Start()
    {
        GameManager.Instance.AddBaseObject(this);
        Collider = gameObject.GetComponent<Collider>();
    }

    public virtual void OnClicked(InteractHand interactHand)
    {

    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
  
        if (outlineObjects == null)
            return;
            foreach (var outline in outlineObjects)
            {
                outline.OutlineWidth = 3;
            }
        if (helperPos == null)
            return;
        OnObjectHoveredIn?.Invoke(objectName, helperPos);
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
        OnObjectHoveredOut?.Invoke(objectName);
        if (outlineObjects == null)
            return;
            foreach (var outline in outlineObjects)
            {
                outline.OutlineWidth = 0;
            }
    }

    public virtual void EnableObject(bool value)
    {
        if (Collider != null)
            Collider.enabled = value;
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = value;
    }
}