namespace HTML
{
    public interface ITagged { string TagId { get; } }  // Used to define HTML tag element
    public interface INested { object[] Elements { get; } }  // Used to "mark" a HTML tag element as nested
    public static class Engine
    {
        public static string Generate(params object[] elements)
        {
            string doc = "";

            foreach (object obj in elements)
            {
                ITagged myTaggedObject = obj as ITagged;
                INested myNestedObject = obj as INested;

                if (myNestedObject is null || myTaggedObject is null) // obj is of raw information type (or non nested decorator). no further recursion possible -> add & continue
                {
                    doc += obj;
                    continue;
                }
                doc += $"\n{myTaggedObject.TagId}" + Generate(myNestedObject.Elements) + $"\n{myTaggedObject.TagId[..1]}/{myTaggedObject.TagId[1..]}";// Recursive function call for nested elements
            }
            return doc;
        }
    }
}