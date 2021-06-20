using System;
using System.Collections.Generic;
using SharpWebview;
using SharpWebview.Content;

namespace WebviewCSharpTemplate
{
    class Program
    {
        // To show console, go to project properties and change "Output type" to "Console Application" instead of "Windows Application"
        /*
            About Resources.resx:
                It is modified on every compile.
                A resource will be generated for each one of your .html files, 
                the name of the resource will be the same as your html file (but without the extention).
                
                The resource named pageList is an array in string form of the names of all your pages
                It is automatically generated and modified on each compile

                Sometimes delete the files manually in Resources.resx if there is a problem

            About running:
                The pre-build event that compiles and inlines html will always fire, even if you dont change any cs
                
            About creating a single .exe or other application
                I created a publish profile to do that for windows
                The profile is named SingleWindows
                It will create a x64 Windows exe, with all inlined html and other resources included inside of it
                Go to Build > Publish > SingleWindows.pubxml then click publish

         */

        private static readonly bool debugMode = true;

        private static readonly int width = 800;
        private static readonly int height = 800;

        static void Main(string[] args)
        {
            // Try not to use many pages
            Dictionary<string, HtmlContent> pageHTML = GeneratePageList();

            // Create webview (view https://github.com/webview/webview_csharp for more information)
            using (var webview = new Webview(debugMode, true))
            {
                webview
                    .SetTitle("Loading...")
                    .SetSize(width, height, WebviewHint.Fixed)

                    // Here you can use .Bind() to create functions that js can call.
                    // args is a string such as ["arg1","arg2","arg3",...]

                    // Set up function binds
                    // cs_extern_initialize(pageTitle) sets the title of the window to that of the page
                    // effects: changes window title
                    // requires: only one argument
                    .Bind("cs_extern_initialize", (id, args) => {
                        string title = args.Trim(new char[] { '[', '\"', ']' });

                        webview.SetTitle(title);
                    })

                    // cs_extern_navigate(pageName) consumes a single argument, navigates to a page
                    // effects: changes view to another page
                    // requires: pageName is a valid page
                    .Bind("cs_extern_navigate", (id, args) => {
                        string navTarget = args.Trim(new char[] { '[', '\"', ']' });

                        Console.WriteLine("Navigating to => " + navTarget);

                        webview.Navigate(pageHTML[navTarget]);

                        
                    })


                    .Bind("cs_send", (id, args) => {
                        webview.Return(id, RPCResult.Success, "{ result: 'Hello' }");
                    })

                    // Go to index.html first
                    .Navigate(pageHTML["index"])
                    .Run();
            }

        }


        // GeneratePageList() returns a Dictionary<string, HtmlContent> where the key is the file name of the page
        //  and the value is the html
        // time: O(n) where n is the number of pages
        private static Dictionary<string, HtmlContent> GeneratePageList()
        {
            // get resource names
            string[] pages = Properties.Resources.pageList.Split(',');

            Dictionary<string, HtmlContent> pageContent = new Dictionary<string, HtmlContent>();

            foreach (string page in pages)
            {
                pageContent.Add(page, new HtmlContent(Properties.Resources.ResourceManager.GetString(page)));
            }

            return pageContent;
        }
    }
}
