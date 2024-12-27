using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using UnityEngine;

[HarmonyPatch]
internal class FoodEffect_Proc_Patch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(FoodEffect), nameof(FoodEffect.Proc))]
    public static void Postfix(Chara c, Thing food)
	{
		bool flag = FoodEffect.IsUndeadFlesh(food);
		if ((food.IsDecayed || flag) && !c.HasElement(480, 1))
		{
			return;
		}
		foreach (Element element in food.elements.dict.Values)
		{
			List<Element> list = food.ListValidTraits(true, false);
			if (!element.source.foodEffect.IsEmpty() && list.Contains(element) && element.source.foodEffect[0] == "little" && !(c.race.id == "mutant") && c.elements.Base(1230) < 10)
			{
				c.Say("little_adam", c);
                c.SetFeat(1230, c.elements.Base(1230) + 1);
            }
		}
	}

}