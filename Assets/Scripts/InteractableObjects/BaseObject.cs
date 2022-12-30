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
    [HideInInspector]public bool InAction { get; set; } = false;

    [SerializeField] protected OutlineCore[] outlineObjects;
    [SerializeField] protected Transform helperPos;
    [SerializeField] protected string objectName;
    [SerializeField] private string _objectHelperName;
    public string ObjectName => objectName;

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
        OutlineObject(false);
        OnObjectHoveredIn?.Invoke(_objectHelperName, helperPos);
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
            OnObjectHoveredOut?.Invoke(objectName);
        if (!InAction)
            OutlineObject(false);
    }
    public void OutlineObject(bool value)
    {
        if (outlineObjects == null)
            return;
        foreach (var outline in outlineObjects)
        {
            if(value)
            outline.OutlineWidth = 3;
            else
                outline.OutlineWidth = 0;
        }
        if (helperPos == null)
            return;
    }

    public virtual void EnableObject(bool value)
    {
        if (Collider != null)
            Collider.enabled = value;
        if (GetComponent<SpriteRenderer>())
            GetComponent<SpriteRenderer>().enabled = value;
    }
}