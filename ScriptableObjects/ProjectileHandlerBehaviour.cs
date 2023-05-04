using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Damien.ProjectileSystem.ScriptableObjects
{
    [System.Serializable] [CreateAssetMenu(fileName = "ProjectileHandlerBehaviour", menuName = "Damien/Projectile System/Create Projectile Handler Behaviour")]
    internal class ProjectileHandlerBehaviour : ScriptableObject
    {
        public string Name;
        public float Speed;
        public GameObject VfxBase;
    }

}