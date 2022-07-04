﻿using System;
using BH.oM.RemoteCompute.RhinoCompute;
using log = BH.Engine.RemoteCompute.Log;

namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Convert
    {
        public static Type RhinoToGHType(this Type t, bool enableWarnings = true)
        {
            Type equivalentGrasshopperType = null;
            if (TypeConversions.RhinoToGHTypes.TryGetValue(t, out equivalentGrasshopperType))
                return equivalentGrasshopperType;

            if (enableWarnings)
                log.RecordWarning($"No equivalent Grasshopper type found for type: {t.FullName}");

            return null;
        }
    }
}