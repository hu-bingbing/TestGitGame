using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdate  {

    int interval { get; }

    void update();
}
