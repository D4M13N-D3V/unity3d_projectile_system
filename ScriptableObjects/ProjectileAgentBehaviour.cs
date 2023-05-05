using Damien.ProjectileSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Damien.ProjectileSystem.ScriptableObjects
{
    [System.Serializable] [CreateAssetMenu(fileName = "Projectile", menuName = "Damien/Projectile System/Create Projectile Agent Behaviour")]
    internal class ProjectileAgentBehaviour : ScriptableObject
    {
        public string Name;
        public bool Continous;
        public float AttackRange;
        public int AttackSpeed;
        public bool HandlerUseWeights = true;
        public bool HandlerUseOrder = false;
        public HandlerConfiguration[] Handlers;

        internal ProjectileHandlerBehaviour GetNextHandlerByOrder(ref int currentHandlerIndex)
        {
            var result = Handlers[currentHandlerIndex].Handler;
            currentHandlerIndex++;
            if (currentHandlerIndex >= Handlers.Length)
                currentHandlerIndex = 0;
            return result;
        }

        internal ProjectileHandlerBehaviour GetNextHandlerByWeights()
        {
            ProjectileHandlerBehaviour handler = null;
            var current = 0;
            var weights = Handlers.ToDictionary(x => x.Handler, x => new KeyValuePair<int, int>(current, current += x.Weight));
            var random = UnityEngine.Random.Range(0, Handlers.Sum(x => x.Weight));

            foreach (var weight in weights)
            {
                if (weight.Value.Key <= random && weight.Value.Value >= random)
                {
                    handler = weight.Key;
                }
            }
            return handler;
        }
    }
}

