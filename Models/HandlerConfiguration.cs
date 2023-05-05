using Damien.ProjectileSystem.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Damien.ProjectileSystem.Models
{

    [System.Serializable]
    internal class HandlerConfiguration
    {
        public int Order;
        public int Weight;
        public ProjectileHandlerBehaviour Handler;
    }
}