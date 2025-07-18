﻿using DetectionEquipment.Shared.BlockLogic.GenericControls;
using System;
using Sandbox.ModAPI;

namespace DetectionEquipment.Client.BlockLogic.Countermeasures
{
    internal class CountermeasureControls : TerminalControlAdder<IMyConveyorSorter>
    {
        protected override Func<IMyTerminalBlock, bool> VisibleFunc => block => block.GetLogic<ClientCountermeasureLogic>() != null;
        public override string IdPrefix => "CountermeasureControls_";

        protected override void CreateTerminalActions()
        {
            CreateToggle(
                "FireToggle",
                "Shoot On/Off",
                "Toggles firing this countermeasure emitter.",
                b => b.GetLogic<ClientCountermeasureLogic>().Firing,
                (b, v) => b.GetLogic<ClientCountermeasureLogic>().Firing = v
                );

            CreateAction(
                "FireToggleAction",
                "Shoot On/Off",
                b =>
                {
                    var logic = b.GetLogic<ClientCountermeasureLogic>();
                    logic.Firing = !logic.Firing;
                },
                (b, sb) =>
                {
                    var logic = b.GetLogic<ClientCountermeasureLogic>();
                    sb.Append($"{(logic.Reloading ? "REL" : "RDY")}  {(logic.Firing ? " On" : "Off")}");
                },
                @"Textures\GUI\Icons\Actions\Toggle.dds"
                );
        }

        protected override void CreateTerminalProperties()
        {
            
        }
    }
}
