﻿using System.Linq;
using BH.oM.RemoteCompute;
using BH.oM.RemoteCompute.RhinoCompute;

namespace BH.Engine.RemoteCompute.RhinoCompute
{
    public static partial class Convert
    {
        public static ResthopperInput ToBHoM(this FormerSchema formerSchema)
        {
            if (formerSchema == null)
                return default(ResthopperInput);

            ResthopperInput result = new ResthopperInput()
            {
                Data = formerSchema.Values.Select(v => new ResthopperInputTree() { InnerTree = v.InnerTree, ParamName = v.ParamName }).ToList(),
                RecursionLevel = formerSchema.RecursionLevel,
                Script = string.IsNullOrWhiteSpace(formerSchema.Pointer) ? formerSchema.Algo : formerSchema.Pointer,
                StoreOutputsInCache = formerSchema.CacheSolve
            };

            return result;
        }
    }
}