using AosSdk.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasObjectHelper _canvasObjectHelper;
    private List<BaseObject> _baseObjects = new List<BaseObject>();

    public static GameManager Instance;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
    private void Start()
    {
        StartCoroutine(Delay());
    }
    public void AddBaseObject(BaseObject baseObject)
    {
        _baseObjects.Add(baseObject);
    }
    private void OnShowTextHelper(string baseObjectName, Transform helperPos)
    {

        _canvasObjectHelper.ShowTextHelper(baseObjectName, helperPos);
    }
    private void OnHideTextHelper(string baseObjectName)
    {
        _canvasObjectHelper.HidetextHelper();
    }
    private void InitDelay()
    {
        if (_baseObjects.Count < 1)
            return;
        foreach (var baseObject in _baseObjects)
        {
            baseObject.OnObjectHoveredIn += OnShowTextHelper;
            baseObject.OnObjectHoveredOut += OnHideTextHelper;
            if (baseObject.TryGetComponent(out GrabbableObject grabbableObject))
                grabbableObject.OnObjectGrabbedIn += OnHideTextHelper;
        }
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.2f);
        InitDelay();
    }

}
