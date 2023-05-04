using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damien.ProjectileSystem.ScriptableObjects
{
    [System.Serializable] [CreateAssetMenu(fileName = "ProjectileAgentBehaviour", menuName = "Damien/Projectile System/Create Projectile Agent Behaviour")]
    internal class ProjectileAgentBehaviour : ScriptableObject
    {
        public string Name;
        public bool Continous;
        public float AttackRange;
        public int AttackSpeed;
        public bool HandlerUseWeights = true;
        public bool HandlerUseOrder = false;
        public HandlerModel[] Handlers;
    }

    [System.Serializable]
    internal class HandlerModel
    {
        public int Order;
        public int Weight;
        public ProjectileHandlerBehaviour Handler;
    }
}

