using Kitchen;
using KitchenMods;
using static KitchenJacketPotato.Mod;

namespace JacketPotatoMod.Patches;

public class ForcePlatedPotatoGroupSystem : GameSystemBase, IModSystem
{
    protected override void OnUpdate()
    {
        var entityQuery = GetEntityQuery(typeof(CItem));

        using var entities = entityQuery.ToEntityArray(Unity.Collections.Allocator.Temp);
        using var itemData = entityQuery.ToComponentDataArray<CItem>(Unity.Collections.Allocator.Temp);

        for (int i = 0; i < entities.Length; i++)
        {
            var e = entities[i];
            var item = itemData[i];
            var items = item.Items;

            if (items.Count != 2 || item.ID == JacketPotatoWithBeans.ID)
                continue;

            if ((items[0] == Plate.ID && items[1] == JacketPotato.ID) ||
                (items[0] == JacketPotato.ID && items[1] == Plate.ID))
            {
                LogInfo($"[PlatedPotato] MATCH FOUND on entity {e.Index}:{e.Version} | Converting");
                item.ID = JacketPotatoWithBeans.ID;
                EntityManager.SetComponentData(e, item);
            }
        }
    }
}