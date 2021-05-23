/*
 *	Copyright (c) 2021, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
