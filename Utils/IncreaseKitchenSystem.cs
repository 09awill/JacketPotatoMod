using HarmonyLib;
using Kitchen;
using KitchenData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using KitchenBurritoMod;
using BurritoMod.Customs.Providers;
using KitchenLib.Utils;
using Unity.Mathematics;
using System.Reflection;

namespace KitchenBurritoMod.Utils
{
    [UpdateAfter(typeof(CreateFranchiseKitchen))]
    internal class IncreaseKitchenSystem : FranchiseFirstFrameSystem
    {
        
        protected override void OnUpdate()
        {
            Mod.LogWarning("Adding franchise kitchen slot");
            CreateSlot(new Vector3(3f, 0f, 6f), Vector3.left);            
        }

        protected void CreateSlot(Vector3 pos, Vector3 face)
        {
            Entity entity = base.EntityManager.CreateEntity(typeof(RebuildKitchen.CFranchiseKitchenSlot));
            base.EntityManager.AddComponentData(entity, new CPosition(pos, quaternion.LookRotation(face, new float3(0f, 1f, 0f))));
        }
    }

}
