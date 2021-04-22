#if DATASPACE_GRIDLOCK_SUPPORT
using Andtech.Gridlock;
#endif
using UnityEngine;

/*
Float, float
Int, int
String, string
Vector3Int, Vector3Int
Rotation, Rotation
===
public class $0DataEventArgs : EventDataEventArgs<$1>
{
public $0DataEventArgs($1 oldValue, $1 newValue) : base(oldValue, newValue) { }
}
public class $0Data : EventData<$1, $0DataEventArgs>
{
public $0Data($1 value = default) : base(value) { }

protected override $0DataEventArgs GetEventArgs($1 oldValue, $1 newValue) => new $0DataEventArgs(oldValue, newValue);
}
/**/

namespace Andtech.Dataspace
{

	public class FloatDataEventArgs : EventDataEventArgs<float>
	{
		public FloatDataEventArgs(float oldValue, float newValue) : base(oldValue, newValue) { }
	}

	public class FloatData : EventData<float, FloatDataEventArgs>
	{
		public FloatData(float value = default) : base(value) { }

		protected override FloatDataEventArgs GetEventArgs(float oldValue, float newValue) => new FloatDataEventArgs(oldValue, newValue);
	}

	public class IntDataEventArgs : EventDataEventArgs<int>
	{
		public IntDataEventArgs(int oldValue, int newValue) : base(oldValue, newValue) { }
	}

	public class IntData : EventData<int, IntDataEventArgs>
	{
		public IntData(int value = default) : base(value) { }

		protected override IntDataEventArgs GetEventArgs(int oldValue, int newValue) => new IntDataEventArgs(oldValue, newValue);
	}

	public class StringDataEventArgs : EventDataEventArgs<string>
	{
		public StringDataEventArgs(string oldValue, string newValue) : base(oldValue, newValue) { }
	}

	public class StringData : EventData<string, StringDataEventArgs>
	{
		public StringData(string value = default) : base(value) { }

		protected override StringDataEventArgs GetEventArgs(string oldValue, string newValue) => new StringDataEventArgs(oldValue, newValue);
	}

	public class Vector3IntDataEventArgs : EventDataEventArgs<Vector3Int>
	{
		public Vector3IntDataEventArgs(Vector3Int oldValue, Vector3Int newValue) : base(oldValue, newValue) { }
	}

	public class Vector3IntData : EventData<Vector3Int, Vector3IntDataEventArgs>
	{
		public Vector3IntData(Vector3Int value = default) : base(value) { }

		protected override Vector3IntDataEventArgs GetEventArgs(Vector3Int oldValue, Vector3Int newValue) => new Vector3IntDataEventArgs(oldValue, newValue);
	}

#if DATASPACE_GRIDLOCK_SUPPORT
	public class RotationDataEventArgs : EventDataEventArgs<Rotation>
	{
		public RotationDataEventArgs(Rotation oldValue, Rotation newValue) : base(oldValue, newValue) { }
	}

	public class RotationData : EventData<Rotation, RotationDataEventArgs>
	{
		public RotationData(Rotation value = default) : base(value) { }

		protected override RotationDataEventArgs GetEventArgs(Rotation oldValue, Rotation newValue) => new RotationDataEventArgs(oldValue, newValue);
	}
#endif
}
