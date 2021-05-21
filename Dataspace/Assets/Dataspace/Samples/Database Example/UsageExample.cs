using System;
using UnityEngine;

namespace Andtech.Dataspace
{

	public class Animal
	{
		public readonly StringData Name;
		public readonly Guid Id = Guid.NewGuid();

		public Animal(string name)
		{
			Name = new StringData(name);
		}


		public override string ToString() => Name.Value;
	}

	public class UsageExample : MonoBehaviour
	{
		private readonly Database<Guid, Animal> animals = new Database<Guid, Animal>();

		void Start()
		{
			animals.Created += Animals_Created;
			animals.Deleted += Animals_Deleted;

			var animal0 = new Animal("Al");
			var animal1 = new Animal("Barry");
			var animal2 = new Animal("Charlie");

			animals.Add(animal0.Id, animal0);
			animals.Add(animal1.Id, animal1);
			animals.Add(animal2.Id, animal2);

			animal0.Name.Value = "Phillip";
		}

		private void Animals_Created(object sender, DatabaseEventArgs<Guid, Animal> e)
		{
			e.Data.Name.OnValueChanged += Name_OnValueChanged;

			Debug.Log($"{e.Data} was created");
		}

		private void Name_OnValueChanged(object sender, StringDataEventArgs e)
		{
			Debug.Log($"{nameof(Animal.Name)} was changed to \"{e.NewValue}\"");
		}

		private void Animals_Deleted(object sender, DatabaseEventArgs<Guid, Animal> e)
		{
			e.Data.Name.OnValueChanged -= Name_OnValueChanged;

			Debug.Log($"{e.Data} was deleted");
		}
	}
}
