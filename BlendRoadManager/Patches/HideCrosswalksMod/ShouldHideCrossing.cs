namespace BlendRoadManager.Patches.HideCrosswalksMod {
    using System.Reflection;
    using BlendRoadManager;
    using CSUtil.Commons;
    using Harmony;

    [HarmonyPatch]
    public static class ShouldHideCrossing {
        public static MethodBase TargetMethod() {
            return typeof(HideCrosswalks.Patches.CalculateMaterialCommons).
                GetMethod(nameof(HideCrosswalks.Patches.CalculateMaterialCommons.ShouldHideCrossing));
        }

        public static bool Prefix(ushort nodeID, ref bool __result) {
            var data = NodeBlendManager.Instance.buffer[nodeID];
            return PrefixUtils.HandleTernaryBool(
                data?.ShouldHideCrossingTexture(),
                ref __result);
        }
    }
}