using Content.Server.Botany.Components;
using Content.Shared.EntityEffects;
using JetBrains.Annotations;
using Robust.Shared.Prototypes;

[UsedImplicitly]
[DataDefinition]
public sealed partial class PlantOpporozidone : EntityEffect
{
    public override void Effect(EntityEffectBaseArgs args)
    {
        if (!args.EntityManager.TryGetComponent(args.TargetEntity, out PlantHolderComponent? plantHolderComp)
            || plantHolderComp.Seed == null
            || !plantHolderComp.Dead) // The plant must be dead to be revived
            return;

        plantHolderComp.Dead = false;
        plantHolderComp.Health += 5;
    }
    protected override string? ReagentEffectGuidebookText(IPrototypeManager prototype, IEntitySystemManager entSys) => Loc.GetString("reagent-effect-guidebook-plant-opporozidone", ("chance", Probability));
}
