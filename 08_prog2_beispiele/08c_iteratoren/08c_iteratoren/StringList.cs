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

			class Enum : IEnumerator
			{
				StringList stringList;

				Element current = null;

				public Enum(StringList stringList)
				{
					this.stringList = stringList;
				}

				public bool MoveNext()
				{
					if (current == null)
					{
						current = stringList.First;
					}
					else
					{
						current = current.Next;
					}

					return current != null;
				}

				public void Reset()
				{
					current = null;
				}

				public object Current 
				{
					get { return current.Data; }
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
				return new StringList.Enum(this);
			}
		}
	}
}
