using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableSourceNode : MonoBehaviour {

    public ASTNode InitExpNode;
    // 変数の値
    public AudubonValue Value { get; private set; }
    // GUI上での変数の値の表現
    ConstNode SampleNode;
    public GameObject cube;

    void Update()
    {
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

    public GameObject CreateVariableNode()
    {
        GameObject instance = Instantiate(SampleNode.gameObject,transform.position + new Vector3(1,1,1), 
                                          transform.rotation) as GameObject;
        Destroy(instance.GetComponent<ConstNode>());
        instance.AddComponent<VariableNode>();
        instance.GetComponent<VariableNode>().Source = this;
        return instance;
    }
    
    public void Set(AudubonValue value)
    {
        Value = value;
        updateSampleNode();
    }

    void updateSampleNode()
    {
        GameObject instance = Instantiate(cube, this.transform.position + new Vector3(1, 1, 1), transform.rotation);
        Value.AddDefaultNode(instance);
        SampleNode = instance.GetComponent<ConstNode>();
    }

    void AddDefaultNode(GameObject obj, AudubonValue value)
    {
        value.AddDefaultNode(obj);
    }   

    void AddDefaultNode(GameObject obj, AudubonInt value)
    {

        obj.AddComponent<IntNode>();
        obj.GetComponent<IntNode>().InitValue = (int)value.Value;
    }
    void AddDefaultNode(GameObject obj, AudubonBool value)
    {
        obj.AddComponent<BoolNode>();
        obj.GetComponent<BoolNode>().InitValue = (bool)value.Value;
    }
    void AddDefaultNode(GameObject obj, AudubonFloat value)
    {
        obj.AddComponent<FloatNode>();
        obj.GetComponent<FloatNode>().InitValue = (float)value.Value;
    }

}
