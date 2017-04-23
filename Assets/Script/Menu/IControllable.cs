using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audubon.Menu
{
    public interface IControllable
    {

        void BeforeUpdate(SteamVR_TrackedObject controller);
        void Update(SteamVR_TrackedObject controller);
        void AfterUpdate(SteamVR_TrackedObject controller);

    }
    public static class IControllableExt
    {
        public static void Controll(this IControllable ic, SteamVR_TrackedObject controller)
        {
            ic.BeforeUpdate(controller);
            ic.Update(controller);
            ic.AfterUpdate(controller);
        }
    }
}
