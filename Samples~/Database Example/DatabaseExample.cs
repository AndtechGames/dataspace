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

    public class DatabaseExample : MonoBehaviour
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

        private void Animals_Created(DatabaseEventArgs<Guid, Animal> e)
        {
            e.Data.Name.OnValueChanged += Name_OnValueChanged;

            Debug.Log($"{e.Data} was created");
        }

        private void Name_OnValueChanged(string oldValue, string newValue)
        {
            Debug.Log($"{nameof(Animal.Name)} was changed from \"{oldValue}\" to \"{newValue}\"");
        }

        private void Animals_Deleted(DatabaseEventArgs<Guid, Animal> e)
        {
            e.Data.Name.OnValueChanged -= Name_OnValueChanged;

            Debug.Log($"{e.Data} was deleted");
        }
    }
}
