# WebviewCSharpTemplate
A template for fully contained webpages in C# Webview

## What does this template let me do?

You can embed multiple html pages in a single application, and have it interact with a C# backend.

## How?

By using [sharpWebview](https://github.com/webview/webview_csharp) and embedding your html in your program.

Each time you compile your app, your html and its resources (js/css files) are inlined and added to Resources.resx, where you can access them from C#.

## Information about the example

* Examples of html pages
* Navigation between pages
* Invoking C# functions from js

## How to use

Download the project

navigate to html
run npm install

# Requirements

* node.js
  * the inlining and Resources.resx manipulation is done by js scripts (located at html/build-script/)
* Visual Studio
