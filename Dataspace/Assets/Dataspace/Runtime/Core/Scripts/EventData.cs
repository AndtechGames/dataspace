using System;

namespace Andtech.Dataspace
{

	public abstract class EventData<TValue>
	{
		public TValue Value
		{
			get => value;
			set
			{
				var oldValue = Value;
				var newValue = value;

				this.value = value;
				OnValueChanged?.Invoke(oldValue, newValue);
			}
		}

		private TValue value;

		public EventData(TValue value) => Value = value;

		public event Action<TValue, TValue> OnValueChanged;
	}
}
