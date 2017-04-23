using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Menu {
public interface IMenu{

    void Update(SteamVR_TrackedObject controller);
    bool isMenuClose();
}
}
