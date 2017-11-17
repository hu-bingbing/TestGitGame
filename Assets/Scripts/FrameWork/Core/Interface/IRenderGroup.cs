using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRenderGroup  {

    void AddData(object data);
    void InserDataAt(object data, int index);
    void RemoveData(object data);
    void RemoveDataAt(int index);

}
