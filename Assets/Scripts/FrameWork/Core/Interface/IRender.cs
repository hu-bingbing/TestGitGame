using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRender
{
    int index { set; get; }
    void overrideData(object data);
    IRenderGroup group { set; get; }

}
