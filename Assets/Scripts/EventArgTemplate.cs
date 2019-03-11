using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventArgTemplate<T> : EventArgs {
	
	public T Attachment { get; private set; }

	public EventArgTemplate(T attachment) {
		Attachment = attachment;
	}
	
}
