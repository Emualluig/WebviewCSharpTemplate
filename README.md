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

Open in visual studio

Run the command `npm install` in the folder html

Create dir named dist

Run the project

# Requirements

* node.js
  * the inlining and Resources.resx manipulation is done by js scripts (located in html/build-script/)
* Visual Studio

# TODO:

 - [ ] Options to better emulate a native application (limit text selection, limit image dragging, etc..)
 - [ ] Create Child Windows
 - [ ] Navigate between pages without losing state
 - [ ] Update build scripts to potentially use Webpack

