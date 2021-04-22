/*
 *	Copyright (c) 2021, <AUTHOR>
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech.Dataspace
{

	public class EventDataEventArgs<TValue>
	{
		public TValue NewValue { get; internal set; }
		public TValue OldValue { get; internal set; }

		public EventDataEventArgs(TValue oldValue, TValue newValue)
		{
			OldValue = oldValue;
			NewValue = newValue;
		}
	}

	public abstract class EventData<TValue, TEventArgs> where TEventArgs : EventDataEventArgs<TValue>
	{
		public TValue Value
		{
			get => value;
			set
			{
				var args = GetEventArgs(Value, value);

				this.value = value;
				OnValueChanged?.Invoke(this, args);
			}
		}

		private TValue value;

		public EventData(TValue value) => Value = value;

		public event EventHandler<TEventArgs> OnValueChanged;

		#region ABSTRACT
		protected abstract TEventArgs GetEventArgs(TValue oldValue, TValue newValue);
		#endregion
	}
}
