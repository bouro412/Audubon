using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSourceNode : MonoBehaviour {
    public string VarName;
    TextMesh info;

    public ASTNode InitExpNode;
    // 変数の値
    public AudubonValue Value { get; private set; }
    // GUI上での変数の値の表現
    ConstNode SampleNode;
    public GameObject PlaneNode;

    void Start() {
        this.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    void Update()
    {
        displayInformation();
        if(Value == null)
        {
            if(InitExpNode != null)
            {
                Value = InitExpNode.eval();
                if(Value != null)
                {
                    Destroy(InitExpNode.gameObject);
                }
            }
        }else if(SampleNode == null)
        {
            updateSampleNode();
        }
    }

    
    [ContextMenu("CreateVariableNode")]
    public GameObject CreateVariableNode()
    {

        GameObject instance = Instantiate(PlaneNode.gameObject,transform.position + new Vector3(1,1,1), 
                                          transform.rotation) as GameObject;
        instance.AddComponent<VariableNode>();
        var variable = instance.GetComponent<VariableNode>();
        variable.Source = this;
        variable.VarName = VarName;

        return instance;
    }
    
    public void Set(AudubonValue value)
    {
        Value = value;
        updateSampleNode();
    }

    void updateSampleNode()
    {
        GameObject instance = Instantiate(PlaneNode, this.transform.position + new Vector3(1, 1, 1), transform.rotation);
        Value.AddDefaultNode(instance);
        SampleNode = instance.GetComponent<ConstNode>();
    }

    void displayInformation() {
        if(info == null) {
            info = GetComponentInChildren<TextMesh>();
        }
        info.text = VarName;
    }
}
