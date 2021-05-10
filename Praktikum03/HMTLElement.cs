namespace HTML
{
    public class NestedAndTagged : ITagged, INested
    {
        public virtual string TagId { get; } // becomes overriden by child class
        public object[] Elements { get; }
        public NestedAndTagged(params object[] elements)
        {
            Elements = elements;
        }
    }

    public class DocumentType : ITagged
    {
        public string TagId { get { return "<DOCTYPE! html>"; } }
        public override string ToString() { return TagId; }
    }
    public class Html : NestedAndTagged
    {
        public override string TagId { get { return "<html>"; } }
        public Html(params object[] elements) : base(elements) { }
    }
    public class Title : NestedAndTagged
    {
        public override string TagId { get { return "<title>"; } }
        public Title(params object[] elements) : base(elements) { }
    }
    public class Head : NestedAndTagged
    {
        public override string TagId { get { return "<head>"; } }
        public Head(params object[] elements) : base(elements) { }
    }
    public class Body : NestedAndTagged
    {
        public override string TagId { get { return "<body>"; } }
        public Body(params object[] elements) : base(elements) { }
    }
    public class Heading1 : NestedAndTagged
    {
        public override string TagId { get { return "<h1>"; } }
        public Heading1(params object[] elements) : base(elements) { }
    }
    public class Heading2 : NestedAndTagged
    {
        public override string TagId { get { return "<h2>"; } }
        public Heading2(params object[] elements) : base(elements) { }
    }
    public class Paragraph : NestedAndTagged
    {
        public override string TagId { get { return "<p>"; } }
        public Paragraph(params object[] elements) : base(elements) { }
    }
    public class Underline : NestedAndTagged
    {
        public override string TagId { get { return "<u>"; } }
        public Underline(params object[] elements) : base(elements) { }
    }
    public class Bold : NestedAndTagged
    {
        public override string TagId { get { return "<b>"; } }
        public Bold(params object[] elements) : base(elements) { }
    }
    public class Italic : NestedAndTagged
    {
        public override string TagId { get { return "<i>"; } }
        public Italic(params object[] elements) : base(elements) { }
    }
    public class LineBreak : ITagged
    {
        public string TagId { get { return "<br/>"; } }
    }
}