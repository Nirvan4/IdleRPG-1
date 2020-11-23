﻿using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable] public class IntEvent : UnityEvent<int>{}
[Serializable] public class StringEvent : UnityEvent<string>{}

namespace Resources {
	public class ResourceUI : MonoBehaviour {

		public StringEvent AmountChanged;
		public Text amountText;
		public Text resourceNameText;
		Resource resource;

		void Update() {
			this.resourceNameText.text = this.resource.name;
			this.amountText.color = this.resource.color;
			this.resourceNameText.color = this.resource.color;
		}

		public void SetUp(Resource resource) {
			this.resource = resource;
			this.resource.OwnedChanged.AddListener(OnOwnedChanged);
		}

		void OnOwnedChanged(int value) {
			this.AmountChanged.Invoke(value.ToString());
		}

		public void Produce() {
			this.resource.Produce();
		}
	}
}
