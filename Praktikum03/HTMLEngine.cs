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

                if (myNestedObject is null || myTaggedObject is null) // obj is of raw information type - not html element. no further recursion possible -> add & continue
                {
                    doc += obj;
                    continue;
                }
                doc += "\n" + myTaggedObject.TagId;
                doc += myNestedObject is null ? "" : Generate(myNestedObject.Elements); // use of ternary operator to "skip" not nested html elements // Recursive function call for nested elements
                doc += "\n" + myTaggedObject.TagId[..1] + "/" + myTaggedObject.TagId[1..]; // add forward slash for "closing html elements"
            }
            return doc;
        }
    }
}