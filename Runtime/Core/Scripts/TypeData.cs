/*
 *	Copyright (c) 2021, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

#if DATASPACE_GRIDLOCK_SUPPORT
using Andtech.Gridlock;
#endif
using UnityEngine;

namespace Andtech.Dataspace
{

    public class BooleanData : EventData<bool>
    {
        public BooleanData(bool value = default) : base(value) { }
    }

    public class IntData : EventData<int>
    {
        public IntData(int value = default) : base(value) { }
    }

    public class FloatData : EventData<float>
    {
        public FloatData(float value = default) : base(value) { }
    }

    public class StringData : EventData<string>
    {
        public StringData(string value = default) : base(value) { }
    }

    public class Vector3IntData : EventData<Vector3Int>
    {
        public Vector3IntData(Vector3Int value = default) : base(value) { }
    }

    public class ColorData : EventData<Color>
    {
        public ColorData(Color value = default) : base(value) { }
    }

#if DATASPACE_GRIDLOCK_SUPPORT
    public class RotationData : EventData<Rotation>
    {
        public RotationData(Rotation value = default) : base(value) { }
    }
#endif
}
