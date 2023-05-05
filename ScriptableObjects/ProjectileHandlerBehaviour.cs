using Assets.ProjectileSystem.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Damien.ProjectileSystem.ScriptableObjects
{
    [System.Serializable] [CreateAssetMenu(fileName = "ProjectileHandlerBehaviour", menuName = "Damien/Projectile System/Create Projectile Handler Behaviour")]
    internal class ProjectileHandlerBehaviour : ScriptableObject
    {
        public string Name;
        public float Speed;
        public SplineConfiguration[] Splines;
        public GameObject Vfx_Base;
        public GameObject Vfx_Trail;
        public GameObject Vfx_Destroy;
        public GameObject Vfx_Hit;

        internal GameObject GetNextSpline()
        {
            GameObject handler = null;
            var current = 0;
            var weights = Splines.ToDictionary(x => x.Spline, x => new KeyValuePair<int, int>(current, current += x.Weight));
            var random = UnityEngine.Random.Range(0, Splines.Sum(x => x.Weight));

            foreach (var weight in weights)
            {
                if (weight.Value.Key <= random && weight.Value.Value > random)
                {
                    handler = weight.Key;
                }
            }
            return handler;
        }
    }

}