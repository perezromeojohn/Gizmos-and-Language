using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BE2_UI_VariableViewer : MonoBehaviour
{
    string _variable;
    InputField _inputField;

    void Awake()
    {
        _variable = GetVariableName();
        _inputField = transform.GetChild(1).GetComponent<InputField>();
    }

    void OnEnable()
    {
        BE2_MainEventsManager.Instance.StartListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValue);
        _inputField.onEndEdit.AddListener(delegate { UpdateVariableValue(); });
    }

    void OnDisable()
    {
        _inputField.onEndEdit.RemoveAllListeners();
        BE2_MainEventsManager.Instance.StopListening(BE2EventTypes.OnAnyVariableValueChanged, UpdateViewerValue);
    }

    void Start()
    {
        UpdateViewerValue();
        UpdateVariableValue();
    }

    //void Update()
    //{
    //
    //}

    public void RefreshViewer()
    {
        _variable = GetVariableName();
        UpdateViewerValue();
        UpdateVariableValue();
    }

    void UpdateViewerValue()
    {
        _inputField.text = BE2_VariablesManager.instance.GetVariableStringValue(_variable);
    }

    void UpdateVariableValue()
    {
        BE2_VariablesManager.instance.AddOrUpdateVariable(_variable, _inputField.text);
    }

    // v2.1 - added method in the variable viwer UI to get variable name
    string GetVariableName()
    {
        string varName = "";
        Transform varBlockTransform = transform.GetChild(0);

        //                                  | block     | section   | header    | text      |
        varName = BE2_Text.GetBE2Text(varBlockTransform.GetChild(0).GetChild(0).GetChild(0)).text;

        return varName;
    }
}
