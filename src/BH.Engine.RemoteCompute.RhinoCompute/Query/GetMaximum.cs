﻿using BH.Engine.RemoteCompute.RhinoCompute.Objects;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Special;
using Grasshopper.Kernel.Types;
using BH.oM.RemoteCompute.RhinoCompute;


namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Query
    {
        public static object GetMaximum(this InputGroup inputGroup)
        {
            var p = inputGroup.Param;

            if (p is IGH_ContextualParameter && p.Sources.Count == 1)
                p = p.Sources[0];

            if (p is GH_NumberSlider paramSlider)
                return paramSlider.Slider.Maximum;

            return null;
        }
    }
}
