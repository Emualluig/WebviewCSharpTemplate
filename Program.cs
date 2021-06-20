using System;

namespace WebviewCSharpTemplate
{
    class Program
    {
        // To show console, go to project properties and change "Output type" to "Console Application" instead of "Windows Application"
        /*
            About Resources.resx
                It is modified on every compile.
                A resource will be generated for each one of your .html files, 
                the name of the resource will be the same as your html file (but without the extention).
                
                The resource named pageList is an array in string form of the names of all your pages
                It is automatically generated and modified on each compile
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
