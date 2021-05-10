﻿namespace HTML
{ 
  // HTML engine for generation of a HTML string from an array of HTML tag elements:

  public interface ITagged { string TagId { get; } }  // Used to define HTML tag element

  public interface INested { object[] Elements { get; } }  // Used to "mark" a HTML tag element as nested

  public static class Engine
  {
    public static string Generate(params object[] elements)
    {
      // TODO: Your code for (recursive) generation of a HTML string from array "elements" here...
    }
  }
}