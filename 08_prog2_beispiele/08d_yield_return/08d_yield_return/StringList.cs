using System;
using System.Collections;

namespace Examples
{
	namespace Tools
	{ 
		class StringList : IEnumerable
		{
			// Internal classes:

			public class Element
			{
				public string Data;
				public Element Next;

				public Element(string data, Element next)
				{
					Data = data;
					Next = next;
				}
			}

			// Data field:
			
			Element first = null;
			
			// Read-only property:

			public Element First
			{
				get { return first; }
			}

			// Method:

			public void Prepend(string data)
			{
				Element newElement = new Element(data, First);

				first = newElement;
			}

			// Interface implementation:

			public IEnumerator GetEnumerator()
			{
				Element element = First;

				while (element != null)
				{
					yield return element.Data;	// !

					element = element.Next;
				}
			}
		}
	}
}
